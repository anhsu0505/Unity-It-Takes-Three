using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_lifespan : MonoBehaviour
{
    public float lifeTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        
    }

    // private void Update(){ //private means the function can't be used in another class
    //     if (transform.position.y > 5.5){
    //         Destroy(gameObject);
    //     }
    // }

}
