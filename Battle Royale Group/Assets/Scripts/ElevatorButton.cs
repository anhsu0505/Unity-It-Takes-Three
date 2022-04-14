using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    private Renderer rend;

    public bool ifMove = false;
    public GameObject elevator;

    public Transform point2;
    public Transform point1;
    public float moveSpeed;

    [SerializeField]
    private Color colorToTurnTo = Color.white;
    [SerializeField]
    private Color defaultColor = Color.white;

    AudioSource _audioSource;
    public AudioClip buttonSound;

    void Start(){
        rend = GetComponent<Renderer>();
        _audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other){
        if((other.gameObject.CompareTag("Rabbit")||other.gameObject.CompareTag("Slime")||other.gameObject.CompareTag("Dancer"))&&ifMove==false){
            ifMove = true;
            _audioSource.PlayOneShot(buttonSound);
            print("botton down, move elevator");
        }
        else{
            ifMove = false;
        }
    }

    void FixedUpdate(){
        if(ifMove == true){
            rend.material.color = colorToTurnTo;
            elevatorMoveUp();
            StartCoroutine(elevatorMoveDown());
        }
    }


    void elevatorMoveUp(){
        // print(platform.position);
        // Move from the current position to the next point
        
        elevator.transform.position = Vector2.MoveTowards(elevator.transform.position, point2.position, moveSpeed * Time.deltaTime);
    }

    IEnumerator elevatorMoveDown(){
        yield return new WaitForSeconds(10);
        // print("point1="+point1.position);
        // print("elevator="+elevator.transform.position);
        ifMove = false;
        rend.material.color = defaultColor;
        // Move from the current position to the next point
        elevator.transform.position = Vector2.MoveTowards(elevator.transform.position, point1.position, moveSpeed * Time.deltaTime);
    }

}
