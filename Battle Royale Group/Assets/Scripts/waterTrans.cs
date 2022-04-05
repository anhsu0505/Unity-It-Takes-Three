using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrans : MonoBehaviour
{
    public GameObject icePlatform;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("ice_bullet")){
            print("!!!!");
            gameObject.SetActive(false);
            Destroy(other.gameObject);
            icePlatform.gameObject.SetActive(true);
        }
    }
}
