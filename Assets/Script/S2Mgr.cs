using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2Mgr : MonoBehaviour
{
    public GameObject prefabs;
    public GameObject shopPanel;
    void Start()
    {
    }
    
    void Update()
    {
        //防止raycast
        if (Input.GetButtonDown("Fire1"))
        {
            //防止raycast
            if (shopPanel.activeSelf)
            {
                return;
            }
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<RoadTag>() != null)
                {
                    GameObject temp = Instantiate(prefabs);
                    temp.transform.localScale = Vector3.one;
                    temp.transform.localEulerAngles = new Vector3(30, 0, 0);
                    
                    Vector3 position = hit.point;
                    position.y = 0;
                    temp.transform.localPosition = position;
                }
            }
        }
    }
    
    
 
}