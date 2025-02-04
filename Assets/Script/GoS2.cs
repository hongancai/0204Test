using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GoS2 : MonoBehaviour
{
    public Button goS2;
    public Image blackScreen;
    void Start()
    {
        goS2.onClick.AddListener(Gos2click);
        blackScreen.gameObject.SetActive(false);
    }

     void Update()
    {
        
    }

    private void Gos2click()
    {
        // 顯示黑幕
        blackScreen.gameObject.SetActive(true);
        
        // 建立序列動畫
        Sequence sequence = DOTween.Sequence();
        
        // 黑幕從透明慢慢變成不透明（淡入）
        sequence.Append(blackScreen.DOFade(3f, 3f).SetEase(Ease.InOutSine));
        
        // 淡入完成後切換場景
        sequence.OnComplete(() => 
        {
            SceneManager.LoadScene("S2");
        });
    }
}



