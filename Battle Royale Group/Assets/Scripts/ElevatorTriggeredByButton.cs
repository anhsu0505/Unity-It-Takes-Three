using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTriggeredByButton : MonoBehaviour
{
    ElevatorButton ElevatorButtonCode;
    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        ElevatorButtonCode = FindObjectOfType<ElevatorButton>();
    }

    void Update()
    {

        if(ElevatorButtonCode.ifMove == true){
            _animator.SetTrigger("Move");
        }
    }
}
