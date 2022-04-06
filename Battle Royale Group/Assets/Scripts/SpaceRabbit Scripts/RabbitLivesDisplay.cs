using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitLivesDisplay : MonoBehaviour
{
    public GameObject heart1, heart2, heart3;

    public SpaceRabbitHealth healthController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLivesDisplay()
    {
        // Check player's current lives
        switch (healthController.currentLives)
        {
            // If player has 3 lives, do nothing
            case 3:
                break;

            // If player has 2 lives, remove 1 heart
            case 2:
                heart3.SetActive(false);
                break;

            // If player has 1 lives, remove 2 hearts
            case 1:
                heart3.SetActive(false);
                heart2.SetActive(false);
                break;

            // If player has 0 lives, remove all hearts
            case 0:
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);
                break;

            // Any other case
            default:
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);
                break;
        }
    }
}
