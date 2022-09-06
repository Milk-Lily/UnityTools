using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Zeus.Framework.Asset
{
    public class UnloadSceneAsyncOperation : CustomYieldInstruction
    {
        bool _isDone = false;
        public UnloadSceneAsyncOperation(string scenePath)
        {
            //UnityEngine.Debug.Log("UnloadSceneAsyncOperation " + scenePath);
            AssetManager.UnloadSceneAsync(scenePath, this.ActionUnloadScene, null);
        }

        private void ActionUnloadScene(bool isDone, float progress, object param)
        {
            if(isDone)
            {
                _isDone = true;
            }
        }
        public override bool keepWaiting { get{ return !_isDone;} }
    }
}

