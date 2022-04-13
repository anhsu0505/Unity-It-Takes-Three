using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
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
        if (other.CompareTag("Enemy") && gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

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
    }
}
