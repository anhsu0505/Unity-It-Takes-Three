using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType { None, AddTime, AddLife, AddScore, Invincibility };
public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    //add sounds
    // AudioSource _audioSource;
    // public AudioClip collectiblesSounds;

    void Start(){
        // _audioSource = GetComponent<AudioSource>();
    }

    // public void Play(){
    //     _audioSource.PlayOneShot(collectiblesSounds);
    // }
}
