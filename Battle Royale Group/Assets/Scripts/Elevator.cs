using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    ElevatorTrigger ElevatorTriggerCode;
    BalletController BalletCode;
    private bool balletOn;

    public List<Transform> points;
    public float moveSpeed;
    public int currentPoint;

    public Transform platform;


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
            elevator2();
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

    void elevator2(){
        print(platform.position);
        // Move from the current position to the next point
        platform.position = Vector2.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        transform.position = platform.position;

        //If getting close to one point
        // if (Vector2.Distance(platform.position, points[currentPoint].position) < 0.05f)
        // {
        //     Update the current point
        //     currentPoint++;

        //     If the current point is higher than the number of points
        //     if (currentPoint >= points.Length)
        //     {
        //         Reset to 0
        //         currentPoint = 0;
        //     }
        // }
    }
}
