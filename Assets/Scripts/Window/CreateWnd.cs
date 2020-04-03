/****************************************************
    文件：CreateWnd.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/27 9:56:3
	功能：待填写
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
public class CreateWnd : WindowRoot
{
    public InputField Name;
    protected override void Init()
    {
        base.Init();
        Name.text = ResSvc.Instance.GetRDNameData();
    }
    public void OnBtnRandomClick()
    {
        Name.text = ResSvc.Instance.GetRDNameData();
    }
}
