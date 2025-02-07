using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{
    public enum StormState
    {
        Idle,
        Atk,
        Die,
    }
    private StormState currentState;
    
    private Animator _animator;
    void Start()
    {
        
        //GameDB.towerhp = 100;
    }

    
    void Update()
    {
        switch (currentState)
        {
            case StormState.Idle:
                ProcessIdle();
                break;
            case StormState.Atk:
                ProcessAtk();
                break;
            case StormState.Die:
                ProcessDie();
                break;
        }
    }

    private void ProcessIdle()
    {
        
    }

    private void ProcessAtk()
    {
       
    }

    private void ProcessDie()
    {
        //Destroy();
    }
}
