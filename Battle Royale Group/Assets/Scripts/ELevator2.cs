using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;

    public Transform platform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move from the current position to the next point
        platform.position = Vector2.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        // If getting close to one point
        if (Vector2.Distance(platform.position, points[currentPoint].position) < 0.05f)
        {
            // Update the current point
            currentPoint++;

            // If the current point is higher than the number of points
            if (currentPoint >= points.Length)
            {
                // Reset to 0
                currentPoint = 0;
            }
        }
    }
}