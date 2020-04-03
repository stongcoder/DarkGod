/****************************************************
    文件：DragonLoop.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/25 18:14:16
	功能：登陆飞龙动画循环
*****************************************************/

using System.Collections;
using UnityEngine;

public class DragonLoop : MonoBehaviour
{
    private Animation Ani;
    private void Start()
    {
        Ani = gameObject.GetComponent<Animation>();
        if (Ani.clip != null)
        {
            InvokeRepeating("PlayDragonAnim", 0, 20);
        }        
    }
    private void PlayDragonAnim()
    {
        if (Ani.clip != null)
        {
            Ani.Play();
        }
  
        
    }
   
}
