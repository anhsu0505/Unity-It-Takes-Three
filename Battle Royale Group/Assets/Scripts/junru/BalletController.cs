using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BalletController : MonoBehaviour
{
    int speed = 5;
    int jumpForce = 300;
    int health = 5;

    bool alive = true;
    bool hurt = false;

    //public TextMeshProUGUI lifeUI;

    public GameObject bulletPrefeb;
    private float bulletForce = 50;

    public Transform spawnPoint;


    Rigidbody2D _rigidbody;

    Animator _animator;

    public bool grounded;
    public LayerMask groundLayer;
    public Transform feetPos;



    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //lifeUI.text = "Life: " + health;
    }


    void Update()
    {
        if (!alive || hurt)
        {
            return;//exit it
        }


        float xSpeed = Input.GetAxis("Horizontal") * speed;
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
        //Mathf.Abs means when ever + or - so make sure the xspeed both applies to forward and backward

        _animator.SetBool("Hurt", hurt);


        if (xSpeed > 0 && transform.localScale.x < 0
            || xSpeed < 0 && transform.localScale.x > 0)
        //detects when facing left or right
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(new Vector2(0, jumpForce));
           
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 bulletDir = new Vector2(transform.localScale.x, 0);
            bulletDir *= bulletForce;
            GameObject newBullet = Instantiate(bulletPrefeb, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir);

            _animator.SetTrigger("shoot");
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, .5f, groundLayer);
        _animator.SetBool("grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (alive && !hurt && other.gameObject.CompareTag("Enemy"))
        {
            
            if (health > 0)
            {
                health--;
        
            }



            if (health < 1)
            {
                StartCoroutine(Die());
            }
            else
            {
                StartCoroutine(GotHurt());
            }


        }
    }
    IEnumerator GotHurt()
    {
        hurt = true;
        _animator.SetTrigger("hurt");
        // _animator.SetBool("hurt",hurt);
        _rigidbody.AddForce(new Vector2(-transform.localScale.x * 50, 50));

        yield return new WaitForSeconds(.5f);
        hurt = false;
        // _animator.SetBool("hurt",hurt);
    }

    IEnumerator Die()
    {
        _animator.SetTrigger("die");
        yield return new WaitForSeconds(0.8f);
        alive = false;
        SceneManager.LoadScene("GameOver");
    }










}