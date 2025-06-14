using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{

    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
           
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb.velocity.y < 0)
            {
                manager.AddScore(1);

               
                rb.velocity = Vector2.zero;
                rb.isKinematic = true;
                other.transform.position = manager.BallPosition;

                other.GetComponent<BallController>().hasThrown = false;
            }
        }
    }

}
