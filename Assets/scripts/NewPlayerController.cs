using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour
{

    // Movement vairables
    public float speed;
    public float jump;
    public float fireDelay = 2f;
    public AudioSource jumpSoundEffect;
    public AudioSource shootSoundEffect;
    public bool grounded = false;
    public bool fire = false;
    public GameObject PlayerBulletGO;
    public GameObject bulletRight;
    public GameObject bulletLeft;

    bool facingRight = true;
    float restartTimer;
    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.IsTouchingLayers(GetComponent<Collider2D>(), LayerMask.GetMask("ground"));
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("grounded", grounded);
        anim.SetBool("Fire", fire);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

        restartTimer += Time.deltaTime;
        if (restartTimer >= fireDelay) { fire = false; }
    }
    
    void Movement() {
        // Jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x, jump);

            grounded = false;
            jumpSoundEffect.Play();
        }

        // Move Right
        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                speed, GetComponent<Rigidbody2D>().velocity.y);

            // Flip Right
            if (facingRight == false)
            Flip();
            facingRight = true;
        }

        // Move Left
        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                -speed, GetComponent<Rigidbody2D>().velocity.y);

            // Flip Left
            if (facingRight == true)
            Flip();
            facingRight = false;
        }

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shootRight = (GameObject)Instantiate(PlayerBulletGO);
            shootRight.transform.position = bulletRight.transform.position;

            GameObject shootLeft = (GameObject)Instantiate(PlayerBulletGO);
            shootLeft.transform.position = bulletRight.transform.position;

            shootSoundEffect.Play();
            fire = true;
            restartTimer = 0;
        }

    }

    // Flipping method
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}