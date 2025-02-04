using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SphMgr : MonoBehaviour
{
    public GameObject spherefabs;
    public enum SphState
    {
        Idle,
        丟砲塔,
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
        followImage.gameObject.SetActive(true); ;
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
                break;
            case SphState.拖砲塔:
                ProcessDargTower();
                break;
        }
        if (currentState == SphState.丟砲塔)
        {
            // 將Image的位置設定為滑鼠位置
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

    private void ProcessDargTower()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<RoadTag>() != null)
            {
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
