/*******************************************************************
* Copyright ? 2017��2021 Perfect World.Co.Ltd. All rights reserved.
* author: �ƶ���Ŀ֧�ֲ� ZEUS FRAMEWORK TEAM
********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zeus.Framework.Asset
{
    public class EditorAssetRef : IAssetRef
    {
        private UnityEngine.Object _assetObject;
        private string _name;
        private string _assetPath;
        private int _refCount;

        public EditorAssetRef(string name, string assetPath, Object assetObject)
        {
            _name = name;
            _assetPath = assetPath;
            _assetObject = assetObject;
            _refCount = 0;
        }

        /// <summary>
        /// ��Ҫ���и���Դʱ�����øú���
        /// </summary>
        public void Retain()
        {
            _refCount++;
        }

        /// <summary>
        /// ���ڳ��и���Դʱ�����øú���
        /// </summary>
        public void Release()
        {
            _refCount--;
        }

        /// <summary>
        /// ��ȡ��Դ����
        /// </summary>
        public UnityEngine.Object AssetObject
        {
            get { return _assetObject; }
        }

        /// <summary>
        /// ��Դ����
        /// </summary>
        public string AssetName { get { return _name; } }

        /// <summary>
        /// ��Դ·��
        /// </summary>
        public string AssetPath { get { return _assetPath; } }

        public int RefCount { get { return _refCount; } }
    }
}

