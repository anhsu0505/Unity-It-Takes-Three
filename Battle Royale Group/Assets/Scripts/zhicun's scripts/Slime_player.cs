using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Slime_player : MonoBehaviour
{
    int speed = 5;
    int JumpForce = 600;
    int bulletForce = 100;
    int health = 6;

    bool alive = true;
    bool hurt = false;

    public TextMeshProUGUI lifeUI;

    public GameObject bulletPrefeb;

    public Transform spawnPoint;

    Rigidbody2D _rigidbody;
    Animator _animator;

    public bool grounded;
    public LayerMask groundLayer;
    public Transform feetPos;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        lifeUI.text = "Life: "+health;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!alive || hurt){
            return;//exit it
        }

        if(transform.position.y<-10){
            alive = !alive;
            SceneManager.LoadScene("GameOver");
        }

        float xSpeed = Input.GetAxis("Horizontal")*speed;
        float yInput = Input.GetAxis("Vertical")*4;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("speed", Mathf.Abs(xSpeed));//int use SetInteger


        //FixedUpdate
        // Vector2 yForce = new Vector2(0,yInput);
        // _rigidbody.AddForce(yForce * Time.timeScale * 200  * Time.deltaTime);
        // _animator.SetFloat("yaxis",transform.position.y);

        if(xSpeed>0 && transform.localScale.x<0 || xSpeed<0 && transform.localScale.x>0){
            transform.localScale *= new Vector2(-1,1);
        }

        if(grounded && Input.GetButtonDown("Jump")){
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,0);
            _rigidbody.AddForce(new Vector2(0, JumpForce));
            //_animator.SetFloat("yaxis",transform.position.y);
        }

        if(Input.GetButtonDown("Fire1")){
            Vector2 bulletDir = new Vector2(transform.localScale.x,0);
            bulletDir *= bulletForce;
           GameObject newBullet = Instantiate(bulletPrefeb, spawnPoint.position, Quaternion.identity);
           newBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir);

           _animator.SetTrigger("shoot");
        }
    }

    private void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(feetPos.position, .5f, groundLayer);
        _animator.SetBool("grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(alive && !hurt && other.gameObject.CompareTag("Enemy")){
            print("-------");
            if(health>0){
            health--;
            lifeUI.text = "Life: "+health;
            }
    


            if(health <1){
                StartCoroutine(Die());
            }
            else
            {
                StartCoroutine(GotHurt());     
            }


        }
    }
    IEnumerator GotHurt(){
    hurt = true;
        _animator.SetTrigger("hurt");
    // _animator.SetBool("hurt",hurt);
    _rigidbody.AddForce(new Vector2(-transform.localScale.x * 50, 50));

    yield return new WaitForSeconds(.5f);
    hurt = false;
    // _animator.SetBool("hurt",hurt);
    }

    IEnumerator Die(){
        _animator.SetTrigger("die");
        yield return new WaitForSeconds(0.8f);
        alive = false;
        SceneManager.LoadScene("GameOver");
    }
}

