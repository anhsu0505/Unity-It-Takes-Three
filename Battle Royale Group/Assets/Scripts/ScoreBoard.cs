using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public float scoreValue = 0;
    public TextMeshProUGUI scoreText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rabbit" || other.tag == "Dancer" || other.tag == "Slime")
        {
            Debug.Log("Player Pickedup");
            scoreValue++;

        }
    }


}
