/*******************************************************************
* Copyright © 2017—2021 Perfect World.Co.Ltd. All rights reserved.
* author: 移动项目支持部 ZEUS FRAMEWORK TEAM
********************************************************************/
using System;
using UnityEngine;
using Zeus.Core;
using System.Collections.Generic;

namespace Zeus.Framework.Hotfix
{
    public class CustomHotfixService : HotfixService
    {
        private long lastCurrent = 0;
        private float timer = 0f;
        private float timer2 = 0.1f;
        private bool needReload = false;

        CustomHotfixServiceUI ui;

        public CustomHotfixService() : base()
        {
            ui = new GameObject("CustomHotfixServiceUI").AddComponent<CustomHotfixServiceUI>();
        }

        public void StartHotfix()
        {
            needReload = false;
            RegistCallbacks();
            ZeusCore.Instance.StartCoroutine(this.Execute());
        }

        public override void OnProcess(HotfixStep step, long current, long target)
        {
            string title = string.Empty;
            switch (step)
            {
                case HotfixStep.CheckAndFinishLastHotfix:
                    ui.Title = "正在解压上次下载的文件[" + +(current / 1024) + "kb/" + (target / 1024) + "kb]";
                    ui.Speed = string.Empty;
                    break;
                case HotfixStep.RequestPatchData:
                    ui.Title = "正在初始化版本信息";
                    ui.Speed = string.Empty;
                    break;
                case HotfixStep.Check:
                    ui.Title = "版本对比中";
                    ui.Speed = string.Empty;
                    break;
                case HotfixStep.Download:
                    ui.Title = "下载中[" + +(current / 1024) + "kb/" + (target / 1024) + "kb]";
                    timer += Time.deltaTime;
                    timer2 += Time.deltaTime;
                    if (timer > 0f && timer2 >= 0.5f)
                    {
                        timer2 -= 0.5f;
                        ui.Speed = "CurSpeed:" + Mathf.Max(0, (current - lastCurrent) / timer / 1024).ToString("F2") + "kb/s,AvgSpeed:" +
                            ((float)AvgDownloadSpeed / 1024).ToString("F2") + "kb/s,CostTime:" + DownloadTime + "ms";
                    }
                    if (timer >= 1f)
                    {
                        timer -= 1f;
                        lastCurrent = current;
                    }
                    break;
                case HotfixStep.Unzip:
                    ui.Title = "解压中[" + +(current / 1024) + "kb/" + (target / 1024) + "kb]";
                    ui.Speed = string.Empty;
                    break;
            }
        }
        /// <summary>
        /// 只有推荐更新的情况下才会调用此函数,使得玩家拥有选择的余地
        /// </summary>
        /// <param name="tips"></param>
        /// <param name="yesOrNo"></param>
        /// <param name="param"></param>
        public override void OnChoice(HotfixTips tips, WaitForYesOrNo yesOrNo, object param)
        {
            string tipStr = string.Empty;
            switch (tips)
            {
                case HotfixTips.RecommendDownload:
                    tipStr = "推荐更新，当前版本：" + CurVersion + ",目标版本：" + TargetVersion + ",文件大小：" + ((long)param / 1024).ToString() + "kb";
                    //true 准备下载
                    //false 跳过更新
                    break;
                case HotfixTips.HardDiskFull:
                    //true 重新检查磁盘空间
                    //false 跳过更新
                    tipStr = "存储空间不足，需要存储空间：" + ((long)param / 1024).ToString() + "kb";
                    break;
                case HotfixTips.PreDownload:
                    tipStr = "是否预下载热更版本，当前版本：" + CurVersion + ",目标版本：" + TargetVersion + ",文件大小：" + ((long)param / 1024).ToString() + "kb";
                    //true 开始预下载
                    //false 不进行预下载，跳过更新
                    break;
                case HotfixTips.AppStoreRecommandDownload:
                    tipStr = "游戏已更新，请前往应用商店更新到最新版本";
                    //true 跳转商店更包
                    //false 不更包，跳过商店推荐更新
                    break;
            }
            ui.tip = tipStr;
            ui._yesOrNo = yesOrNo;
        }

