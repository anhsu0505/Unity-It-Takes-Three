using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public HealthController[] healthControllers;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthControllers = FindObjectsOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        // Disable players
        for (int i = 0; i < healthControllers.Length; i++)
        {
            healthControllers[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(waitToRespawn);

        // Reactivate players
        for (int i = 0; i < healthControllers.Length; i++)
        {
            healthControllers[i].gameObject.SetActive(true);
            healthControllers[i].gameObject.transform.position = CheckpointController.instance.spawnPoint;
        }
    }
}
