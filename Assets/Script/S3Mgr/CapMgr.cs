using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapMgr : MonoBehaviour
{
     public GameObject caperefabs;
    public enum CapState
    {
        Idle,
        丟砲塔,
        拖砲塔,
    }
    private CapState currentState;
    public Button btnCap;

    private GameObject cache砲塔;
    void Start()
    {
        currentState = CapState.Idle;
        btnCap.onClick.AddListener(OnBtnCapClick);
    }

    private void OnBtnCapClick()
    {
        currentState = CapState.丟砲塔;
        Debug.Log("開始丟Sph喔");
    }


    void Update()
    {
        switch (currentState)
        {
            case CapState.Idle:
                ProcessIdle();
                break;
            case CapState.丟砲塔:
                ProcessDragTower();
                break;
            case CapState.拖砲塔:
                Process拖砲塔();
                break;
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
                if (hit.transform.gameObject.name.ToLower().Contains("capsule"))
                {
                    // cache 
                    cache砲塔 = hit.transform.gameObject;
                    //該狀態
                    currentState = CapState.拖砲塔;
                }
            }
        }
    }

    private void ProcessDragTower()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<RoadTag>() != null)
                {
                    GameObject temp = Instantiate(caperefabs);
                    temp.transform.localScale = Vector3.one;
                    temp.transform.localEulerAngles = new Vector3(30, 0, 0);
                    temp.transform.localPosition = hit.point;

                    currentState = CapState.Idle; //改變狀態!!!
                }
            }
        }
    }

    private void Process拖砲塔()
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
            currentState = CapState.Idle;
        }
    }
}
