using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;

public class SphMgr : MonoBehaviour
{
    public GameObject spherefabs;
    public enum SphState
    {
        Idle,
        丟砲塔,
        Cancel,
        拖砲塔,
    }
    private SphState currentState;
    public Button btnSph;
    public GameObject followImage;
   
    private GameObject cache砲塔;
    
    void Start()
    {
        currentState = SphState.Idle;
        btnSph.onClick.AddListener(OnBtnSphClick);
    }

    private void OnBtnSphClick()
    {
        followImage.gameObject.SetActive(true); 
        currentState = SphState.丟砲塔;
        btnSph.interactable = false;
        Debug.Log("開始丟Sph喔");
    }


    void Update()
    {
        switch (currentState)
        {
            case SphState.Idle:
                ProcessIdle();
                break;
            case SphState.丟砲塔:
                ProcessPlacingTower();
                if (Input.GetMouseButtonDown(1))  // 按下右鍵
                {
                    currentState = SphState.Cancel;  // 切換到取消狀態
                }
                break;
            case SphState.Cancel:
                ProcessCancel();
                break;
            case SphState.拖砲塔:
                ProcessDargTower();
                break;
        }
        if (currentState == SphState.丟砲塔)
        {
            followImage.transform.position = Input.mousePosition;
        }
    }

    private void ProcessIdle()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name.ToLower().Contains("sphere"))
                {
                    // cache 
                    cache砲塔 = hit.transform.gameObject;
                    //該狀態
                    currentState = SphState.拖砲塔;
                }
            }
        }
    }

    private void ProcessPlacingTower()
    {
        if (Input.GetButtonDown("Fire1"))
        {   
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<RoadTag>() != null)
                {
                    GameObject temp = Instantiate(spherefabs);
                    temp.transform.localScale = Vector3.one;
                    temp.transform.localEulerAngles = new Vector3(30, 0, 0);
                    temp.transform.localPosition = hit.point;
                    followImage.gameObject.SetActive(false);
                    currentState = SphState.Idle; //改變狀態!!!
                }
            }
        }
    }

    private void ProcessCancel()
    {
        // 隱藏跟隨圖片
        followImage.gameObject.SetActive(false);
    
        // 重新啟用按鈕
        btnSph.interactable = true;
    
        // 重置狀態
        currentState = SphState.Idle;
    
        Debug.Log("取消放置");
    }

    private void ProcessDargTower()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<RoadTag>() != null)
            {
                Vector3 dragPosition = hit.point;
                dragPosition.y = 0.5f;
                cache砲塔.transform.localPosition = hit.point;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            cache砲塔 = null;
            currentState = SphState.Idle;
        }
    }
}