        /// <summary>
        /// 强制玩家确认的情况会调用此函数
        /// </summary>
        /// <param name="tips"></param>
        /// <param name="trigger"></param>
        /// <param name="param"></param>
        public override void OnConfirm(HotfixTips tips, WaitForTrigger trigger, object param)
        {
            string tipStr = string.Empty;
            switch (tips)
            {
                case HotfixTips.AppStoreDownload:
                    tipStr = "游戏已更新，请前往应用商店更新到最新版本";
                    break;
                case HotfixTips.ForceDownload:
                    tipStr = "强制更新，当前版本：" + CurVersion + ",目标版本：" + TargetVersion + ",文件大小：" + ((long)param / 1024).ToString() + "kb";
                    break;
                case HotfixTips.HardDiskFull:
                    tipStr = "存储空间不足，需要存储空间：" + ((long)param / 1024).ToString() + "kb";
                    break;
            }
            ui.tip = tipStr;
            ui._trigger = trigger;
        }

        /// <summary>
        /// 提示玩家发生错误并点击确认重试
        /// </summary>
        /// <param name="error"></param>
        /// <param name="trigger"></param>
        public override void OnErrorConfirm(HotfixError error, WaitForTrigger trigger, object param)
        {
            string errorStr = string.Empty;
            //此处根据需要，对错误类型加以适当的提示文本
            switch (error)
            {
                case HotfixError.NetError:
                    errorStr = "网络连接异常，无法连接服务器，请重试";
                    break;
                case HotfixError.InitError:
                    errorStr = "初始化热更版本数据失败，请重试";
                    break;
                case HotfixError.HardDiskFull:
                    errorStr = "存储空间不足，请重试，需要空间："+ ((long)param / 1024).ToString() + "kb";
                    break;
                case HotfixError.DownloadError:
                    errorStr = "下载热更文件失败，本次更新为强制更新,请确认重试";
                    break;
                default:
                    errorStr = "更新异常，请重试";
                    break;
            }
            ui.tip = errorStr;
            ui._trigger = trigger;
        }


        /// <summary>
        /// 提示玩家发生错误，选择重试或者跳过，只有推荐更新时会调用此函数
        /// </summary>
        /// <param name="error"></param>
        /// <param name="yesOrNo"></param>
        public override void OnErrorChoice(HotfixError error, WaitForYesOrNo yesOrNo, object param)
        {
            //yes:重试   no:跳过


            string errorStr = string.Empty;
            //此处根据需要，对错误类型加以适当的提示文本
            switch (error)
            {
                case HotfixError.DownloadError:
                    errorStr = "下载热更文件失败，请重试";
                    break;
                case HotfixError.HttpStatusCode404Error:
                    errorStr = "网络连接异常，无法获取服务器数据，请重试";
                    break;
                default:
                    errorStr = "更新异常，请重试";
                    break;
            }
            ui.tip = errorStr;
            ui._yesOrNo = yesOrNo;
        }

        public override void OnFinish()
        {
            UnregistCallbacks();
            ui.Title = "热更结束";
            ui.tip = string.Empty;
            ui.Speed = string.Empty;
            if (needReload)
            {
                //清理已经加载的bundle及其路径缓存，以便下次加载资源的时候使用最新的bundle
                //加载完资源调用UnloadAll(false) 确保之后加载最新资源
                Zeus.Framework.Asset.AssetManager.UnloadBundleAndReInit();
            }
        }

