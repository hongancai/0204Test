using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class PHandler : MonoBehaviour
{
    private float count;

    private IList<GameObject> MList;

    // Start is called before the first frame update
    void Start()
    {
        MList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter:{other.gameObject.name}");
    }


    private void OnTriggerStay(Collider other)
    {
        if (!MList.Contains(other.gameObject)
            && other.gameObject.name != "Plane")
        {
            MList.Add(other.gameObject);
        }

        count++;
        if (count > 100)
        {
            // Debug.Log($"OnTriggerStay:{other.gameObject.name}");
            Debug.Log($"{MList.Count}");

            var r = from q in MList
                orderby Vector3.Distance(this.transform.localPosition,
                    q.transform.localPosition) ascending 
                select q;

            if (r.Any())
            {
                GameObject first = r.First();
                Debug.Log($"NEARS :{first.name}");
            }


            // atk ... 


            MList.Clear();
            count = 0;
        }
    }
}