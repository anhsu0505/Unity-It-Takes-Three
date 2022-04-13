using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad = "";

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
        LoadNewScene();
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

    private void LoadNewScene()
    {
        // Check if all players are at the portal
        if (slimeDetected == true && dancerDetected == true && rabbitDetected == true)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