        #region 预下载相关接口：如果某些场景对性能及网络要求较高，可使用以下接口，用于在运行过程中对预下载进行状态查询以及开关控制
        /// <summary>
        /// 尝试开启预下载热更文件并返回结果
        /// </summary>
        /// <returns>true：开启了预下载  false：未开启预下载</returns>
        public bool TryStartPreDownload()
        {
            return base.StartPreDownload();
        }
        /// <summary>
        /// 是否正处于预下载热更文件的状态(暂停状态也会返回true)
        /// </summary>
        /// <returns></returns>
        public bool CheckIsPreDownloading()
        {
            return base.IsPreDownloading();
        }
        /// <summary>
        /// 预下载是否处于暂停状态
        /// </summary>
        /// <returns></returns>
        public bool CheckIsPreDownloadPause()
        {
            return base.IsPreDownloadPause();
        }
        /// <summary>
        /// 暂停预下载（可恢复）
        /// </summary>
        /// <returns></returns>
        public void TryPausePreDownload()
        {
            base.PausePreDownload();
        }
        /// <summary>
        /// 恢复预下载
        /// </summary>
        /// <returns></returns>
        public void TryResumePreDownload()
        {
            base.ResumePreDownload();
        }
        /// <summary>
        /// 停止预下载热更文件（停止后不可恢复）
        /// </summary>
        public void TryStopPreDownload()
        {
            base.StopPreDownLoad();
        }
        /// <summary>
        /// 获取当前正在预下载中的版本号
        /// </summary>
        public List<string> TryGetPredDownloadingVersion()
        {
            return base.GetPredDownloadingVersions();
        }

        /// <summary>
        /// 查询热更信息，
        /// （1）正常的更新：根据返回的信息正确处理就可以了
        /// （2）预下载更新：如果热更的配置文件内开启了自动预下载，则会自动进行预下载并返回无更新；如果没有开启自动预下载，则返回更新内容，
        ///                  调用方检测到返回的信息为预下载时，可以查询是否在进行预下载，来选择是否重新走热更流程，因为设置中未开启自动预下载时，
        ///                  热更会做UI层提示给玩家，最终会由玩家决定本次是否启动预下载。注：如果当前预下载内容已经开始下载了，则返回无更新。
        /// </summary>
        /// <param name="success">成功回调,参数1：热更类型  参数2：热更包大小  参数3：是否为预下载</param>
        /// <param name="fail">失败回调</param>
        /// <param name="serverUrls">自定义的查询地址，会覆盖包内配置文件的url</param>
        /// <param name="customTargetVersion">自定义查询目标版本，如果有值且与本地版本一致则无更新</param>
        /// /// <param name="controlDataUrls">自定义的查询地址，会覆盖包内配置文件的controlDataUrls</param>
        public static void CustomQueryHotfixInfo(System.Action<HotFixType, double, bool> success, System.Action<HotfixError> fail, string serverUrls = null, string customTargetVersion = null, string controlDataUrls = null)
        {
            QueryHotfixInfo(success, fail, serverUrls, customTargetVersion, controlDataUrls);
        }
        #endregion

        #region callback
        private void RegistCallbacks()
        {
            RegistOnCheckAndFinishLastHotfixStart(OnCheckAndFinishLastHotfixStart);
            RegistOnCheckAndFinishLastHotfixSuc(OnCheckAndFinishLastHotfixSuc);
            RegistOnCheckAndFinishLastHotfixFail(OnCheckAndFinishLastHotfixFail);
            RegistOnInit(OnInit);
            RegistOnDownloadStart(OnDownloadStart);
            RegistOnDownloadSuc(OnDownloadSuc);
            RegistOnDownloadFail(OnDownloadFail);
            RegistOnUnzipStart(OnUnzipStart);
            RegistOnUnzipSuc(OnUnzipSuc);
            RegistOnUnzipFail(OnUnzipFail);
        }

