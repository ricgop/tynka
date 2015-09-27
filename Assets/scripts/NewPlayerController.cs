using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour {

    // Movement vairables
    public float speed;
    public float jump;
    float moveVelocity;
    bool grounded = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x, jump);
        }

        // Move Right
        if (Input.GetKey(KeyCode.RightArrow) ||
    Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                speed, GetComponent<Rigidbody2D>().velocity.y);

        }

        // Move Left
        if (Input.GetKey(KeyCode.LeftArrow) ||
    Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                -speed, GetComponent<Rigidbody2D>().velocity.y);

        }
    }
}
