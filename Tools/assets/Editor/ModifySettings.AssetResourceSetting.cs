/*******************************************************************
* Copyright © 2017—2020 Perfect World.Co.Ltd. All rights reserved.
* author: 移动项目支持部 ZEUS FRAMEWORK TEAM
********************************************************************/
#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;
using Zeus.Framework.Asset;
using System.Collections.Generic;
using Zeus.Core.FileSystem;
using System.Text;

namespace Zeus.Build
{
    class ModifyAssetResourceSetting : IModifyPlayerSettings, IFinallyBuild
    {
        private static readonly string StartScenePath = "Assets/Scene/Start.unity";
        private static bool recoverSetting = true;
        private static AssetLoaderType assetLoader_original;
        private static EditorBuildSettingsScene[] EditorSettingScenesOldValue;
        private static AssetManagerSetting oriSetting;

        //实现接口方法
        public void OnModifyPlayerSettings(BuildTarget target)
        {
            RemoveDeletedScene();
            EditorSettingScenesOldValue = new EditorBuildSettingsScene[EditorBuildSettings.scenes.Length];
            System.Array.Copy(EditorBuildSettings.scenes, EditorSettingScenesOldValue, EditorBuildSettings.scenes.Length);

            AssetLoaderType loaderType = AssetLoaderType.AssetBundle;
            bool useBundleLoader = false;
            if (CommandLineArgs.TryGetBool(GlobalBuild.CmdArgsKey.USE_BUNDLELOADER, ref useBundleLoader))
            {
                //修改ZeusAssetManagerSetting.json  
                if (!useBundleLoader)
                {
                    loaderType = AssetLoaderType.Resources;
                }
                //修改BuildSettings中的Scenes In Build
                else
                {
                    List<string> scenesList = AssetManagerSetting.LoadSetting().bundleLoaderSetting.ScenesInBuild;
                    if (scenesList.Count > 0)
                    {
                        EditorBuildSettingsScene[] scenes = new EditorBuildSettingsScene[scenesList.Count];
                        for (int i = 0; i < scenes.Length; ++i)
                        {
                            scenes[i] = new EditorBuildSettingsScene(scenesList[i], true);
                        }
                        EditorBuildSettings.scenes = scenes;
                    }
                    else
                    {
                        EditorBuildSettings.scenes = new EditorBuildSettingsScene[] { new EditorBuildSettingsScene(StartScenePath, true) };
                    }
                }
            }
            oriSetting = AssetManagerSetting.LoadSetting();
            AssetManagerSetting newSetting = AssetManagerSetting.LoadSetting();
            newSetting.assetLoaderType = loaderType;
            if(newSetting.assetLoaderType == AssetLoaderType.AssetBundle)
            {
                if (target == BuildTarget.Android)
                {
                    bool isFillFirstPackage = false;
                    if (CommandLineArgs.TryGetBool(GlobalBuild.CmdArgsKey.IS_FILL_FIRSTPACKAGE_ANDROID, ref isFillFirstPackage))
                    {
                        newSetting.bundleLoaderSetting.isFillFirstPackageAndroid = isFillFirstPackage;
                        if (isFillFirstPackage)
                        {
                            int fillSize = 0;
                            if (CommandLineArgs.TryGetInt(GlobalBuild.CmdArgsKey.FILL_FIRSTPACKAGE_SIZE_ANDROID, ref fillSize))
                            {
                                newSetting.bundleLoaderSetting.TargetAndroidAssetSizeInMB = fillSize;
                            }
                        }
                    }
                }
                else if(target == BuildTarget.iOS)
                {
                    bool isFillFirstPackage = false;
                    if (CommandLineArgs.TryGetBool(GlobalBuild.CmdArgsKey.IS_FILL_FIRSTPACKAGE_IOS, ref isFillFirstPackage))
                    {
                        newSetting.bundleLoaderSetting.isFillFirstPackageiOS = isFillFirstPackage;
                        if (isFillFirstPackage)
                        {
                            int fillSize = 0;
                            if (CommandLineArgs.TryGetInt(GlobalBuild.CmdArgsKey.FILL_FIRSTPACKAGE_SIZE_IOS, ref fillSize))
                            {
                                newSetting.bundleLoaderSetting.TargetiOSAssetSizeInMB = fillSize;
                            }
                        }
                    }
                }
            }

            AssetManagerSetting.SaveSetting(newSetting);
        }

        //去除EditorBuildSettings中被删除的Scene
        private static void RemoveDeletedScene()
        {
            if (EditorBuildSettings.scenes.Length > 0)
            {
                List<EditorBuildSettingsScene> newScenes = new List<EditorBuildSettingsScene>();
                for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
                {
                    EditorBuildSettingsScene scene = EditorBuildSettings.scenes[i];
                    if(string.IsNullOrWhiteSpace(scene.path))
                    {
                        continue;
                    }
                    string fullPath = Path.GetFullPath(scene.path);
                    if (File.Exists(fullPath))
                    {
                        newScenes.Add(scene);
                    }
                }
                EditorBuildSettings.scenes = newScenes.ToArray();
                newScenes.Clear();
                newScenes = null;
            }
        }


        //[Build.FinallyBuild]
        public void OnFinallyBuild(BuildTarget target, string outputPath)
        {
            bool useBundleLoader = false;
            if (CommandLineArgs.TryGetBool(GlobalBuild.CmdArgsKey.USE_BUNDLELOADER, ref useBundleLoader))
            {
                if (recoverSetting)
                {
                    AssetManagerSetting.SaveSetting(oriSetting);
                    EditorBuildSettings.scenes = EditorSettingScenesOldValue;
                }
            }
        }
    }
}
#endif