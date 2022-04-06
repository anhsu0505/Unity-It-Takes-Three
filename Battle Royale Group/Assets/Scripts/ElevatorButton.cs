using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    private Renderer rend;

    public bool ifMove = false;
    public GameObject elevator;

    public Transform point;
    public float moveSpeed;

    [SerializeField]
    private Color colorToTurnTo = Color.white;

    void Start(){
        rend = GetComponent<Renderer>();
    }


    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Rabbit")||other.gameObject.CompareTag("Slime")||other.gameObject.CompareTag("Dancer")){
            ifMove = true;
        }
    }

    void FixedUpdate(){
        if(ifMove == true){
            print("botton down, move elevator");
            rend.material.color = colorToTurnTo;
            elevatorMove();
        }
    }


    void elevatorMove(){
        // print(platform.position);
        // Move from the current position to the next point
        elevator.transform.position = Vector2.MoveTowards(elevator.transform.position, point.position, moveSpeed * Time.deltaTime);
    }
}
