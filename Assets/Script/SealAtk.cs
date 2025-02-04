using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SealAtk : MonoBehaviour
{
    public Button atkBtn;
    public GameObject seala;
    public GameObject sealb;
    public CanvasGroup sealACanvasGroup;
    public CanvasGroup sealBCanvasGroup;
    public float groundYPosition = 2.5f;

    void Start()
    {
        atkBtn.onClick.AddListener(PlayAtk);
        seala.SetActive(false);
        sealb.SetActive(false);
    }

    private void PlayAtk()
    {   
        seala.SetActive(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(seala.transform.DOMove(new Vector3(0f, groundYPosition, 0), 3f)
            .SetEase(Ease.Linear));
        sequence.AppendCallback(() =>
        {
            sealACanvasGroup.DOFade(0f, 0.5f).OnComplete(() => 
            {
                seala.SetActive(false);
            });
            sealb.SetActive(true);
            sealb.transform.localScale = Vector3.zero;
            sealb.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f)
                .SetEase(Ease.OutBack);
            sequence.AppendInterval(2f); // 等待2秒
            sequence.Append(sealBCanvasGroup.DOFade(0f, 1.0f).OnComplete(() => 
            {
                sealb.SetActive(false);
            }));
        });
        
    }
    void Update()
    {
        
    }
}