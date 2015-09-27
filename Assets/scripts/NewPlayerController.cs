using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour
{

    // Movement vairables
    public float speed;
    public float jump;
    public bool grounded = false;
    private Animator anim;
    bool facingRight = true;
    public bool fire = false;
    public AudioSource jumpSoundEffect;
    public AudioSource shootSoundEffect;

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
        anim.SetBool("fire", fire);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
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
            shootSoundEffect.Play();
            fire = true;
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