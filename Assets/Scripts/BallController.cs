using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField] private float ballPower = 10f;
    private Vector2 StartPosition;
    private Vector2 EndPosition;
    private bool isSwipeActive= false;
    public bool hasThrown = false;
    Rigidbody2D rb;
    private void Start()
    {
       rb=GetComponent<Rigidbody2D>();
        rb.isKinematic=true;
        
    }

    private void Update()
    {
        if (!hasThrown) 
        {
            SwipeController();
        }
    }

    void SwipeController()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartPosition = touch.position;
                    isSwipeActive = true;
                  
                    break;

                    case TouchPhase.Ended:

                    if (isSwipeActive)
                    {
                      
                        EndPosition = touch.position;
                        Vector2 swipe = EndPosition - StartPosition;
                        rb.isKinematic = false;
                        Vector2 Move = Camera.main.ScreenToViewportPoint(EndPosition) - Camera.main.ScreenToViewportPoint(StartPosition);
                        rb.AddForce(Move * ballPower, ForceMode2D.Impulse);
                        isSwipeActive=false;

                        hasThrown = true;
                    }
                    break;
            }
        }
    }
}
