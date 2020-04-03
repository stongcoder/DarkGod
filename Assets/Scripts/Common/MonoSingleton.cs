/****************************************************
	文件：MonoSingleton.cs
	作者：ryh
	邮箱: 2311790787@qq.com
	日期：2020/02/25 9:22   	
	功能：单例模式基类
*****************************************************/
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour
    where T: MonoSingleton<T>
{
    public static T Instance { get; private set; }

    protected void Awake()
    {
        Instance = (T)this;
    }
}
