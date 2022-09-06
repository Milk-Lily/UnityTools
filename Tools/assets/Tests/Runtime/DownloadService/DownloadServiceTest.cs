/*******************************************************************
* Copyright ? 2017—2021 Perfect World.Co.Ltd. All rights reserved.
* author: 移动项目支持部 ZEUS FRAMEWORK TEAM
********************************************************************/
using System;
using UnityEngine;
using UnityEngine.UI;
using Zeus.Framework.Asset;

public class DownloadServiceTest : MonoBehaviour
{
    public GameObject ErrorWindow;
    public GameObject DownloadingProgressWindow;
    public GameObject DownloadManagePanel;
    public GameObject CarrierDataWarningWindow;

    private Slider _maxDownloadingTaskSlider;
    private Text _maxDownloadingTaskText;
    private Slider _downloadingProgressBar;
    private Text _downloadingProgressText;
    private Button _downloadingCompleteButton;
    private Text _errorText;

    public InputField timeout;
    public InputField readtimeout;
    public Toggle nagle;

    bool _isDownloading = false;
    private void Start()
    {
        Application.targetFrameRate = 30;

        _maxDownloadingTaskSlider = DownloadManagePanel.GetComponentInChildren<Slider>();
        _maxDownloadingTaskText = DownloadManagePanel.GetComponentInChildren<Text>();
        _downloadingProgressBar = DownloadingProgressWindow.GetComponentInChildren<Slider>();
        _downloadingProgressText = DownloadingProgressWindow.GetComponentInChildren<Text>();
        _downloadingCompleteButton = DownloadingProgressWindow.GetComponentInChildren<Button>();
        _errorText = ErrorWindow.GetComponentInChildren<Text>();
        DownloadingProgressWindow.SetActive(false);
        ErrorWindow.SetActive(false);
        CarrierDataWarningWindow.SetActive(false);
        // timeout.onEndEdit.AddListener((str)=>
        // {
        //     int timeout = 0;
        //     if(int.TryParse(str,out timeout))
        //     {
        //         Zeus.Framework.Network.UnityDownloader.TIMEOUT = timeout;
        //         Debug.Log("TimeOut: "+timeout);
        //     }
        // });
        // readtimeout.onEndEdit.AddListener((str)=>
        // {
        //     int timeout = 0;
        //     if(int.TryParse(str,out timeout))
        //     {
        //         Zeus.Framework.Network.UnityDownloader.READTIMEOUT = timeout;
        //         Debug.Log("ReadTimeOut: "+timeout);
        //     }
        // });
        // nagle.isOn = Zeus.Framework.Network.UnityDownloader.UseNagleAlgorithm;
        // nagle.onValueChanged.AddListener((b)=>
        // {

        //         Zeus.Framework.Network.UnityDownloader.UseNagleAlgorithm = b;
        //         Debug.Log("UseNagleAlgorithm: "+b);
        // });
    }

    DateTime _start;

    public void Download()
    {
        
        _start = DateTime.Now;
        _isDownloading = true;
        int i = (int)_maxDownloadingTaskSlider.value;
        if (!DownloadingProgressWindow.activeSelf)
        {
            ShowDownloadingWindow();
        }

        AssetManager.SetAllowDownloadInBackground(true);
        AssetManager.SetCarrierDataNetworkDownloading(true);
        AssetManager.SetSucNotificationStr("download suc");
        AssetManager.SetFailNotificationStr("download fail");
        AssetManager.SetKeepAliveNotificationStr("app keepalive");
        //开始下载
        AssetManager.DownloadSubpackageBundles(i, OnDownloading1);
        
        _maxDownloadingTaskText.text = _maxDownloadingTaskSlider.value.ToString();
    }

    double lastcom = 0;
    private void OnDownloading1(double completedSize, double totalSize, double avgDownloadSpeed, SubpackageState state, SubpackageError error)
    {
        if(lastcom > completedSize)
        {
            UnityEngine.Debug.LogError("lastcom(" + lastcom + ") > completedSize(" + completedSize + "),totalSize=" + totalSize);
        }
        _downloadingProgressBar.value = (float)completedSize / (float)totalSize;
        string stateText = string.Empty;
        if (state == SubpackageState.Downloading)
        {
            stateText = "[" + state.ToString() + "] ";

        }
        _downloadingProgressText.text = stateText + (completedSize / totalSize * 100).ToString("F2") + "%" + " " + (avgDownloadSpeed / 1024).ToString("F0") + "KB/S ";
        if (state == SubpackageState.Abort)
        {
            //下载出错
            if (error != SubpackageError.None)
            {
                ShowErrorWindow(error.ToString());
            }
            _isDownloading = false;
        }
        else if (state == SubpackageState.Complete)
        {
            Debug.Log("Average speed: " + totalSize / 1024 / 1024 / (DateTime.Now - _start).TotalSeconds);
            _downloadingCompleteButton.gameObject.SetActive(true);
            _isDownloading = false;
        }
    }

