/*******************************************************************
* Copyright © 2017—2021 Perfect World.Co.Ltd. All rights reserved.
* author: 移动项目支持部 ZEUS FRAMEWORK TEAM
********************************************************************/
using UnityEngine;
using System.Collections;
using Zeus.Core.FileSystem;
using Zeus.Framework.Asset;

namespace Zeus.Framework.Hotfix
{
    public class HotFixDownloadTest : MonoBehaviour
    {
        private void Awake()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            Application.runInBackground = true;
#endif
        }

        private IEnumerator Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            ZeusFramework.Start();
            yield return new WaitForEndOfFrame();
            Zeus.Framework.Asset.AssetManager.Init();

            SetupHotfixService();
        }

        //启动热更服务
        private void SetupHotfixService()
        {
            //热更之前可以使用bundle加载资源
            //开始热更之前要清理bundle缓存

            //热更前确保所有资源都加载完毕，热更过程中不要加载资源和requre新的lua
            //开始热更
            var service = new CustomHotfixService();
            //service.SetCustomTargetVersion("000111");
            service.StartHotfix();
            //lua需要自己清缓存否则会在下次进入游戏后生效
        }
    }
}