using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Button btnsetting;
    public Button btnsettingclose;
    public GameObject settingMenu;
    
    void Start()
    {
        settingMenu.SetActive(false);
        btnsettingclose.onClick.AddListener(OnSettingClickfalse);
        btnsetting.onClick.AddListener(OnSettingClick);
    }

    private void OnSettingClick()
    {
        settingMenu.SetActive(true);
        EscMgr.Instance.OpenSettingPanel();
    }

    private void OnSettingClickfalse()
    {
        settingMenu.SetActive(false);
        EscMgr.Instance.CloseSettingPanel();
    }

    
}
