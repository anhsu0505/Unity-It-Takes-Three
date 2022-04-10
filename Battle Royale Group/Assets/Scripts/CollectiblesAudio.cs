using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesAudio : MonoBehaviour
{
    AudioSource _audioSource;
    public AudioClip collectiblesSounds;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rabbit"))
        {
            StartCoroutine(Destroy());
            _audioSource.PlayOneShot(collectiblesSounds);
        }
    }

    IEnumerator Destroy(){
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }   

     public void Play(){
        //  StartCoroutine(Destroy());
        //_audioSource.PlayOneShot(collectiblesSounds);
    }
}
