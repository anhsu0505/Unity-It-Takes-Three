using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        // If there's no data from previous game
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            // Set volume to 50%
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        // Save volume setting
        Save();
    }

    private void Save()
    {
        // Store player's volume setting
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    private void Load()
    {
        // Load player's volume setting from previous game
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
