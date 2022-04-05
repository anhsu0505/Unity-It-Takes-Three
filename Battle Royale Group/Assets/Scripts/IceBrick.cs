using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBrick : MonoBehaviour
{
    Animator _animator;

    void Start(){
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("fire_bullet")){
            print("melt");
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
