using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBrick : MonoBehaviour
{
    Animator _animator;

    //public GameObject readMe;



    void Start(){
        _animator = GetComponent<Animator>();

        //readMe.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("fire_bullet")){
            print("melt");
            StartCoroutine(melt());
            Destroy(other.gameObject);
        }

        if (other.tag == "Dancer" || other.tag == "Rabbit")
        {
            Debug.Log("Player Entered");
            //readMe.SetActive(true);

        }
    }

    IEnumerator melt(){
        _animator.SetTrigger("melt");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
