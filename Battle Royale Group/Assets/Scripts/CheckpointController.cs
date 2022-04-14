using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    public Checkpoint[] checkPoints;

    public Vector3 spawnPoint;

    public Transform launchPos;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Find all checkpoints in the scene
        checkPoints = FindObjectsOfType<Checkpoint>();

        // Set spawn point at the beginning of the game
        spawnPoint = launchPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckpoints()
    {
        // Loop through all checkpoints and deactivate each one
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].ResetCheckPoint();
        }
    }


    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        // Set new spawn point
        spawnPoint = newSpawnPoint;
        //Debug.Log(spawnPoint);
    }
}
