using UnityEngine;
using System.Collections;

public class SeberKorunku : MonoBehaviour
{

//    public int pointsToAdd;
    public AudioSource korunkaSoundEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == null)
            return;

//        ScoreManager.AddPoints(pointsToAdd);
        korunkaSoundEffect.Play();
        Destroy(gameObject);
    }
}
