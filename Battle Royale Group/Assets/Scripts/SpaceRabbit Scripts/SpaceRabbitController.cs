using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceRabbitController : MonoBehaviour
{
    public int playerNum = 3;
    string attackBtn;
    string jumpBtn;
    string xInputAxis;

    public static SpaceRabbitController instance;

    public float speed = 5;

    public float jumpForce = 5.5f;

    private Rigidbody2D rabbitRb;

    private Animator rabbitAnimator;

    public bool onGround;

    public LayerMask groundLayer;

    public Transform feet;

    public bool canDoubleJump;

    public GameObject bulletPrefab;

    private float bulletForce = 50;

    public Transform bulletPos;

    public float knockBackLength;
    public float knockBackForce;
    private float knockBackCounter;

    private bool hurt;
    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rabbitRb = GetComponent<Rigidbody2D>();
        rabbitAnimator = GetComponent<Animator>();
        onGround = true;
        canDoubleJump = false;

        attackBtn = "Attack"+playerNum;
        jumpBtn = "Jump" + playerNum;
        xInputAxis = "Horizontal" + playerNum;
    }

    // Update is called once per frame
    void Update()
    {
        // Set hurt animation's trigger
        rabbitAnimator.SetBool("Hurt", hurt);

        // If knock back time is over
        if (knockBackCounter <= 0)
        {
            // Allows player to move
            hurt = false;
            MoveRabbit();
            JumpControl();
            Shoot();
        } else
        {
            // Count down knock back time
            knockBackCounter -= Time.deltaTime;
            hurt = true;   
            // Knock player back based on the direction player is facing
            if (transform.localScale.x > 0)
            {
                rabbitRb.velocity = new Vector2(-knockBackForce, rabbitRb.velocity.y);
            }
            if (transform.localScale.x < 0)
            {
                rabbitRb.velocity = new Vector2(knockBackForce, rabbitRb.velocity.y);
            }
        }
        
    }

    private void JumpControl()
    {
        // Check if player presses Space
        if (Input.GetButtonDown(jumpBtn))
            {
                // Check if player is on the ground
                if (onGround)
                {
                    Jump();
                    // Enable double jump
                    canDoubleJump = true;
                }
                // Check if player can double jump
                else if (canDoubleJump)
                {
                    Jump();
                    // Disable double jump
                    canDoubleJump = false;
                }
            }
        
    }

    private void MoveRabbit()
    {
        // Player's input
        float xSpeed = Input.GetAxis(xInputAxis) * speed;

        // Move rabbit
        rabbitRb.velocity = new Vector2(xSpeed, rabbitRb.velocity.y);

        // Set moving speed for animation
        rabbitAnimator.SetFloat("Speed", Mathf.Abs(xSpeed));

        // Flip the rabbit sprite according to its moving direction
        if (xSpeed < 0 && transform.localScale.x > 0 || xSpeed > 0 && transform.localScale.x < 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }

    private void Shoot()
    {
        // Check if player presses fire
        if (Input.GetButtonDown(attackBtn))
        {
            // The direction of the bullet
            Vector2 bulletDir = new Vector2(transform.localScale.x, 0);
            // Instantiate new bullet
            GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
            // Bullet flies
            newBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir * bulletForce, ForceMode2D.Impulse);
        }
    }

    private void Jump()
    {
        // Reset velocity before jumping
        rabbitRb.velocity = new Vector2(rabbitRb.velocity.x, 0);
        // Jump
        rabbitRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        // Check if player is standing on an object on Ground layermask
        onGround = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);

        // Set the grounded trigger for jump animation according to onGround
        rabbitAnimator.SetBool("Grounded", onGround);
    }

    public void KnockBack()
    {
        // Reset knock back time counter
        knockBackCounter = knockBackLength;
        // Reset player's position and knock player back
        rabbitRb.velocity = new Vector2(0f, knockBackForce);   
    }
}
