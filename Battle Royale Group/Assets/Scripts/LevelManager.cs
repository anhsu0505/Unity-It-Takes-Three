using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        // Check if any player runs out of lives
        for (int i = 0; i < healthControllers.Length; i++)
        {
            // If one player runs out of lives
            if (healthControllers[i].currentLives <= 0)
            {
                // Restart the level
                StartCoroutine(RestartLevel());
            }
            
        }
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

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(waitToRespawn);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
