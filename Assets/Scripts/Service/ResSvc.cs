/****************************************************
    文件：ResSvc.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/24 19:11:53
	功能：资源加载服务
*****************************************************/

using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResSvc : MonoSingleton<ResSvc>
{
    private Action PrgCB = null;
    private Dictionary<string, AudioClip> AudioDic = new Dictionary<string, AudioClip>();
    public void Init()
    {
        PECommon.Log("ResSvc初始化");
        InitRDName();

    }
    public void AsyncLoadScene(string sceneName,Action loaded)
    {
       AsyncOperation sceneAsync= SceneManager.LoadSceneAsync(sceneName);
        GameRoot.Instance.loadingWnd.SetWindowState(true);
        PrgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.Instance.loadingWnd.SetProgress(val);
            if (val == 1)
            {
                if (loaded != null)
                {
                    loaded();
                }
                PrgCB = null;
                sceneAsync = null;
                GameRoot.Instance.loadingWnd.gameObject.SetActive(false);

            }
        };
    }
    private void Update()
    {
        if (PrgCB != null)
        {
            PrgCB();
        }
    }
    public AudioClip LoadAudio(string path,bool cache = false)
    {
        AudioClip au = null;
        if (!AudioDic.TryGetValue(path,out au)){
            au = Resources.Load<AudioClip>(path);
            if (cache)
            {
                AudioDic.Add(path, au);
            }           
        }
        return au;
    }
    #region InitCfgs
    private List<string> surnameList = new List<string>();
    private List<string> manNameList = new List<string>();
    private List<string> womanNameList = new List<string>();
    private void InitRDName()
    {
        TextAsset xml = Resources.Load<TextAsset>(PathDefine.RDNameCfg);
        if (!xml)
        {
            PECommon.Log(string.Format(Constants.ResSvc_1, PathDefine.RDNameCfg),LogType.Error);
        }
        else
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.text);
            XmlNodeList nodeList = doc.SelectSingleNode("root").ChildNodes;
            for (int i = 0; i < nodeList.Count; i++)
            {
                XmlElement elem = nodeList[i] as XmlElement;
                if (elem.GetAttributeNode("ID") == null)
                {
                    continue;
                }
                int ID = Convert.ToInt32(elem.GetAttributeNode("ID").InnerText);
                foreach(XmlElement e in elem.ChildNodes)
                {
                    switch (e.Name)
                    {
                        case "surname":
                            surnameList.Add(e.InnerText);
                            break;
                        case "man":
                            manNameList.Add(e.InnerText);
                            break;
                        case "woman":
                            womanNameList.Add(e.InnerText);
                            break;
                    }
                }

            }
        }
    }
    public string GetRDNameData(bool isMan = true)
    {
        string rdName = surnameList[Tools.RandomInt(0, surnameList.Count - 1)];
                
        if (isMan)
        {
            rdName += manNameList[Tools.RandomInt(0, manNameList.Count - 1)];
        }
        else
        {
            rdName += womanNameList[Tools.RandomInt(0, womanNameList.Count - 1)];
        }
        return rdName;
    }
    #endregion
}
