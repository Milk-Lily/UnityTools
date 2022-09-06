/*******************************************************************
* Copyright ? 2017��2021 Perfect World.Co.Ltd. All rights reserved.
* author: �ƶ���Ŀ֧�ֲ� ZEUS FRAMEWORK TEAM
********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zeus.Framework.Http.UnityHttpDownloader;

namespace Zeus.Framework.Asset
{
    [Flags]
    public enum AssetLoadErrorType
    {
        None = ErrorType.None,
       
        //Զ�̼���bundle������Ĵ�������
        //��������޷�������Դ
        NetError = ErrorType.NetError,����������������
        IOException = ErrorType.IOException,
        Exception = ErrorType.Exception,
        //���߳�����֮��ϲ��ļ�����
        CombineFile = ErrorType.CombineFile,
        //��Դ��CDN�ϲ�����
        MissingFile = ErrorType.MissingFile,
        //�����������޷�������Դ
        HardDiskFull = ErrorType.HardDiskFull,
        //������ɺ�У��ʧ��
        MD5Error = ErrorType.CheckFail,
        //��Դ�����ڣ�������Сдƴд����
        AssetNotExist = 1 << 12,
        //bundle����ʧ��
        BundleLoadFailed = 1 << 13,
        //��bundle�м���Assetʧ��
        AssetLoadFailed = 1 << 14,

        //ͬ��������Դ��bundle������
        AssetSyncLoadBundleNotReady = 1 << 15,
        //��������
        Others = 1 << 16
    }
}
