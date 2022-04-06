using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpController : MonoBehaviour
{
    public PowerUpType currentPowerUp = PowerUpType.None;

    public bool invinciblePowerUp = false;

    public GameObject invincibleDisplay;

    private Coroutine invincibleCounter;

    private Timer timer;


    public float scoreValue = 0;
    public TextMeshProUGUI scoreText;


    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }


    void Update()
    {
  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Check the type of collectible player picks up
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            // Destroy the collectible
            Destroy(other.gameObject);

            // Check player's current lives
            switch (currentPowerUp)
            {
                // If player picks up invincibility collectible
                case PowerUpType.Invincibility:
                    // Player is invincible
                    invinciblePowerUp = true;

                    // Show invincibility display
                    invincibleDisplay.gameObject.SetActive(true);

                    // If a previous invincibility counter is ongoing
                    if (invincibleCounter != null)
                    {
                        // Stop counter
                        StopCoroutine(invincibleCounter);
                    }

                    // Start invincible counter
                    invincibleCounter = StartCoroutine(InvincibleCounterRoutine());
                    break;

                // If player picks up time collectible
                case PowerUpType.AddTime:
                    // Player gets an extra 5 seconds
                    timer.timeValue += 5;
                    // Reset current power up to none
                    currentPowerUp = PowerUpType.None;
                    break;

                // If player picks up score collectible
                case PowerUpType.AddScore:
                    Debug.Log("Get 1 score.");
                    // Reset current power up to none
                    currentPowerUp = PowerUpType.None;
                    scoreValue++;
                    break;

                // If player picks up life collectible
                case PowerUpType.AddLife:
                    Debug.Log("Get 1 extra life if player has less than 3 lives.");
                    // Reset current power up to none
                    currentPowerUp = PowerUpType.None;
                    break;

                // Any other case
                default:
                    break;
            }
        }
    }

    IEnumerator InvincibleCounterRoutine()
    {
        yield return new WaitForSeconds(7);
        invinciblePowerUp = false;
        invincibleDisplay.gameObject.SetActive(false);
        currentPowerUp = PowerUpType.None;
    }
}