        private void UnregistCallbacks()
        {
            UnregistOnCheckAndFinishLastHotfixStart(OnCheckAndFinishLastHotfixStart);
            UnregistOnCheckAndFinishLastHotfixSuc(OnCheckAndFinishLastHotfixSuc);
            UnregistOnCheckAndFinishLastHotfixFail(OnCheckAndFinishLastHotfixFail);
            UnregistOnInit(OnInit);
            UnregistOnDownloadStart(OnDownloadStart);
            UnregistOnDownloadSuc(OnDownloadSuc);
            UnregistOnDownloadFail(OnDownloadFail);
            UnregistOnUnzipStart(OnUnzipStart);
            UnregistOnUnzipSuc(OnUnzipSuc);
            UnregistOnUnzipFail(OnUnzipFail);
        }

        private void OnCheckAndFinishLastHotfixStart(string version)
        {
            Debug.Log("OnCheckAndFinishLastHotfixStart:" + version);
        }

        private void OnCheckAndFinishLastHotfixSuc(string version, int time)
        {
            Debug.Log("OnCheckAndFinishLastHotfixSuc:" + version + " ,time:" + time);
        }

        private void OnCheckAndFinishLastHotfixFail(string version, string error, int time)
        {
            Debug.Log("OnCheckAndFinishLastHotfixFail:" + version + " ,error:" + error + " ,time:" + time);
        }

        private void OnInit(HotFixType type, string version)
        {
            Debug.Log("Oninit:" + type + "," + version);
        }

        private void OnDownloadStart(string[] url)
        {
            Debug.Log("OnDownloadStart:" + url[0]);
        }

        private void OnDownloadSuc(string[] url, int time)
        {
            Debug.Log("OnDownloadSuc:" + url[0] + ",time:" + time);
        }

        private void OnDownloadFail(string[] url, double size, string error, int time)
        {
            Debug.Log("OnDownloadFail:" + url[0] + ",size:" + size + ",error:" + error + ",time:" + time);
        }

        private void OnUnzipStart(string resVersion)
        {
            Debug.Log("OnUnzipStart:" + resVersion);
        }

        private void OnUnzipSuc(string resVersion, int time)
        {
            needReload = true;
            Debug.Log("OnUnzipSuc:" + resVersion + ",time:" + time);
        }

        private void OnUnzipFail(string resVersion, string name, string error, int time)
        {
            Debug.Log("OnUnzipFail:" + resVersion + ",name:" + name + ",error:" + error + ",time:" + time);
        }


        #endregion
    }

    public class CustomHotfixServiceUI : MonoBehaviour
    {
        public WaitForYesOrNo _yesOrNo;
        public WaitForTrigger _trigger;

        public string Title = string.Empty;
        public string Speed = string.Empty;
        public string tip = string.Empty;


        private void OnGUI()
        {
            GUILayout.Label(Title, new GUIStyle() { fontSize = 50 });
            if (!string.IsNullOrEmpty(tip)) GUILayout.Label(tip, new GUIStyle() { fontSize = 50 });
            if (!string.IsNullOrEmpty(Speed)) GUILayout.Label(Speed, new GUIStyle() { fontSize = 50 });

            GUILayout.BeginHorizontal();
            if (_yesOrNo != null || _trigger != null)
            {
                GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
                myButtonStyle.normal.textColor = Color.black;
                myButtonStyle.fontSize = 50;

                if (GUILayout.Button("确定", myButtonStyle))
                {
                    tip = string.Empty;
                    if (_yesOrNo != null)
                    {
                        _yesOrNo.YesOrNo(true);
                        _yesOrNo = null;
                    }
                    if (_trigger != null)
                    {
                        _trigger.Trigger();
                        _trigger = null;
                    }
                }
            }

            if (_yesOrNo != null)
            {
                GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
                myButtonStyle.normal.textColor = Color.black;
                myButtonStyle.fontSize = 50;

                if (GUILayout.Button("取消", myButtonStyle))
                {
                    tip = string.Empty;
                    _yesOrNo.YesOrNo(false);
                    _yesOrNo = null;
                }
            }
            GUILayout.EndHorizontal();
        }
    }
}