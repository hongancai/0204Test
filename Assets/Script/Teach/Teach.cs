using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teach : MonoBehaviour
{
    public GameObject teachPnl;
    public GameObject[] image;
    public Button rBtn; 
    public Button lBtn;
    public Button openTeachBtn;
    public Button closeTeachBtn;
    public EscMgr escstateMachine;
    
    void Start()
    {
        if (escstateMachine == null)
        {
            Debug.Log("未設置 PanelStateMachine 引用！");
        }
        teachPnl.gameObject.SetActive(false);
        rBtn.onClick.AddListener(OnNextPageBtn);
        lBtn.onClick.AddListener(OnPreviousPageBtn);
        openTeachBtn.onClick.AddListener(OnOpenTeachtn);
        closeTeachBtn.onClick.AddListener(OnCloseTeachBtn);
    }
    
    public void OnOpenTeachtn()
    {
        teachPnl.gameObject.SetActive(true);
        Time.timeScale = 0f;
        if (escstateMachine != null)  // 添加空值檢查
        {
            escstateMachine.NotifyPanelStateChanged();
        }
    }
    public void OnCloseTeachBtn()
    {
        teachPnl.gameObject.SetActive(false);
        Time.timeScale = 1f;
        if (escstateMachine != null)  // 添加空值檢查
        {
            escstateMachine.NotifyPanelStateChanged();
        }
    }

    private void OnPreviousPageBtn()
    {
        for (int i = 0; i < image.Length; i++)
        {
            if (image[i].activeSelf)
            {
                image[i].SetActive(false);
                image[i - 1].SetActive(true);
                return;
            }
        }
    }

    private void OnNextPageBtn()
    {
        for (int i = 0; i < image.Length; i++)
        {
            if (image[i].activeSelf)
            {
                image[i].SetActive(false);
                image[i + 1].SetActive(true);
                return;
            }
        }
    }
    
    void Update()
    {
        if (image[4].activeSelf)
        {
            rBtn.gameObject.SetActive(false);
        }
        else
        {
            rBtn.gameObject.SetActive(true);
        }
        if (image[0].activeSelf)
        {
            lBtn.gameObject.SetActive(false);
        }
        else
        {
            lBtn.gameObject.SetActive(true);
        }
    }
}
