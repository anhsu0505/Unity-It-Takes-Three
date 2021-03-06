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

    private HealthController healthController;

    public LivesDisplay livesDisplay;

    //sounds
    private SoundsPlayer soundsPlayerCode;


    void Start()
    {
        timer = FindObjectOfType<Timer>();
        healthController = GetComponent<HealthController>();
        soundsPlayerCode = FindObjectOfType<SoundsPlayer>();
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

            //Destroy the collectible 
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
                    //play sound
                    soundsPlayerCode.PlayInvincibleSound();
                    break;

                // If player picks up time collectible
                case PowerUpType.AddTime:
                    // Player gets an extra 5 seconds
                    timer.timeValue += 5;
                    // Reset current power up to none
                    currentPowerUp = PowerUpType.None;
                    //play sound
                    soundsPlayerCode.PlayHealSound();
                    break;

                // If player picks up score collectible
                case PowerUpType.AddScore:
                    Debug.Log("Get 1 score.");
                    // Reset current power up to none
                    currentPowerUp = PowerUpType.None;
                    ScoreBoard.instance.DisplayScore();
                    //play sound
                    soundsPlayerCode.PlayScoreSound();
                    break;

                // If player picks up life collectible
                case PowerUpType.AddLife:
                    Debug.Log("Get 1 extra life if player has less than 3 lives.");
                    if (healthController.currentLives < 3 && healthController.currentLives > 0)
                    {
                        healthController.currentLives++;
                        // Update lives bar display
                        livesDisplay.UpdateLivesDisplay();
                    }
                    // Reset current power up to none
                    currentPowerUp = PowerUpType.None;
                    //play sound
                    soundsPlayerCode.PlayHealSound();
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
