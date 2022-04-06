using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI timerText;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimeTracker();

        DisplayTime(timeValue);
    }

    private void TimeTracker()
    {
        // If there's still time left
        if (timeValue > 0)
        {
            // Countdown time
            timeValue -= Time.deltaTime;
        }
        else
        {
            // If timer reaches 0
            timeValue = 0;
            Debug.Log("Game Over!");
            gameOver.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        // Calculate minutes and seconds to display
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
