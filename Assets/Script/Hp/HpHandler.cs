using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpHandler : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }
    public void SetHp(float hp)
    {
        if (hp < 0.0f || hp > 1.0f)
        {
            return;
        }
        float s = (1 - hp) / 2;
        transform.localScale = new Vector3(s
            , transform.localScale.y
            , transform.localScale.z);

        transform.localPosition = new Vector3(
            s * -1
            , transform.localPosition.y
            , transform.localPosition.z);
    }
}