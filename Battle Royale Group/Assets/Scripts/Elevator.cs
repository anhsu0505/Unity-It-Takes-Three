using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Slime_player SlimePlayerCode;
    private bool slimeOn;
    BalletController BalletCode;
    private bool balletOn;
    
    public float speed = 0.5f;
    public float distance = 5;
    private float startPos;

    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        slimeOn = false;
        balletOn = false;

        SlimePlayerCode = FindObjectOfType<Slime_player>();
        BalletCode = FindObjectOfType<BalletController>();

        //startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {


        if(SlimePlayerCode.platformCounter == true && slimeOn == false){
            slimeOn = true;
            print("Slime"+slimeOn);
        }

        if(BalletCode.platformCounter == true && balletOn == false){
            balletOn = true;
            print("Ballet"+balletOn);
        }


        if(slimeOn == true && balletOn == true){
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
        _animator.SetTrigger("Move");
        yield return new WaitForSeconds(3f);
        slimeOn = false;
        balletOn = false;
        print("Slime"+slimeOn);
        print("Ballet"+balletOn);
    }
}
