using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Main";
    AudioSource _audioSource;
    public AudioClip clickSound;


    private void Start()
    {
       _audioSource = GetComponent<AudioSource>();
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
        _audioSource.PlayOneShot(clickSound);
    }
}
