using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBrick : MonoBehaviour
{
    Animator _animator;
    AudioSource _audioSource;
    public AudioClip meltSound;


    void Start(){
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("fire_bullet")){
            print("melt");
            _audioSource.PlayOneShot(meltSound);
            StartCoroutine(melt());
            Destroy(other.gameObject);
        }
    }

    IEnumerator melt(){
        _animator.SetTrigger("melt");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
