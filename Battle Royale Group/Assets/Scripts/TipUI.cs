using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipUI : MonoBehaviour
{
    public GameObject readMe;


    void Start()
    {
        readMe.SetActive(false);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rabbit" || other.tag == "Dancer")
        {
            Debug.Log("Player Entered");
            readMe.SetActive(true);

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Rabbit" || other.tag == "Dancer")
        {
            Debug.Log("Player Left");
            readMe.SetActive(false);

        }
    }
}