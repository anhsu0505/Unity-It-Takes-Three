using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer checkPointSR;
    public Sprite cpOn, cpOff;

    private bool dancerDetected = false;
    private bool slimeDetected = false;
    private bool rabbitDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all players are at the checkpoint
        if (slimeDetected == true && dancerDetected == true && rabbitDetected == true)
        {
            // Deactivate all checkpoints
            CheckpointController.instance.DeactivateCheckpoints();
            // Activate the new checkpoint
            checkPointSR.sprite = cpOn;
            // Set new spawn point to most recent checkpoint
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slime"))
        {
            slimeDetected = true;
        }

        if (other.CompareTag("Dancer"))
        {
            dancerDetected = true;
        }

        if (other.CompareTag("Rabbit"))
        {
            rabbitDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Slime"))
        {
            slimeDetected = false;
        }

        if (other.CompareTag("Dancer"))
        {
            dancerDetected = false;
        }

        if (other.CompareTag("Rabbit"))
        {
            rabbitDetected = false;
        }
    }


    public void ResetCheckPoint()
    {
        checkPointSR.sprite = cpOff;
    }
}
