/*******************************************************************
* Copyright ? 2017—2021 Perfect World.Co.Ltd. All rights reserved.
* author: 移动项目支持部 ZEUS FRAMEWORK TEAM
********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zeus.Framework.Asset;
using UnityEngine.SceneManagement;

public class ZeusAssetManagerTest : MonoBehaviour {

    // Use this for initialization
    Dictionary<string, List<LoadData>> cachedObject = new Dictionary<string, List<LoadData>>();
    Dictionary<string, List<ObsoleteLoadData>> cachedObsoleteObject = new Dictionary<string, List<ObsoleteLoadData>>();

    private string inputText1 = "Test/prefab2";
    private string inputText2 = "Test/baseDep1Prefab";
    private string inputText3 = "Test/baseDep2Prefab";
    private string inputText4 = "Test/baseDep3Prefab";

    private string loadSceneText = "Load Scene";

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnGUI()
    {
        float view_x = 10.0f;
        float inputText_Y = 10.0f;
        int inputTextCount = 0;
        inputText1 = GUI.TextField(new Rect(view_x, inputText_Y + 30*inputTextCount++, 360, 20), inputText1);
        inputText2 = GUI.TextField(new Rect(view_x, inputText_Y + 30 * inputTextCount++, 360, 20), inputText2);
        inputText3 = GUI.TextField(new Rect(view_x, inputText_Y + 30 * inputTextCount++, 360, 20), inputText3);
        inputText4 = GUI.TextField(new Rect(view_x, inputText_Y + 30 * inputTextCount++, 360, 20), inputText4);
        GUI.Label(new Rect(170, 30 * inputTextCount++, 550, 20), loadSceneText);
        float button_Y = 30 * inputTextCount++;
        int button_count = 0;
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "SyncLoad"))
        {
            LoadSyncToInstantiateObject(inputText1);
        }
        
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "UrgentLoad"))
        {
            LoadUrgentToInstantiateObject(inputText1);
        }
        
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "AsyncLoad"))
        {
            UnityEngine.Profiling.Profiler.BeginSample("LoadAsyncToInstantiateObject");
            LoadAsyncToInstantiateObject(inputText1);
            UnityEngine.Profiling.Profiler.EndSample();
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "AsyncLoadObjects"))
        {
            List<string> objects = new List<string>();
            objects.Add(inputText1);
            //objects.Add(inputText2);
//             objects.Add(inputText3);
//             objects.Add(inputText4);
             objects.Add(inputText4);
             objects.Add(inputText1);
            //////////////////////////

            LoadAsyncToInstantiateObjects(objects);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "AsyncLoadObjects2"))
        {
            List<string> objects = new List<string>();
            objects.Add(inputText1);
            objects.Add(inputText2);
            objects.Add(inputText3);
            objects.Add(inputText4);
            LoadAsyncToInstantiateObjects2(objects);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "AsyncLoadObjects3"))
        {
            List<string> objects = new List<string>();
            objects.Add("Texture/banghui/banghui001");
            objects.Add("Texture/banghui/banghui002");
            objects.Add("Texture/banghui/banghui003");
            objects.Add("Texture/banghui/banghui004");
            objects.Add("Texture/banghui/banghui005");
            objects.Add("Texture/banghui/banghui006");
            objects.Add("Texture/banghui/banghui007");
            objects.Add("Texture/banghui/banghui008");
            objects.Add("Texture/banghui/banghui009");
            objects.Add("Texture/banghui/banghui010");
            objects.Add("Texture/banghui/banghui011");
            objects.Add("Texture/banghui/banghui012");
            objects.Add("Texture/banghui/banghui013");
            objects.Add("Texture/banghui/banghui014");
            objects.Add("Texture/banghui/banghui015");
            objects.Add("Texture/banghui/banghui016");
            objects.Add("Texture/banghui/banghui017");
            objects.Add("Texture/banghui/banghui018");
            objects.Add("Texture/banghui/banghui019");
            objects.Add("Texture/banghui/banghui020");
            objects.Add("Texture/banghui/banghui021");

            objects.Add("Texture/banghui02/banghui001");
            objects.Add("Texture/banghui02/banghui002");
            objects.Add("Texture/banghui02/banghui003");
            objects.Add("Texture/banghui02/banghui004");
            objects.Add("Texture/banghui02/banghui005");
            objects.Add("Texture/banghui02/banghui006");
            objects.Add("Texture/banghui02/banghui007");
            objects.Add("Texture/banghui02/banghui008");
            objects.Add("Texture/banghui02/banghui009");
            objects.Add("Texture/banghui02/banghui010");
            objects.Add("Texture/banghui02/banghui011");
            objects.Add("Texture/banghui02/banghui012");
            objects.Add("Texture/banghui02/banghui013");
            objects.Add("Texture/banghui02/banghui014");
            objects.Add("Texture/banghui02/banghui015");
            objects.Add("Texture/banghui02/banghui016");
            objects.Add("Texture/banghui02/banghui017");
            objects.Add("Texture/banghui02/banghui018");
            objects.Add("Texture/banghui02/banghui019");
            objects.Add("Texture/banghui02/banghui020");
            objects.Add("Texture/banghui02/banghui021");

            objects.Add("Texture/banghui03/banghui001");
            objects.Add("Texture/banghui03/banghui002");
            objects.Add("Texture/banghui03/banghui003");
            objects.Add("Texture/banghui03/banghui004");
            objects.Add("Texture/banghui03/banghui005");
            objects.Add("Texture/banghui03/banghui006");
            objects.Add("Texture/banghui03/banghui007");
            objects.Add("Texture/banghui03/banghui008");
            objects.Add("Texture/banghui03/banghui009");
            objects.Add("Texture/banghui03/banghui010");
            objects.Add("Texture/banghui03/banghui011");
            objects.Add("Texture/banghui03/banghui012");
            objects.Add("Texture/banghui03/banghui013");
            objects.Add("Texture/banghui03/banghui014");
            objects.Add("Texture/banghui03/banghui015");
            objects.Add("Texture/banghui03/banghui016");
            objects.Add("Texture/banghui03/banghui017");
            objects.Add("Texture/banghui03/banghui018");
            objects.Add("Texture/banghui03/banghui019");
            objects.Add("Texture/banghui03/banghui020");
            objects.Add("Texture/banghui03/banghui021");

            objects.Add("Texture/banghui04/banghui001");
            objects.Add("Texture/banghui04/banghui002");
            objects.Add("Texture/banghui04/banghui003");
            objects.Add("Texture/banghui04/banghui004");
            objects.Add("Texture/banghui04/banghui005");
            objects.Add("Texture/banghui04/banghui006");
            objects.Add("Texture/banghui04/banghui007");
            objects.Add("Texture/banghui04/banghui008");
            objects.Add("Texture/banghui04/banghui009");
            objects.Add("Texture/banghui04/banghui010");
            objects.Add("Texture/banghui04/banghui011");
            objects.Add("Texture/banghui04/banghui012");
            objects.Add("Texture/banghui04/banghui013");
            objects.Add("Texture/banghui04/banghui014");
            objects.Add("Texture/banghui04/banghui015");
            objects.Add("Texture/banghui04/banghui016");
            objects.Add("Texture/banghui04/banghui017");
            objects.Add("Texture/banghui04/banghui018");
            objects.Add("Texture/banghui04/banghui019");
            objects.Add("Texture/banghui04/banghui020");
            objects.Add("Texture/banghui04/banghui021");

            objects.Add("Texture/fengxin/fengxin01");
            objects.Add("Texture/fengxin/fengxin02");
            objects.Add("Texture/fengxin/fengxin03");
            objects.Add("Texture/fengxin/fengxin04");
            objects.Add("Texture/fengxin/fengxin05");
            objects.Add("Texture/fengxin/fengxin06");
            objects.Add("Texture/fengxin/fengxin07");
            objects.Add("Texture/fengxin/fengxin08");
            objects.Add("Texture/fengxin/fengxin09");
            objects.Add("Texture/fengxin/fengxin10");
            objects.Add("Texture/fengxin/fengxin11");
            objects.Add("Texture/fengxin/fengxin12");
            objects.Add("Texture/fengxin/fengxin13");
            objects.Add("Texture/fengxin/fengxin14");
            objects.Add("Texture/fengxin/fengxin15");
            objects.Add("Texture/fengxin/fengxin16");
            objects.Add("Texture/fengxin/fengxin17");
            objects.Add("Character/Hero");
            objects.Add("Character/Hero");
            objects.Add("UI/prefab/ui_areaserver_item");
            objects.Add("UI/prefab/ui_createrole");
            objects.Add("UI/prefab/ui_loading");
            objects.Add("UI/prefab/ui_noticewithtext");
            objects.Add("UI/prefab/ui_selectserver");
            objects.Add("UI/prefab/ui_noticewithtext");
            objects.Add("UI/prefab/ui_server_item");
            objects.Add("UI/prefab/ui_store");
            objects.Add("UI/prefab/ui_store_item");
            objects.Add("UI/prefab/ui_task_item");
            objects.Add("UI/prefab/ui_task_list");
            objects.Add("UI/prefab/Common/LoadingPanel");
            objects.Add("UI/prefab/Dialog/Dialog");
            objects.Add("UI/prefab/Login/LoginPanel");

            LoadAsyncToInstantiateObjects3(objects);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "Unload"))
        {
            UnLoadAsyncToInstantiateObject(inputText1);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "UnloadObsolete"))
        {
            List<ObsoleteLoadData> loadDataList = cachedObsoleteObject[inputText1];
            loadDataList[loadDataList.Count - 1].Release();
            loadDataList.RemoveAt(loadDataList.Count - 1);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "ALSL_load"))
        {
            SyncLoadWhenAsyncNotComplete();
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "loadScene"))
        {
            Debug.Log("Load scene: " + inputText1);
            LoadSceneSingle(inputText1);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "loadSceneAdditive"))
        {
            Debug.Log("Load scene: " + inputText1);
            LoadSceneAdditive(inputText1);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "AsyncLoadScene"))
        {
            Debug.Log("Load scene: " + inputText1);
            AsyncLoadScene(inputText1, LoadSceneMode.Single);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "AsyncLoadSceneAdditive"))
        {
            Debug.Log("Load scene: " + inputText1);
            AsyncLoadScene(inputText1, LoadSceneMode.Additive);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "UnloadScene"))
        {
            Debug.Log("UnLoad scene: " + inputText1);
            AsyncUnLoadScene(inputText1);
        }
        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "TestGetAssetBundlePath"))
        {
            TestGetAssetBundlePath();
        }

        if (GUI.Button(new Rect(view_x, button_Y + 30 * button_count++, 160, 20), "LoadnotInstance"))
        {
            LoadSyncToInstantiateObject(inputText1, false);
        }
        button_count = 0;
        if (GUI.Button(new Rect(view_x + 160 + 10, button_Y + 30 * button_count++, 160, 20), "LoadInstance"))
        {
            LoadSyncToInstantiateObject(inputText1, true);
        }
        if (GUI.Button(new Rect(view_x + 160 + 10, button_Y + 30 * button_count++, 160, 20), "UnloadUnusedAssets"))
        {
            Resources.UnloadUnusedAssets();
        }
        
        if (GUI.Button(new Rect(view_x + 160 + 10, button_Y + 30 * button_count++, 160, 20), "TestAssetGroup1"))
        {
            StartCoroutine(this.TestAssetGroup1());
        }

        if (GUI.Button(new Rect(view_x + 160 + 10, button_Y + 30 * button_count++, 160, 20), "TestResourceLoadAsync"))
        {
            TestResourceLoadAsync(inputText1);
        }

        if (GUI.Button(new Rect(view_x + 160 + 10, button_Y + 30 * button_count++, 160, 20), "ObsoleteLoad"))
        {
            ObsoleteLoadToInstantiateObject(inputText1);
        }

        if (GUI.Button(new Rect(view_x + 160 + 10, button_Y + 30 * button_count++, 160, 20), "ObsoleteAsyncLoad"))
        {
            ObsoleteLoadAsyncToInstantiateObject(inputText1);
        }
    }

    private void SyncLoadWhenAsyncNotComplete()
    {
        LoadAsyncToInstantiateObject(inputText1);
        LoadSyncToInstantiateObject(inputText1);
    }

    private void LoadSyncToInstantiateObject(string assetPath, bool instanceObject = true)
    {
        IAssetRef assetRef = AssetManager.LoadAsset(assetPath);
        
        if (instanceObject)
        {
            InstantiateObject(assetRef);
        }
        else
        {
            assetRef.Retain();
        }
    }

    private void LoadAsyncToInstantiateObject(string assetPath)
    {
        AssetManager.LoadAssetAsync(assetPath,
            (IAssetRef assetRef, object param) =>
            {
                InstantiateObject(assetRef);
            },
            null);
    }

    private void LoadUrgentToInstantiateObject(string assetPath)
    {
        AssetManager.LoadAssetUrgent(assetPath,
            (IAssetRef assetRef, object param) =>
            {
                InstantiateObject(assetRef);
            },
            null);
    }

    private void LoadAsyncToInstantiateObjects(List<string> assetList)
    {
        for (int i = 0; i < assetList.Count; i++)
        {
            string assetPath = assetList[i];
            AssetManager.LoadAssetAsync(
                assetPath,
                (IAssetRef assetRef, object param) =>
                {
                    InstantiateObject(assetRef);
                },
                null);
        }
    }

    private void LoadAsyncToInstantiateObjects3(List<string> assetList)
    {
        for (int i = 0; i < assetList.Count; i++)
        {
            string assetPath = assetList[i];
            AssetManager.LoadAssetAsync(
                assetPath,
                (IAssetRef assetRef, object param) =>
                {
                    //Debug.Log("LoadAsyncToInstantiateObjects3: " + assetRef.AssetPath);
                    InstantiateObject(assetRef);
                },
                null);
        }
        Debug.Log("LoadAsyncToInstantiateObjects3: " + assetList.Count);
    }

    private void TestInnerSpeed(List<string> assetList)
    {
        for (int i = 0; i < assetList.Count; i++)
        {
            string abName;
            string assetName;
            if (AssetBundleUtils.TryGetAssetBundleName(assetList[i], out abName, out assetName))
            {
                //assetList[i] = AssetBundleUtils._GetRelativeBundlePath(abName);
                Debug.Log(assetList[i]);
            }
            else
            {
                Debug.LogWarning("not found asset " + assetList[i]);
            }
        }
        for(int i = 0; i < 50; i++)
        {
            assetList.Add(assetList[0] + "01" + i);
        }
        assetList.AddRange(assetList);
        int count = 0;
        System.DateTime now = System.DateTime.Now;
        for (int i = 0; i < assetList.Count; i++)
        {
            if (Zeus.Core.FileSystem.VFileSystem.ExistsFile(assetList[i]))
            //if(Zeus.Core.FileSystem.InnerPackage.ExistsFile(assetList[i]))
            {
                count++;
            }
        }
        System.TimeSpan span = System.DateTime.Now - now;
        Debug.Log("TestInnerSpeed: " + span.TotalSeconds);
        Debug.Log("TestInnerSpeed: exist count: " + count + " not exist count:" + (assetList.Count - count));
    }

    private void LoadAsyncToInstantiateObjects2(List<string> assetList)
    {
        Debug.Assert(assetList.Count > 3, "LoadAsyncToInstantiateObjects2 assetList not enough");
        for (int i = 0; i < assetList.Count-1; i++)
        {
            string assetPath = assetList[i];
            string assetPath2 = assetList[assetList.Count - 1];
            AssetManager.LoadAssetAsync(
                assetPath,
                (IAssetRef assetRef, object param) =>
                {
                    InstantiateObject(assetRef);

                    AssetManager.LoadAssetAsync(
                        assetPath2,
                        (IAssetRef assetRef2, object param2) =>
                        {
                            InstantiateObject(assetRef2);
                        },
                        null);
                },
                null);
        }
    }

    private void UnLoadAsyncToInstantiateObject(string assetPath)
    {
        List<LoadData> loadDataList = cachedObject[assetPath];
        loadDataList[loadDataList.Count - 1].Release();
        loadDataList.RemoveAt(loadDataList.Count - 1);
    }

    private void LoadSceneSingle(string assetPath)
    {
        AssetManager.LoadScene(assetPath, LoadSceneMode.Single);
    }

    private void LoadSceneAdditive(string assetPath)
    {
        AssetManager.LoadScene(assetPath, LoadSceneMode.Additive);
    }

    private void AsyncLoadScene(string assetPath, LoadSceneMode loadMode)
    {
        AssetManager.LoadSceneAsync(assetPath, loadMode,
            (bool isComplete, float progress, object param) =>
            {
                loadSceneText = "Load " + assetPath + "[" + isComplete + "]:" + progress;
                if (isComplete)
                {
                    Debug.Log("AsyncLoadScene Load " + assetPath + " complete");
                }
            },
            null);
    }

    private void AsyncUnLoadScene(string assetPath)
    {
        AssetManager.UnloadSceneAsync(assetPath, 
            (bool isComplete, float progress, object param) =>
            {
                loadSceneText = "UnLoad " + assetPath + "[" + isComplete + "]:" + progress;
                Debug.Log("AsyncLoadScene UnLoad " + assetPath + " complete");
            },
            null);
    }

    private void TestGetAssetBundlePath()
    {
        List<string> bundleList = new List<string>();
        int count = 200;
        while(count > 0)
        {
            count--;
            bundleList.Add("assetbundle" + count);
        }
        for(int i = 0; i < bundleList.Count; i++)
        {
            UnityEngine.Profiling.Profiler.BeginSample("AssetBundleUtils.GetAssetBundlePath");
            AssetBundleUtils.GetAssetBundlePath(bundleList[i]);
            UnityEngine.Profiling.Profiler.EndSample();
        }
        for (int i = 0; i < bundleList.Count; i++)
        {
            UnityEngine.Profiling.Profiler.BeginSample("AssetBundleUtils.GetAssetBundlePath");
            AssetBundleUtils.GetAssetBundlePath(bundleList[i]);
            UnityEngine.Profiling.Profiler.EndSample();
        }
        Debug.Log("TestGetAssetBundlePath");
    }

    private void LoadUrgentSpeed(string assetPath)
    {
        AssetManager.LoadAssetUrgent(assetPath,
            (IAssetRef assetRef, object param) =>
            {
                Debug.Log("LoadUrgentSpeed : " + assetPath);
            },
            null);
    }

    private void LoadAsyncSpeed(string assetPath)
    {
        AssetManager.LoadAssetAsync(assetPath,
            (IAssetRef assetRef, object param) =>
            {
                Debug.Log("LoadAssetAsync : " + assetPath);
            },
            null);
    }

    
    private IEnumerator TestAssetGroup1()
    {
        Debug.Log("TestAssetGroup1");
        AssetGroup assetgroup = new AssetGroup();
        assetgroup.LoadAsset(inputText1, typeof(UnityEngine.Object));
        assetgroup.LoadAsset(inputText1, typeof(UnityEngine.Object));
        
        assetgroup.LoadAssetAsyncUrgent(inputText2, typeof(UnityEngine.Object),
          (Object assetRef, object param) =>
          {

          },
          null);
        assetgroup.LoadAssetAsync(inputText3, typeof(UnityEngine.Object),
          (Object assetRef, object param) =>
          {
              
          },
          null);
        assetgroup.LoadAsset(inputText2, typeof(UnityEngine.Object));
        yield return new WaitForSeconds(3.0f);

        assetgroup.Release();
    }

    private void TestResourceLoadAsync(string assetPath)
    {
        AssetManager.LoadAssetAsync(assetPath,
            (IAssetRef assetRef, object param) =>
            {
                //AssetManager.UnloadAsset();
                StartCoroutine(TestResourceLoadCallback(assetRef));
            },
            null);
    }

    private IEnumerator TestResourceLoadCallback(IAssetRef assetRef)
    {
        AsyncOperation operation = Resources.UnloadUnusedAssets();
        Debug.Log("TestResourceLoadCallback UnloadUnusedAssets");
        //yield return operation;
        while (!operation.isDone)
        {
            yield return null;
        }
        InstantiateObject(assetRef);
        Debug.Log("TestResourceLoadCallback : " + assetRef.AssetPath);
    }


    private void InstantiateObject(IAssetRef assetRef)
    {
        assetRef.Retain();
        if (!cachedObject.ContainsKey(assetRef.AssetPath))
        {
            List<LoadData> loadDataList = new List<LoadData>();
            cachedObject.Add(assetRef.AssetPath, loadDataList);
        }
        LoadData data = new LoadData();
        data.assetRef = assetRef;
        if (assetRef.AssetObject is GameObject)
        {
            data.obj = (GameObject)GameObject.Instantiate(assetRef.AssetObject);
        }
        else
        {
            //Debug.LogWarning("Instantiate target is not gameObject : " + assetRef.AssetPath);
        }
        cachedObject[assetRef.AssetPath].Add(data);
    }


    class LoadData
    {
        public IAssetRef assetRef;
        public GameObject obj;

        public void Release()
        {
            assetRef.Release();
            assetRef = null;
            if(obj != null)
            {
                GameObject.Destroy(obj);
                obj = null;
            }
        }
    }

    private void ObsoleteInstantiateObject(UnityEngine.Object assetObjectRef, string assetPath)
    {
        
        if (!cachedObsoleteObject.ContainsKey(assetPath))
        {
            List<ObsoleteLoadData> loadDataList = new List<ObsoleteLoadData>();
            cachedObsoleteObject.Add(assetPath, loadDataList);
        }
        ObsoleteLoadData data = new ObsoleteLoadData();
        data.objectRef = assetObjectRef;
        if (assetObjectRef is GameObject)
        {
            data.obj = (GameObject)GameObject.Instantiate(assetObjectRef);
        }
        else
        {
            //Debug.LogWarning("Instantiate target is not gameObject : " + assetRef.AssetPath);
        }
        cachedObsoleteObject[assetPath].Add(data);
    }

    class ObsoleteLoadData
    {
        public UnityEngine.Object objectRef;
        public GameObject obj;
        public void Release()
        {
            AssetManager.UnuseAsset(objectRef);
            objectRef = null;
            if (obj != null)
            {
                GameObject.Destroy(obj);
                obj = null;
            }
        }
    }

    private void ObsoleteLoadToInstantiateObject(string assetPath)
    {
        Object obj = AssetManager.GetAsset(assetPath);
        ObsoleteInstantiateObject(obj, assetPath);
    }

    private void ObsoleteLoadAsyncToInstantiateObject(string assetPath)
    {
        AssetManager.GetAssetAsync(assetPath,
            (Object assetRef, object param) =>
            {
                ObsoleteInstantiateObject(assetRef, param as string);
            },
            assetPath);
    }
}
