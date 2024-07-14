//my script working
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeJump : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Rigidbody rb;
    private float jumpForce = 2.9f;
    private bool isGrounded = true; // Add a variable to track if the ball is on the ground
    
    // just added
    // private float jumpForceMultiplier = 1.6f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SwipeCheck();
    }

    void SwipeCheck()
    {
        if (isGrounded && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeDelta = touch.position - startTouchPosition;

                // Check if the swipe is in the upward direction and the magnitude is significant
                if (swipeDelta.y > 0 && swipeDelta.magnitude > 4f && isGrounded == true)
                {
                    Jump();
                   
                }
            }
        }
    }

    void Jump()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        //working
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

        //new
        // rb.AddForce(Vector3.up * rb.velocity.magnitude * jumpForceMultiplier, ForceMode.VelocityChange);

        //my edits
        // rb.AddForce(Vector3.up * jumpForce * jumpForceMultiplier, ForceMode.VelocityChange);
        Debug.Log("Jumping");
        isGrounded = false; // Set the flag to false when jumping
        
    }

    // OnCollisionEnter is called when the ball collides with another object
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("blueT")||collision.gameObject.CompareTag("redT")||collision.gameObject.CompareTag("greenT")||collision.gameObject.CompareTag("redCG")||collision.gameObject.CompareTag("blueCG")||collision.gameObject.CompareTag("greenCG")) // Replace "Ground" with the tag of your ground object
        {
            isGrounded = true; // Set the flag to true when the ball lands on the ground   
        }
        else{
            isGrounded = false;
        }

    }
}
