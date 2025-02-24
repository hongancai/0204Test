using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class OpenPnl : MonoBehaviour
{
    public GameObject shopPnl;
    public Button closeshoBtn;
    //public EscMgr escstateMachine;
    
    void Start()
    {
        shopPnl.gameObject.SetActive(false);
        closeshoBtn.onClick.AddListener(OnBtnClose);
    }

    public void OnBtnClose()
    {
        Time.timeScale = 1;
        shopPnl.gameObject.SetActive(false);
        //escstateMachine.NotifyPanelStateChanged();
    }
    

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Time.timeScale = 0;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<ShopTag>() != null)
                {
                    shopPnl.gameObject.SetActive(true);
                    //escstateMachine.NotifyPanelStateChanged();
                    Debug.Log("測試開商店");
                }
            }
        }
    }

    public bool IsShopOpen()
    {
        return shopPnl.activeSelf;
    }
}