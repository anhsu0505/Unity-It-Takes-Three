using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrans : MonoBehaviour
{
    public GameObject icePlatform;

    //add sound
    SoundsPlayer soundsPlayerCode;

    void Start(){
        soundsPlayerCode = FindObjectOfType<SoundsPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("ice_bullet")){
            soundsPlayerCode.PlayWaterSound();
            Destroy(other.gameObject);
            gameObject.SetActive(false);
            icePlatform.gameObject.SetActive(true);

        }
    }

}
