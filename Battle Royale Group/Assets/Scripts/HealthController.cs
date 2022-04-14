using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 100;

    public int maxLives = 3;

    public int currentLives;

    private int currentHealth;

    public HealthBar healthBar;

    public LivesDisplay livesDisplay;

    public bool isAlive;

    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer playerSR;

    //public GameObject player;

    //public Transform launchPos;

    private PowerUpController powerUpController;

    private Animator _animator;

    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        currentLives = maxLives;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerSR = GetComponent<SpriteRenderer>();
        powerUpController = GetComponent<PowerUpController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is invincible
        if (invincibleCounter > 0)
        {
            // Count down invincible time
            invincibleCounter -= Time.deltaTime;

            // If player is no longer invincible
            if (invincibleCounter <= 0)
            {
                // Change player avatar back to normal
                playerSR.color = new Color(playerSR.color.r, playerSR.color.g, playerSR.color.b, 1);
            }
        }

        // If player falls
        if (transform.position.y < -20 && currentLives > 0)
        {
            LoseLives();
        }

        if (currentLives <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public void TakeDamage(int damage)
    {
        if (invincibleCounter <= 0 && powerUpController.invinciblePowerUp == false)
        {
            if (isAlive && currentHealth > 0)
            {
                if (gameObject.name == "SpaceRabbit")
                {
                    // Knock player back
                    SpaceRabbitController.instance.KnockBack();
                }
                else
                {
                    StartCoroutine(GotHurt());
                }
                // Reduce player's health
                currentHealth -= damage;
                // Set the health bar to reflect current health
                healthBar.SetHealth(currentHealth);
                // Reset invincible counter
                invincibleCounter = invincibleLength;
                // Display invincibility - reduce player avatar's opacity
                playerSR.color = new Color(playerSR.color.r, playerSR.color.g, playerSR.color.b, 0.5f);
                // If the player is space rabbit 
            }

            if (currentHealth <= 0 && currentLives > 0)
            {
                LoseLives();
            }
        }

        if (currentLives <= 0)
        {
            if (gameObject.name == "SpaceRabbit")
            {
                Death();
            }
            else
            {
                StartCoroutine(Die());
            }
        }
    }


    private void LoseLives()
    {
        Debug.Log("Lose one life.");
        // Take away 1 life
        currentLives--;

        if (currentLives >= 1)
        {
            // Reset current health to max
            currentHealth = maxHealth;
            // Set the health bar to max
            healthBar.SetHealth(currentHealth);
            // Update lives bar display
            livesDisplay.UpdateLivesDisplay();
            // Respawn player
            LevelManager.instance.RespawnPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player touches an enemy
        if (other.CompareTag("Enemy") || other.CompareTag("Swan"))
        {
            // Take damage
            TakeDamage(3);
        }

        // If player touches an enemy's poison bullet
        if (other.CompareTag("Poison"))
        {
            // Take damage
            TakeDamage(1);
        }

        // If player touches a poison plant
        if (other.CompareTag("Plant"))
        {
            // Take damage
            TakeDamage(2);
        }
    }

    IEnumerator GotHurt()
    {
        // Set Hurt animation trigger
        _animator.SetTrigger("Hurt");
        _rigidbody.AddForce(new Vector2(-transform.localScale.x * 50, 50));
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator Die()
    {
        // Set current lives to 0
        currentLives = 0;
        // Set isAlive to false
        isAlive = false;
        // Update lives bar display
        livesDisplay.UpdateLivesDisplay();
        // Set Die animation trigger
        _animator.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);
        // Remove player from scene
        gameObject.SetActive(false);
    }
    private void Death()
    {
        // Set current lives to 0
        currentLives = 0;
        isAlive = false;
        // Remove player from scene
        gameObject.SetActive(false);
        Debug.Log("Game Over.");
    }
}
