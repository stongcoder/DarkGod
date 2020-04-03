/****************************************************
    文件：DynamicWnd.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/26 17:17:58
	功能：动态窗口
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot
{
    public GameObject Tips;
    private Queue<string> TipsQueue = new Queue<string>();
    private bool isTipsShowing=false;
    private void Update()
    {
        lock (TipsQueue)
        {
            if (TipsQueue.Count > 0 && !isTipsShowing)
            {
                isTipsShowing = true;
                SetTips(TipsQueue.Dequeue());
            }
        }
    }
    protected override void Init()
    {
        base.Init();
        Tips.SetActive(false);
    }
    public void AddTips(string tips)
    {
        lock (TipsQueue)
        {
           
            TipsQueue.Enqueue(tips);
        }        
    }
    private void SetTips(string tips)
    {
        Tips.SetActive(true);
        Tips.GetComponent<Text>().text = tips;
        Tips.GetComponent<Animation>().Play();
        AnimationClip clip = Tips.GetComponent<Animation>().clip;
        
        StartCoroutine(TipsShowDone(clip.length, () => 
        {
            Tips.SetActive(false);
            isTipsShowing = false;
        }));
    }
    private IEnumerator TipsShowDone(float length,Action cb)
    {
        yield return new WaitForSeconds(length);
        if (cb != null)
        {
            cb();  
        }
    }
    
}
