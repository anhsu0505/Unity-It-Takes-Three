using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip collectibleSounds_heal;
    public AudioClip collectibleSounds_score;
    public AudioClip waterTransSound;
    public AudioClip collectibleSounds_invincible;
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

    public void PlayInvincibleSound(){
        _audioSource.PlayOneShot(collectibleSounds_invincible);
    }

    public void PlayWaterSound(){
        _audioSource.PlayOneShot(waterTransSound);
    }
}
