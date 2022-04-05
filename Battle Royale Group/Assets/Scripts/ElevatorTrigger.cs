using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    public GameObject elevator;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (elevator.transform.position.x, elevator.transform.position.y+0.7f);
    }
}
