using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Slime_player : MonoBehaviour
{
    public int playerNum = 1;
    string attackBtn;
    string jumpBtn;
    string xInputAxis;
    string attackFire;

    int speed = 5;
    int JumpForce = 600;
    int bulletForce = 100;
    int health = 6;

    bool alive = true;
    bool hurt = false;

    public TextMeshProUGUI lifeUI;

    public GameObject bulletPrefeb_ice;
    public GameObject bulletPrefeb_fire;

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

        attackBtn = "Attack"+playerNum;
        attackFire = "AttackFire";
        jumpBtn = "Jump" + playerNum;
        xInputAxis = "Horizontal" + playerNum;

        // lifeUI.text = "Life: "+health;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(!alive || hurt){
        //     return;//exit it
        // }

        //if fall down
        // if(transform.position.y<-10){
        //     alive = !alive;
        //     SceneManager.LoadScene("GameOver");
        // }

        float xSpeed = Input.GetAxis(xInputAxis)*speed;

        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
        _animator.SetFloat("speed", Mathf.Abs(xSpeed));//int use SetInteger

        if(xSpeed>0 && transform.localScale.x<0 || xSpeed<0 && transform.localScale.x>0){
            transform.localScale *= new Vector2(-1,1);
        }

        if(grounded && Input.GetButtonDown(jumpBtn)){
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,0);
            _rigidbody.AddForce(new Vector2(0, JumpForce));
            //_animator.SetFloat("yaxis",transform.position.y);
        }

        if(Input.GetButtonDown(attackBtn)){
            Vector2 bulletDir = new Vector2(transform.localScale.x,0);
            bulletDir *= bulletForce;
            bulletPrefeb_ice.transform.localScale = transform.localScale;
           GameObject newBullet = Instantiate(bulletPrefeb_ice, spawnPoint.position, Quaternion.identity);
           newBullet.GetComponent<Rigidbody2D>().AddForce(bulletDir);

           _animator.SetTrigger("shoot");
        }

        if(Input.GetButtonDown(attackFire)){
            Vector2 bulletDir_f = new Vector2(transform.localScale.x,0);
            bulletDir_f *= bulletForce;
            bulletPrefeb_fire.transform.localScale = transform.localScale;
           GameObject newBullet_f = Instantiate(bulletPrefeb_fire, spawnPoint.position, Quaternion.identity);
           newBullet_f.GetComponent<Rigidbody2D>().AddForce(bulletDir_f);

           _animator.SetTrigger("fireShoot");
        }
    }


    //grounded detective
    private void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(feetPos.position, .3f, groundLayer);
        _animator.SetBool("grounded", grounded);
    }

    // This section has been replaced by a separate health controller script
    /*
    private void OnCollisionEnter2D(Collision2D other){
        if(alive && !hurt && other.gameObject.CompareTag("Enemy")){

            // print("-------");
            // if(health>0){
            // health--;
            // lifeUI.text = "Life: "+health;
            // }

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
    */
}

