using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private bool playerDetected;

    private Animator enemyAnimator;

    public Transform bulletPos;

    private float bulletForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;

        enemyAnimator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set attack animation trigger
        enemyAnimator.SetBool("playerDetected", playerDetected);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            if (gameObject.CompareTag("Alien"))
            {
                StartCoroutine(ShootBullets(0.2f));
            }
            if (gameObject.CompareTag("Boss"))
            {
                StartCoroutine(ShootBullets(0.1f));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }

    IEnumerator ShootBullets(float spawnRate)
    {
        while (SpaceRabbitHealth.instance.isAlive && playerDetected)
        {
            yield return new WaitForSeconds(spawnRate);
            // Instantiate new bullet
            GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
            // Bullet flies
            newBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * bulletForce, ForceMode2D.Impulse);
        }        
    }
}
