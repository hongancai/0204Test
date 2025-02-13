using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teach : MonoBehaviour
{
    public GameObject[] image;
    public Button rBtn;
    public Button lBtn;
    
    void Start()
    {
        rBtn.onClick.AddListener(OnNextPageBtn);
        lBtn.onClick.AddListener(OnPreviousPageBtn);
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
