/*******************************************************************
* Copyright ? 2017��2021 Perfect World.Co.Ltd. All rights reserved.
* author: �ƶ���Ŀ֧�ֲ� ZEUS FRAMEWORK TEAM
********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Zeus.Framework.Asset
{
    public interface ISubPackageLoader
    {
        void DownloadSubpackage(int maxDownloadingTask,
           Action<double, double, double, SubpackageState, SubpackageError> downloadingProgressCallback,
           double limitSpeed,
           bool isBackgroundDownloading,
           string[] tags,
           bool isDownloadAll);


        void PauseDownloading();

        void SetLimitSpeed(double limitSpeed);

        void SetAllowDownloadInBackground(bool isAllowd);

        void SetCarrierDataNetworkDownloading(bool isAllowed);

        bool GetCarrierDataNetworkDownloadingAllowed();

        bool IsBackgroundDownloadAllowed();

        void SetCdnUrl(string urlsStr);

        void SetCdnUrl(string[] urls);

        void SetSucNotificationStr(string str);

        void SetFailNotificationStr(string str);

        void SetKeepAliveNotificationStr(string str);

        Dictionary<string, double> GetTag2SizeDic();

        bool IsSubpackageReady(string tag);

        bool IsHardDiskEnough();

        double CalcUnCompleteChunkSizeForTag(string tag);

        double GetSizeToDownloadOfTag(string tag);

        double GetTagSize(string tag);

        void GetSubPackageSize(out double totalSize, out double completeSize);

        void SetAssetLoadExceptionObserver(Action<AssetLoadErrorType, string> observer);

        void SetAssetRemoteLoadObserver(Action<string, string, int, float, string> observer);

        void SetTagStatusObserver(Action<string, bool> observer);
        //���Զ�ˣ�CDN����Դ�Ƿ���������ڳ��������������Ƿ��ϴ�
        void CheckRemoteFileStatus(Action<ChunkListStatus> remote);

        void AddPercentNotification(int percent, string notificationStr);

        void ClearPercentNotification();
    }
}
