using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Main";
    [SerializeField] private string tutorial1 = "Tutorial 1";
    [SerializeField] private string tutorial2 = "Tutorial 2";
    [SerializeField] private string tutorial3 = "Tutorial 3";
    [SerializeField] private string tutorial4 = "Tutorial 4";




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

    public void ShowTutorial1()
    {
        _audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(tutorial1);
    }

    public void ShowTutorial2()
    {
        _audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(tutorial2);
    }

    public void ShowTutorial3()
    {
        _audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(tutorial3);
    }

    public void ShowTutorial4()
    {
        _audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(tutorial4);
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
