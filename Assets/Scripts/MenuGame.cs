using UnityEngine;
using UnityEngine.UI;

public class MenuGame : UIController
{
    public void SetSfxVolume()
    {
        GameManager.Instance.setting.SfxVolume *= -1;
    }

    public void SetBgmVolume()
    {
        GameManager.Instance.setting.BgmVolume *= -1;
    }
}
