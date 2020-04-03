/****************************************************
    文件：WindowRoot.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/25 15:0:28
	功能：窗口基类
*****************************************************/

using UnityEngine;

public class WindowRoot : MonoBehaviour
{
    public void SetWindowState(bool state = true)
    {
        if (gameObject.activeSelf != state)
        {
            gameObject.SetActive(state);
            if (state)
            {
                Init();
            }
            else
            {
                Clear();
            }
        }

    }
    protected virtual void Init()
    {

    }
    protected virtual void Clear()
    {

    }
}
