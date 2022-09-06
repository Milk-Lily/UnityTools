/*******************************************************************
* Copyright © 2017—2020 Perfect World.Co.Ltd. All rights reserved.
* author: 移动项目支持部 ZEUS FRAMEWORK TEAM
********************************************************************/
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Threading;

namespace Zeus.Framework.Asset
{
    public class BundleRef : IBundleRef
    {
        private int _refcount;
        private string _bundleName;
        private AssetBundle _assetBundle;
        private LinkedList<BundleAssetRef> _assetRefList;
        private List<IBundleRef> _depBundleList;
        private IBundleCollector _collector;
        private bool _isDelayRelease = false;
        private bool _isUnloadble = false;
        private float _cachedTime;

        public BundleRef(string pBundleName, IBundleCollector collector, int depCount = 0)
        {
            _assetRefList = new LinkedList<BundleAssetRef>();
            _bundleName = pBundleName;
            _assetBundle = null;
            _refcount = 0;
            if (depCount == 0)
            {
                _depBundleList = null;
            }
            else
            {
                _depBundleList = new List<IBundleRef>(depCount);
            }
            _collector = collector;
            collector.OnRefCountToZero(this);
            _isUnloadble = AssetBundleUtils.IsUnloadbleBundle(pBundleName);
        }

        public BundleRef(string pBundleName, AssetBundle pAssetBundle, IBundleCollector collector, int depCount = 0)
        {
            Debug.Assert(pAssetBundle != null);
            _assetRefList = new LinkedList<BundleAssetRef>();
            _bundleName = pBundleName;
            _assetBundle = pAssetBundle;
            _refcount = 0;
            if (depCount == 0)
            {
                _depBundleList = null;
            }
            else
            {
                _depBundleList = new List<IBundleRef>(depCount);
            }
            _collector = collector;
            collector.OnRefCountToZero(this);
        }

        public void AddDepBundle(IBundleRef bundleRef)
        {
            bundleRef.Retain();
            _depBundleList.Add(bundleRef);
        }

        public string BundleName { get { return _bundleName; } }

        public void Retain()
        {
            Interlocked.Increment(ref _refcount);
            //Debug.Log("[" + bundleName + "  " + refcount + "]");
        }

        public void Release(BundleAssetRef assetRef)
        {
            Interlocked.Decrement(ref _refcount);
            //Debug.Log("Release bundle [" + _bundleName + "  " + _refcount + "]");
            if (_refcount == 0 || (assetRef != null && assetRef.RefCount == 0))
            {
                _collector.OnRefCountToZero(this);
            }
            if (_refcount < 0)
            {
                Debug.LogWarning("Please check, assetRef.Retain() and Release() don't match!");
            }
        }

        public int RefCount { get { return _refcount; } }
        public LinkedList<BundleAssetRef> AssetRefList { get { return _assetRefList; } }

        public bool IsDelayRelease { get { return _isDelayRelease; } set { _isDelayRelease = value; } }
        public void SetAssetBundle(AssetBundle bundle)
        {
            _assetBundle = bundle;
            if(bundle == null)
            {
                Debug.LogError("Bundle load failed : " + _bundleName);
            }
        }

