using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public bool ifMove = false;
    private Renderer rend;

    [SerializeField]
    private Color colorToTurnTo = Color.white;

    void Start(){
        rend = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            ifMove = true;
        }
    }

    void FixedUpdate(){
        if(ifMove == true){
            rend.material.color = colorToTurnTo;
        }
    }
}
