using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public GameObject elevator;
    public float distance;

    public List<Transform> points;
    public float moveSpeed;
    public int currentPoint;

    public bool slimeOn;
    public bool dancerOn;
    public bool rabbitOn;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (elevator.transform.position.x, elevator.transform.position.y+distance);
        if( slimeOn==true && dancerOn == true ){
            elevator2();
        }

    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Slime")){
            slimeOn = true;
        }
        if(other.gameObject.CompareTag("Dancer")){
            dancerOn = true;
        }
    }



    void elevator2(){
        // print(platform.position);
        // Move from the current position to the next point
        elevator.transform.position = Vector2.MoveTowards(elevator.transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
    }
}
