using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BalletController : MonoBehaviour
{
    //for multiplayer
    public int playerNum = 2;
    string attackBtn;
    string jumpBtn;
    string xInputAxis;

    int speed = 5;
    int jumpForce = 500;
    //int health = 5;

    //bool alive = true;
    bool hurt = false;

    //public TextMeshProUGUI lifeUI;

    public GameObject bulletPrefeb;
    private float bulletForce = 100;

    public Transform spawnPoint;


    Rigidbody2D _rigidbody;

    Animator _animator;

    public bool grounded;
    public LayerMask groundLayer;
    public Transform feetPos;

    private HealthController healthController;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //lifeUI.text = "Life: " + health;
        healthController = GetComponent<HealthController>();
        attackBtn = "Attack"+playerNum;
        jumpBtn = "Jump" + playerNum;
        xInputAxis = "Horizontal" + playerNum;
    }


    void Update()
    {
        // Only allow control if player is alive
        if (healthController.isAlive)
        {
            float xSpeed = Input.GetAxis(xInputAxis) * speed;

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

            if (grounded && Input.GetButtonDown(jumpBtn))
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(new Vector2(0, jumpForce));

            }

            if (Input.GetButtonDown(attackBtn))
            {
                Vector2 bulletDir = new Vector2(transform.localScale.x, 0);
                bulletDir *= bulletForce;
                GameObject newBullet = Instantiate(bulletPrefeb, spawnPoint.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir);

                _animator.SetTrigger("shoot");
            }
        }       
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(feetPos.position, .5f, groundLayer);
        _animator.SetBool("grounded", grounded);
    }

    // This part has been replaced with a Health Controller script
    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (alive && !hurt && other.gameObject.CompareTag("Enemy"))
        {
            
            // if (health > 0)
            // {
            //     health--;
        
            // }



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
    */










}