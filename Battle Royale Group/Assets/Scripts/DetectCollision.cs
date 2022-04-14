using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject[] collectibles;
    public float dropRate;

    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && gameObject.CompareTag("Bullet") || other.CompareTag("Swan") && gameObject.CompareTag("Shoe") || other.CompareTag("Plant") && gameObject.CompareTag("fire_bullet"))
        {
            Instantiate(explosionEffect, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);

            // Determine a random drop select number
            float dropSelect = Random.Range(0, 100f);

            // If drop select is smaller than the drop rate
            if (dropSelect <= dropRate)
            {
                // Drop a collectible
                Instantiate(collectibles[Random.Range(0, 3)], other.transform.position, other.transform.rotation);
            }
        }

        /*
        if (other.CompareTag("Swan") && gameObject.CompareTag("Shoe"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Plant") && gameObject.CompareTag("fire_bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        */
    }
}
