using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zeus.Framework.Asset
{
    public class LoadSceneAsyncOperation : CustomYieldInstruction
    {
        bool _isDone = false;
        public LoadSceneAsyncOperation(string scenePath, LoadSceneMode mode = LoadSceneMode.Single)
        {
            //UnityEngine.Debug.Log("LoadSceneAsyncOperation: " + scenePath + " : " + mode.ToString());
            AssetManager.LoadSceneAsync(scenePath, mode, this.ActionLoadScene, scenePath);
        }

        private void ActionLoadScene(bool isDone, float progress, object param)
        {
            if(isDone)
            {
                //UnityEngine.Debug.Log("LoadSceneAsyncOperation done: " + param as string);
                _isDone = true;
            }
        }
        public override bool keepWaiting { get{ return !_isDone;} }
    }
}

