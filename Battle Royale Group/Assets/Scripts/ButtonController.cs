using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Main";
    AudioSource _audioSource;
    public AudioClip clickSound;
    public GameObject soundMenu;

    private void Start()
    {
       _audioSource = GetComponent<AudioSource>();
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
        _audioSource.PlayOneShot(clickSound);
    }

    public void QuitGame()
    {
        Application.Quit();
        _audioSource.PlayOneShot(clickSound);
        Debug.Log("Quitting Game");
    }

    public void OpenSoundMenu()
    {
        soundMenu.SetActive(true);
        _audioSource.PlayOneShot(clickSound);
    }

    public void CloseSoundMenu()
    {
        soundMenu.SetActive(false);
        _audioSource.PlayOneShot(clickSound);
    }
}