        public void LoadAssetRef(ref BundleAssetRef bundleAssetRef, string assetPath, string assetName, Type type)
        {
            try
            {
                _assetRefList.AddLast(bundleAssetRef);
                if (_assetBundle != null)
                {
                    UnityEngine.Object assetObject = _assetBundle.LoadAsset(assetName, type);
                    if (assetObject == null)
                    {
                        Debug.LogError("BundleRef " + _bundleName + " not contains asset: " + assetName);
                    }

                    bundleAssetRef.AssetObject = assetObject;
                    if (_isUnloadble)
                    {
                        _assetBundle.Unload(false);
                        _assetBundle = null;
                        //Debug.Log("Bundle Unload(false) : " + _bundleName);
                    }
                }
                else
                {
                    Debug.LogError("Load asset \"" + assetPath + "\" failed: bundle load failed");
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogException(ex);
                Debug.LogError("Load asset \"" + assetPath + "\" failed.");
            }
        }

        public AssetBundleRequest LoadAssetAsync(string assetName, Type type)
        {
            AssetBundleRequest request = null;
            try
            {
                if(_assetBundle != null)
                {
                    request = _assetBundle.LoadAssetAsync(assetName, type);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
                Debug.LogError("Load asset \"" + assetName + "\" failed.");
            }
            return request;
        }

        public void AddBundleAssetRef(BundleAssetRef bundleAssetRef)
        {
            Debug.Assert(bundleAssetRef.BundleName == this._bundleName);
            _assetRefList.AddLast(bundleAssetRef);
            if (_isUnloadble && _assetBundle != null)
            {
                _assetBundle.Unload(false);
                _assetBundle = null;
                //Debug.Log("Bundle Unload(false) : " + _bundleName);
                //AssetsLogger.Log("unload(false) bundle", this.BundleName, ":", bundleAssetRef.AssetPath);
            }
        }

        public void UnloadBundle(bool unloadAllLoadedObjects = true)
        {
            if (_assetBundle != null)
            {
                _assetBundle.Unload(unloadAllLoadedObjects);
                _assetBundle = null;
                AssetsLogger.Log("UnloadBundle", _bundleName);
            }
            else
            {
                LinkedListNode<BundleAssetRef> assetNode = _assetRefList.First;
                while (assetNode != null)
                {
                    var assetRef = assetNode.Value;
                    if (assetRef.IsUnloadable())
                    {
                        Resources.UnloadAsset(assetRef.AssetObject);
                        //AssetsLogger.Log("UnloadAsset [", assetRef.AssetPath, "]");
                    }
                    assetNode = assetNode.Next;
                }
            }
            _assetRefList.Clear();
            if (_refcount != 0)
            {
                Debug.LogWarning("BundleRef :" + _bundleName + " UnloadBundle refcount not zero but " + _refcount);
            }
            if (_depBundleList != null)
            {
                for (int i = 0; i < _depBundleList.Count; i++)
                {
                    _depBundleList[i].Release(null);
                }
                _depBundleList.Clear();
            }
        }

        public int TryUnloadAsset(Dictionary<string, BundleAssetRef> cachedAssetDict, int maxCount)
        {
            int count = 0;
            LinkedListNode<BundleAssetRef> assetNode = _assetRefList.First;
            bool beDepended = IsBeDepended();
            while (assetNode != null)
            {
                var next = assetNode.Next;
                var assetRef = assetNode.Value;
                if (assetRef.RefCount <= 0)
                {
                    if (assetRef.IsUnloadable() && !beDepended)
                    {
                        Resources.UnloadAsset(assetRef.AssetObject);
                        AssetsLogger.Log("TryUnloadAsset [", assetRef.AssetPath, "]");
                    }
                    _assetRefList.Remove(assetNode);
                    assetRef.AssetObject = null;
                    cachedAssetDict.Remove(assetRef.AssetPath);
                    count++;
                }

                assetNode = next;
                if (maxCount > 0 && count >= maxCount)
                {
                    break;
                }
            }
            return count;
        }

        private bool IsBeDepended()
        {
            return true;
            LinkedListNode<BundleAssetRef> assetNode = _assetRefList.First;
            int assetRefCount = 0;
            while (assetNode != null)
            {
                if (assetNode.Value.RefCount > 0)
                    assetRefCount++;

                assetNode = assetNode.Next;
            }
            return assetRefCount < this.RefCount;
        }

        public bool IsBundleUnloaded()
        {
            return _assetBundle == null;
        }

        public float CachedTime
        {
            get { return _cachedTime; }
            set { _cachedTime = value; }
        }
    }
}