    /// <summary>
    /// 检查子包是否已经下载并准备就绪
    /// </summary>
    public void CheckSubpackage()
    {
        Debug.Log(_isDownloading + " " + AssetManager.IsSubpackageReady());
        AssetManager.IsSubpackageReady();
        DownloadInBG();
    }

    public void DownloadInBG()
    {
        _isDownloading = true;
        if (!DownloadingProgressWindow.activeSelf)
        {
            ShowDownloadingWindow();
        }
        AssetManager.SetAllowDownloadInBackground(true);
        AssetManager.SetCarrierDataNetworkDownloading(true);
        AssetManager.SetSucNotificationStr("download suc");
        AssetManager.SetFailNotificationStr("download fail");
        AssetManager.SetKeepAliveNotificationStr("app keepalive");
        //开始下载
        AssetManager.DownloadSubpackageInBackground(512 * 1024, OnDownloading2);
        _maxDownloadingTaskText.text = _maxDownloadingTaskSlider.value.ToString();
    }

    private void OnDownloading2(double completedSize, double totalSize, double avgDownloadSpeed, SubpackageState state, SubpackageError error)
    {
        _downloadingProgressBar.value = (float)completedSize / (float)totalSize;
        string stateText = string.Empty;
        if (state == SubpackageState.Downloading)
        {
            if (!_isDownloading)
            {
                _isDownloading = true;
            }
            if (CarrierDataWarningWindow.activeSelf)
            {
                CarrierDataWarningWindow.SetActive(false);
            }
            if (!DownloadingProgressWindow.activeSelf)
            {
                DownloadingProgressWindow.SetActive(true);
            }
            stateText = "[" + state.ToString() + "] ";
        }
        _downloadingProgressText.text = stateText + (completedSize / totalSize * 100).ToString("F2") + "%" + " " + (avgDownloadSpeed / 1024).ToString("F0") + "KB/S";
        if (state == SubpackageState.Abort)
        {
            Debug.LogError(error.ToString());
            _isDownloading = false;
        }
        else if (state == SubpackageState.WaitLocalAreaNetwork)
        {
            Debug.Log("ShowWarningWindow");
            ShowWarningWindow();
        }
        else if (state == SubpackageState.Complete)
        {
            Debug.Log("Average speed: " + totalSize / 1024 / 1024 / (DateTime.Now - _start).TotalSeconds);
            _downloadingCompleteButton.gameObject.SetActive(true);
            _isDownloading = false;
        }
    }

    private void ShowDownloadingWindow()
    {
        DownloadingProgressWindow.SetActive(true);
        _downloadingProgressBar.value = 0;
        _downloadingProgressText.text = "0.00%";
        _downloadingCompleteButton.gameObject.SetActive(false);
    }

    private void ShowErrorWindow(string errorType)
    {
        DownloadingProgressWindow.SetActive(false);
        ErrorWindow.SetActive(true);
        _errorText.text = errorType;
    }

    private void ShowWarningWindow()
    {
        DownloadingProgressWindow.SetActive(false);
        CarrierDataWarningWindow.SetActive(true);
    }

    #region ButtonEvent
    public void HideErrorWindow()
    {
        ErrorWindow.SetActive(false);
    }

    public void Cancel()
    {
        HideErrorWindow();
    }

    public void Retry()
    {
        _isDownloading = true;
        DownloadingProgressWindow.SetActive(true);
    }

    public void PauseDownloading()
    {
        if (_isDownloading)
        {
            AssetManager.PauseDownloading();
        }
    }

    public void FinishDownloading()
    {
        HideDownloadingWindow();
    }

    public void HideWarningWindow()
    {
        CarrierDataWarningWindow.SetActive(false);
    }

    public void RetryInCarrierDataNetwork()
    {
        _isDownloading = true;
        AssetManager.SetCarrierDataNetworkDownloading(true);
        DownloadingProgressWindow.SetActive(true);
        DownloadInBG();
    }
    #endregion

    private void HideDownloadingWindow()
    {
        DownloadingProgressWindow.SetActive(false);
    }

    private void Update()
    {
    }

}