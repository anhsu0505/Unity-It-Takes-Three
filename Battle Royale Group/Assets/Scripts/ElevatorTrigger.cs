using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public GameObject elevator;
    public float distance;

    //elevatorTrigger
    public bool slimeOn;
    public GameObject slime;
    public LayerMask platformTriggerLayer;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (elevator.transform.position.x, elevator.transform.position.y+distance);
        
        //elevatorTrigger
        slimeOn = Physics2D.OverlapCircle(slime.transform.position, .3f, platformTriggerLayer);
    }
}
