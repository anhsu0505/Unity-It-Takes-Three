using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "Score: " +score;
    }

    
     private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Rabbit" || other.tag == "Dancer" || other.tag == "Slime")
            {
                Debug.Log("Player Pickedup");
                score += 1;
                scoreText.text = "Score: " + score;
        }
        }
    


}
