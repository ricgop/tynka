using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    float speed;

	// Use this for initialization
	void Start () {
        speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {

        // Get bullet's current position
        Vector2 position = transform.position;

        // Compute bullet's new position
        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        // Update bullet's position
        transform.position = position;

        // Set to top right corner of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        // Destroy bullet
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	
	}
}
