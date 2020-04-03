/****************************************************
    文件：LoadingWnd.cs
	作者：ryh
    邮箱: 2311790787@qq.com
    日期：2020/2/25 10:8:15
	功能：加载窗口
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoadingWnd : WindowRoot
{
    public Image ImgLoading;
    public Image ImgPoint;
    public Text TxtTips;
    public Text TxtPercent;
    public float loadingWidth;
    protected override void Init()
    {
        base.Init();
        ImgLoading.fillAmount = 0;
        TxtTips.text = "这里出现随机的tips";
        TxtPercent.text = "0%";
        loadingWidth = ImgLoading.GetComponent<RectTransform>().rect.width;
        ImgPoint.transform.localPosition = new Vector3(-loadingWidth / 2, 0, 0);

    }
    public void SetProgress(float value)
    {
        ImgLoading.fillAmount = value;
        ImgPoint.transform.localPosition = new Vector3(-loadingWidth / 2 + loadingWidth * value, 0, 0);
        TxtPercent.text = value*100 + "%";
    }
}
