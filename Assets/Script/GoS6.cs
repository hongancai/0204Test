using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoS6 : MonoBehaviour
{
    public Button goS6Btn;
    
    void Start()
    {
        goS6Btn.onClick.AddListener(OnGoS6Click);
    }

    private void OnGoS6Click()
    {
        SceneManager.LoadScene("S6");
    }


    void Update()
    {
        
    }
}
