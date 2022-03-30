using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRabbitHealth : MonoBehaviour
{
    public static SpaceRabbitHealth instance;

    public int maxHealth = 100;

    public int maxLives = 3;

    public int currentLives;

    private int currentHealth;

    public bool isAlive;

    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer rabbitSR;

    public Transform launchPos;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        currentLives = maxLives;
        currentHealth = maxHealth;
        rabbitSR = GetComponent<SpriteRenderer>();
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
                rabbitSR.color = new Color(rabbitSR.color.r, rabbitSR.color.g, rabbitSR.color.b, 1);
            }
        }

        // If player falls
        if (transform.position.y < -20 && currentLives > 0)
        {
            LoseLives();
        }

        if (currentLives <= 0)
        {
            Death();
        }
    }

    private void TakeDamage(int damage)
    {
        if (invincibleCounter <= 0)
        {
            if (isAlive && currentHealth > 0)
            {
                // Reduce player's health
                currentHealth -= damage;

                // Reset invincible counter
                invincibleCounter = invincibleLength;
                // Display invincibility - reduce player avatar's opacity
                rabbitSR.color = new Color(rabbitSR.color.r, rabbitSR.color.g, rabbitSR.color.b, 0.5f);
                // Knock player back
                SpaceRabbitController.instance.KnockBack();
            }

            if (currentHealth <= 0 && currentLives > 0)
            {
                LoseLives();
            }
        }
        
        if (currentLives <= 0)
        {
            Death();
        }
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

    private void LoseLives()
    {
        Debug.Log("Lose one life.");
        // Take away 1 life
        currentLives--;
        
        if (currentLives >= 1)
        {
            // Reset current health to max
            currentHealth = maxHealth;

            // Reset player's position
            transform.position = launchPos.position;
        }       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If player touches an enemy
        if (other.CompareTag("Enemy"))
        {
            // Take damage
            TakeDamage(3);
        }

        // If player touches an enemy
        if (other.CompareTag("Poison"))
        {
            // Take damage
            TakeDamage(1);
        }
    }

}
