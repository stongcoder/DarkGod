/****************************************************
    文件：AudioSvc.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/25 16:8:23
	功能：音效服务
*****************************************************/

using UnityEngine;

public class AudioSvc : MonoSingleton<AudioSvc>
{
    public AudioSource BGAudio;
    public AudioSource UIAudio;
    public void Init()
    {
        PECommon.Log("AudioSvc初始化");
    }
    public void PlayBGM(string name,bool isLoop = true)
    {
        AudioClip au = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
        if (BGAudio.clip == null || BGAudio.clip.name != au.name)
        {
            BGAudio.clip = au;
            BGAudio.loop = isLoop;
            BGAudio.Play();
        }
    }
    public void PlayUIAudio(string name)
    {
        AudioClip au = ResSvc.Instance.LoadAudio("ResAudio" + name, true);
        UIAudio.clip = au;
        UIAudio.Play();
    }
}
