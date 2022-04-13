using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip collectibleSounds_heal;
    public AudioClip collectibleSounds_score;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

     public void PlayHealSound(){
        _audioSource.PlayOneShot(collectibleSounds_heal);
    }

    public void PlayScoreSound(){
        _audioSource.PlayOneShot(collectibleSounds_score);
    }
}
