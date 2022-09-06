/*******************************************************************
* Copyright ? 2017��2021 Perfect World.Co.Ltd. All rights reserved.
* author: �ƶ���Ŀ֧�ֲ� ZEUS FRAMEWORK TEAM
********************************************************************/
using System;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Zeus.Framework.Asset
{
    public class BundleDependenciesCheckWindow : EditorWindow
    {
        [MenuItem("Zeus/Asset/Bundle Dependencies Check", false, 9)]
        static public void Open()
        {
            window = GetWindow<BundleDependenciesCheckWindow>(false, "Bundle Dependencies Check");
            AssetBundleUtils.ReInit();
        }

        static public BundleDependenciesCheckWindow window;

        private BundleDependenciesCheck_All allCheckUI = new BundleDependenciesCheck_All();
        private BundleDependenciesCheck_Filter filterCheckUI = new BundleDependenciesCheck_Filter();
        private BundleDependenciesCheck_Specify specifyCheckUI = new BundleDependenciesCheck_Specify();

        int tab = 0;
        int lastTab = -1;
        string[] tabs = new string[] {"���ȫ��Bundle","ɸѡBundle","�鿴����Bundle"}; 

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            tab = GUILayout.Toolbar(tab,tabs);
            GUILayout.EndHorizontal();

            switch (tab)
            {
                case 0:
                    if (lastTab != tab)
                        allCheckUI.PreProcess();
                    allCheckUI.Display();
                    break;
                case 1:
                    filterCheckUI.Display();
                    break;
                case 2:
                    specifyCheckUI.Display();
                    break;
                default:
                    break;
            }

            lastTab = tab;
        }
    }

    public class BundleDependenciesCheckUI
    {
        public List<BundleDependencyInfo> bundleDependencyInfoList = new List<BundleDependencyInfo>();
        Vector2 scrollPos = new Vector2(0, 100);

        public void Display()
        {
            DisplayOptions();
            DisplayResult();
        }

        public virtual void DisplayOptions()
        {
            bundleDependencyInfoList.Clear();
        }

        int currentPage;
        int wantedPage;
        int ItemCountPerPage = 100;

        public virtual void DisplayResult()
        {
            int lastPage = Mathf.CeilToInt(bundleDependencyInfoList.Count / (ItemCountPerPage * 1.0f)) - 1;

            currentPage = Mathf.Clamp(currentPage, 0, lastPage);

            //scroll view �߶�Ӧ�ü�ȥͷ��ui�߶�
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(BundleDependenciesCheckWindow.window.position.width - 40), GUILayout.Height(BundleDependenciesCheckWindow.window.position.height - 120));

            if(bundleDependencyInfoList == null || bundleDependencyInfoList.Count <= 0)
                EditorGUILayout.LabelField("�޽��");
            else
            {
                GUILayout.BeginVertical();

                int startIndex = ItemCountPerPage * currentPage;

                for (int i = 0; i < ItemCountPerPage; i++)
                {
                    var itemIndex = startIndex + i;
                    if(itemIndex < bundleDependencyInfoList.Count)
                    {
                        var ui = new BundleDependencyDisplayItem();
                        ui.Display(itemIndex, bundleDependencyInfoList[itemIndex]);
                    }
                }
                
                GUILayout.EndVertical();
            }

            EditorGUILayout.EndScrollView();

            if(bundleDependencyInfoList != null && bundleDependencyInfoList.Count > 0)
                DrawPageInfo(lastPage);
        }

        public void DrawPageInfo(int lastPage)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("��ҳ", GUILayout.Width(60)))
                currentPage = 0;
            if(GUILayout.Button("��һҳ",GUILayout.Width(60)))
                currentPage -= 1;
            var pageInfo = currentPage + "/" + lastPage;
            EditorGUILayout.LabelField(pageInfo,GUILayout.Width(8*pageInfo.Length));
            if(GUILayout.Button("��һҳ",GUILayout.Width(60)))
                currentPage += 1;
            if (GUILayout.Button("���һҳ", GUILayout.Width(60)))
                currentPage = lastPage;

            wantedPage = EditorGUILayout.IntField(wantedPage,GUILayout.Width(60));
            if (GUILayout.Button("Go", GUILayout.Width(30)))
                currentPage = wantedPage;
            EditorGUILayout.EndHorizontal();
        }

        public void OutPutJson(string filePath)
        {
            AllBundleDependencyInfos allInfos = new AllBundleDependencyInfos();
            foreach (var item in bundleDependencyInfoList)
                allInfos.allBundleDependencyInfos.Add(new BundleDependencyInfo_forJson(item));

            var jsonContens = UnityEngine.JsonUtility.ToJson(allInfos, true);

            System.IO.File.WriteAllText(filePath,jsonContens);
            Debug.Log("����ɹ�����鿴 " + filePath);
        }

        //todo
        public void OutPutMarkdown(string filePath)
        {

        }
    }

    public class BundleDependenciesCheck_All : BundleDependenciesCheckUI
    {
        public override void DisplayOptions()
        {
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();

            if(GUILayout.Button("���Json",GUILayout.Width(200)))
                OutPutJson(System.IO.Path.GetFullPath("BundleDependenciesCheck" + DateTime.Now.ToFileTime() +".json"));

            GUILayout.EndHorizontal();
        }

        public void PreProcess()
        {
            bundleDependencyInfoList.Clear();

            var allBundles = AssetBundleUtils.GetAllAssetBundles();

            foreach (var abName in allBundles)
            {
                int maxDepth;
                List<List<string>> cycles = null;
                List<string> allDependencies = null;

                BundleDependenciesCheck.GetBundleDependenciesInfoByDFS(abName, out allDependencies, out maxDepth, out cycles);
                var bundleDInfo = new BundleDependencyInfo();
                bundleDInfo.abName = abName;
                bundleDInfo.maxDepth = maxDepth;
                bundleDInfo.cycles = cycles;
                bundleDInfo.dependencies = allDependencies;
                bundleDependencyInfoList.Add(bundleDInfo);
            }
        }
    }

    public class BundleDependenciesCheck_Filter : BundleDependenciesCheckUI
    {
        int minMaxDepth = 0;
        bool isOnlyContainsRefCycles = false;

        public override void DisplayOptions()
        {
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("������� >=", GUILayout.Width(70));
            minMaxDepth = EditorGUILayout.IntField(minMaxDepth,GUILayout.Width(100));

            GUILayout.Space(10);
            
            isOnlyContainsRefCycles = EditorGUILayout.Toggle("��������ѭ��������Bundle", isOnlyContainsRefCycles);

            GUILayout.Space(10);
           
            if (GUILayout.Button("ɸѡ��Ŀ��Bundle����չʾ������Ϣ"))
            {
                bundleDependencyInfoList.Clear();

                var allBundles = AssetBundleUtils.GetAllAssetBundles();

                foreach (var abName in allBundles)
                {
                    int maxDepth;
                    List<List<string>> cycles = null;
                    List<string> allDependencies = null;

                    BundleDependenciesCheck.GetBundleDependenciesInfoByDFS(abName, out allDependencies, out maxDepth, out cycles);
                    if(maxDepth >= minMaxDepth)
                    {
                        if(isOnlyContainsRefCycles)
                        {
                            if(cycles != null && cycles.Count >0)
                            {
                                var bundleDInfo = new BundleDependencyInfo();
                                bundleDInfo.abName = abName;
                                bundleDInfo.maxDepth = maxDepth;
                                bundleDInfo.cycles = cycles;
                                bundleDInfo.dependencies = allDependencies;
                                bundleDependencyInfoList.Add(bundleDInfo);
                            }
                        }
                        else
                        {
                            var bundleDInfo = new BundleDependencyInfo();
                            bundleDInfo.abName = abName;
                            bundleDInfo.maxDepth = maxDepth;
                            bundleDInfo.cycles = cycles;
                            bundleDInfo.dependencies = allDependencies;
                            bundleDependencyInfoList.Add(bundleDInfo);
                        }
                    }
                }
            }

           if(GUILayout.Button("���Json",GUILayout.Width(200)))
                OutPutJson(System.IO.Path.GetFullPath("BundleDependenciesCheck" + DateTime.Now.ToFileTime() +".json"));

            GUILayout.EndHorizontal();
        }
    }

    public class BundleDependenciesCheck_Specify : BundleDependenciesCheckUI
    {
        string abName = string.Empty;
        public override void DisplayOptions()
        {
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            var allBundles = AssetBundleUtils.GetAllAssetBundles();
            GUILayout.Label("BundleName:",GUILayout.Width(100));
            abName = GUILayout.TextField(abName,GUILayout.Width(200));

            GUILayout.Space(10);
            if (GUILayout.Button("չʾָ��Bundle��������Ϣ", GUILayout.Width(200)))
            {
                bundleDependencyInfoList.Clear();

                if(!allBundles.Contains(abName))
                {
                    GUILayout.EndHorizontal();
                    EditorUtility.DisplayDialog("Error",$"{abName} ������","OK");
                    return;
                }

                int maxDepth;
                List<List<string>> cycles = null;
                List<string> allDependencies = null;

                BundleDependenciesCheck.GetBundleDependenciesInfoByDFS(abName, out allDependencies, out maxDepth, out cycles);
                var bundleDInfo = new BundleDependencyInfo();
                bundleDInfo.abName = abName;
                bundleDInfo.maxDepth = maxDepth;
                bundleDInfo.cycles = cycles;
                bundleDInfo.dependencies = allDependencies;
                bundleDependencyInfoList.Add(bundleDInfo);

            }

            if(GUILayout.Button("���Json",GUILayout.Width(200)))
                OutPutJson(System.IO.Path.GetFullPath("BundleDependenciesCheck" + DateTime.Now.ToFileTime() +".json"));

            GUILayout.EndHorizontal();
        }
    }

    public class BundleDependencyDisplayItem
    {
        public void Display(int index, BundleDependencyInfo content)
        {
            EditorGUILayout.BeginHorizontal();

            GUILayout.Label(index + ".BundleName:",GUILayout.Width(100));
            GUILayout.TextField(content.abName,GUILayout.Width(200));
            GUILayout.Space(10);

            if(content.maxDepth == 0)
                GUILayout.Label("����������bundle",GUILayout.Width(200));
            else
            {
                GUILayout.Label("����������Ϊ:",GUILayout.Width(100));
                GUILayout.TextField(content.maxDepth.ToString(),GUILayout.Width(200));
                GUILayout.Space(10);

                GUILayout.Label("������bundleΪ��", GUILayout.Width(100));
                string allDependencies = string.Empty;
                foreach (var item in content.dependencies)
                    allDependencies += (item + " ");
                GUILayout.TextField(allDependencies,GUILayout.Width(6 * allDependencies.Length));

                GUILayout.Space(10);

                if (content.cycles != null && content.cycles.Count > 0)
                {
                    GUILayout.Label("����ѭ�����ã�",GUILayout.Width(100));

                    foreach (var cycle in content.cycles)
                    {
                        var cycle_str = "��->"; 
                        foreach (var ab in cycle)
                            cycle_str += (ab + " -> ");
                        cycle_str +=  "��";

                        GUILayout.TextField(cycle_str, GUILayout.Width(cycle_str.Length * 7));
                    }
                }
            }

            EditorGUILayout.EndHorizontal();
        }
    }

    [Serializable]
    public class AllBundleDependencyInfos
    {
        [SerializeField]
        public List<BundleDependencyInfo_forJson> allBundleDependencyInfos = new List<BundleDependencyInfo_forJson>(); 
    }

    [Serializable]
    public class BundleDependencyInfo_forJson
    {
        public string abName;
        public int maxDepth;
        public List<string> dependencies;
        public List<DependencyCycle> dependencyCycles;

        public BundleDependencyInfo_forJson(BundleDependencyInfo bundleInfo)
        {
            abName = bundleInfo.abName;
            maxDepth = bundleInfo.maxDepth;
            dependencies = bundleInfo.dependencies;
            dependencyCycles = new List<DependencyCycle>();

            if (bundleInfo.cycles == null || bundleInfo.cycles.Count < 1)
                return;

            foreach (var item in bundleInfo.cycles)
            {
                var cycle = new DependencyCycle();
                cycle.nodes = item;
                dependencyCycles.Add(cycle);
            }
        }

        [Serializable]
        public class DependencyCycle
        {
            public List<string> nodes = new List<string>();
        }
    }


    [Serializable]
    public class BundleDependencyInfo
    {
        public string abName;
        public int maxDepth;
        public List<string> dependencies;
        public List<List<string>> cycles;
    }

    public static class BundleDependenciesCheck
    {
        /// <summary>
        ///����������أ���ȡ�����Ľ�����������ȣ��Լ���Сѭ�����û� 
        /// </summary>
        /// <param name="abName">bundle ����</param>
        /// <param name="allDependencies"> ��������bundle������</param>
        /// <param name="maxDepth">���������ȣ�������ѭ��������ɵ����</param>
        /// <param name="cycles">������У�ѭ�����õ����û���ʹ��list��ʾ����βָ����ף�</param>
        static public void GetBundleDependenciesInfoByDFS(string abName, out List<string> allDependencies, out int maxDepth, out List<List<string>> cycles)
        {
            var dirRefs = AssetBundleUtils.GetDirectDependencies(abName);
            maxDepth = 0;
            cycles = new List<List<string>>();
            allDependencies = new List<string>();

            Dictionary<string, string> nodesRecord = new Dictionary<string, string>();

            //û����������bundle
            if (dirRefs == null || dirRefs.Length == 0)
                return;

            //����������bundle
            foreach (var item in dirRefs)
            {
                var list = new List<string>();
                list.Add(abName);

                DepthFirstSearchHelper(item, list, nodesRecord, ref maxDepth, cycles);
            }

            allDependencies = nodesRecord.Keys.ToList();
        }

        //ֻ��⹹�ɵļ�С��
        static public void DepthFirstSearchHelper(string child_abName, List<string> depthList, Dictionary<string, string> nodeRecordTable, ref int maxDepth, List<List<string>> cycles)
        {
            //����ýڵ��Ѿ������û����ˣ�����
            //�ɱ����ظ���¼���û�
            //�����ӽڵ㿼������
            foreach (var item in cycles)
            {
                if (item.Contains(child_abName))
                    return;
            }

            //֮ǰ�������д��ڸýڵ㣬˵���л����ڣ��Ҹýڵ㲻�ü�¼
            if (depthList.Contains(child_abName))
            {
                var index = depthList.IndexOf(child_abName);
                //��¼���û�
                var cycle = depthList.GetRange(index, depthList.Count - index);
                cycles.Add(cycle);

                maxDepth = Mathf.Max(maxDepth, depthList.Count - 1);
                return;
            }

            //��¼���������е����нڵ�
            if (!nodeRecordTable.ContainsKey(child_abName))
                nodeRecordTable.Add(child_abName, child_abName);

            var list = new List<string>(depthList);
            list.Add(child_abName);

            var dirRefsOfChild = AssetBundleUtils.GetDirectDependencies(child_abName);

            //Ҷ�ӽڵ�
            if (dirRefsOfChild == null || dirRefsOfChild.Length == 0)
            {
                maxDepth = Mathf.Max(maxDepth, list.Count - 1);
                return;
            }

            //�����ӽڵ�
            foreach (var item in dirRefsOfChild)
                DepthFirstSearchHelper(item, list, nodeRecordTable, ref maxDepth, cycles);
        }
    }
}
