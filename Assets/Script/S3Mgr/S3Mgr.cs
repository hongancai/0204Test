using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S3Mgr : MonoBehaviour
{
    public GameObject prefabs;

    public enum MyState
    {
        Idle,
        丟砲塔,
        拖砲塔,
    }

    private MyState currentState;
    public Button btnHero;

    private GameObject cache砲塔;


    void Start()
    {
        currentState = MyState.Idle;
        btnHero.onClick.AddListener(OnBtnHeroClick);
        
    }

    void Update()
    {
        switch (currentState)
        {
            case MyState.Idle:
                ProcessIdle();
                break;
            case MyState.丟砲塔:
                ProcessDragTower();
                break;
            case MyState.拖砲塔:
                Process拖砲塔();
                break;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2 myVector = Input.mousePosition;
            myVector.x -= 5;
            Mouse.current.WarpCursorPosition(myVector);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(btnHero.GetComponent<RectTransform>(),
                    Input.mousePosition))
            {
                OnBtnHeroClick();
            }
        }
    }

    private void OnBtnHeroClick()
    {
        currentState = MyState.丟砲塔;
        Debug.Log("開始丟喔");
    }

    /*---------------  Function  -------------------*/

    private void ProcessIdle()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name.ToLower().Contains("cube"))
                {
                    // cache 
                    cache砲塔 = hit.transform.gameObject;
                    //該狀態
                    currentState = MyState.拖砲塔;
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
                    GameObject temp = Instantiate(prefabs);
                    temp.transform.localScale = Vector3.one;
                    temp.transform.localEulerAngles = new Vector3(30, 0, 0);
                    temp.transform.localPosition = hit.point;

                    currentState = MyState.Idle; //改變狀態!!!
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
            currentState = MyState.Idle;
        }
    }
}