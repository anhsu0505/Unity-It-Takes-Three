using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBackForth : MonoBehaviour
{
    public float speed = .5f;
    public float distance = 5;
    private float startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos.y = Mathf.SmoothStep(startPos, startPos+distance, Mathf.PingPong(Time.time *speed,1));
        transform.position = newPos;
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            other.transform.SetParent(null);
        }
    }
}
