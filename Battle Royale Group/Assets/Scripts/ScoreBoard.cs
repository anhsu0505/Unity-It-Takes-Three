using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public static ScoreBoard instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rabbit" || other.tag == "Dancer" || other.tag == "Slime")
        {
            DisplayScore();
        }
    }

    public void DisplayScore()
    {
        Debug.Log("Player Pickedup");
        score += 1;
        scoreText.text = "Score: " + score;
    }
}
