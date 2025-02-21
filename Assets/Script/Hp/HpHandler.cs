using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHandler : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 originalPosition;

    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.localPosition;
    }

    public void SetHp(float hp)
    {
        hp = Mathf.Clamp01(hp);

       
        transform.localScale = new Vector3(hp, originalScale.y, originalScale.z);

        
        float s = (originalScale.x - (originalScale.x * hp)) * 0.5f;
        Vector3 newPosition = new Vector3(
            originalPosition.x -s ,  
            originalPosition.y,
            originalPosition.z
        );

        transform.localPosition = newPosition;
    }
}