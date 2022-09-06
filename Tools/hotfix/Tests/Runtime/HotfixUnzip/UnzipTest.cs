/*******************************************************************
* Copyright © 2017—2021 Perfect World.Co.Ltd. All rights reserved.
* author: 移动项目支持部 ZEUS FRAMEWORK TEAM
********************************************************************/
using System;
using UnityEngine;
using Zeus.Framework.Hotfix;

public class UnzipTest : MonoBehaviour
{
    Zeus.Framework.Hotfix.UnzipUtil unzip;
    System.IO.FileStream Stream;
    void Start()
    {
        //Stream = System.IO.File.Open(@"C:\Users\Administrator\Desktop\testUnzip\zeus-framework\build.gradle",
        //    System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
        Run();
    }

    private void Update()
    {
        if (unzip != null)
        {
            Debug.LogError("[" + unzip.UnzipSize + "/" + unzip.TargetSize + "]");
        }
    }

    public void Run()
    {
        //unzip = new UnzipUtil();
        //string zipFile = @"C:\Users\Administrator\Desktop\test.zip";
        //string targetUnzipPath = @"C:\Users\Administrator\Desktop\testUnzip";
        //unzip.SetUnzipParams(zipFile, targetUnzipPath, AddMainThreadMethod, TryHandleUnzipExtractException);
    }

    private void AddMainThreadMethod()
    {
        Zeus.Core.ZeusCore.Instance.AddMainThreadTask(OnDownloadComplete);
    }

    private void OnDownloadComplete()
    {
        UnzipUtil.UnzipError error = unzip.TopPriorityError;
        if (error == UnzipUtil.UnzipError.Null)
        {
            Debug.LogError("Unzip Success");
        }
        else
        {
            Debug.LogError("[HotfixService] [Unzip] Error:" + unzip.Error.ToString() + ", UnHandleException：" + (unzip.UnHandleException == null ? "" : unzip.UnHandleException.ToString()));
        }
        unzip = null;
    }

    private bool TryHandleUnzipExtractException(ICSharpCode.ZeusSharpZipLib.Zip.ZipFile zipFile, ICSharpCode.ZeusSharpZipLib.Zip.ZipEntry entry, Exception e)
    {
        bool result = false;
        System.IO.IOException ioe = e as System.IO.IOException;
        //处理异常
        return result;
    }
}
