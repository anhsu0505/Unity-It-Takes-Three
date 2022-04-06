using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorGlowEffectFollow : MonoBehaviour
{
    public GameObject elevator;
    public float distance;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (elevator.transform.position.x, elevator.transform.position.y+distance);
    }
}
