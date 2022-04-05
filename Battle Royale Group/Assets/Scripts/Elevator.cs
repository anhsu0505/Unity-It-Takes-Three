using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    ElevatorTrigger ElevatorTriggerCode;
    BalletController BalletCode;
    private bool balletOn;


    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();

        balletOn = false;

        ElevatorTriggerCode = FindObjectOfType<ElevatorTrigger>();
        BalletCode = FindObjectOfType<BalletController>();

        //startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {


        if(BalletCode.platformCounter == true && balletOn == false){
            balletOn = true;
            print("Ballet"+balletOn);
        }


        if(ElevatorTriggerCode.slimeOn == true && balletOn == true){
            StartCoroutine(moveTime());
        }
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(null);
        }
    }

    IEnumerator moveTime(){
        // Vector2 newPos = transform.position;
        // newPos.y = Mathf.SmoothStep(startPos, startPos+distance, Time.time *speed);
        // transform.position = newPos;
        _animator.SetTrigger("Move1");
        yield return new WaitForSeconds(3f);
    }
}
