// my edits
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveRL : MonoBehaviour
{
    //public float forwardSpeed = 1.63f;
    //public float forwardSpeed = 1.90f;//perfect
    public float forwardSpeed = 1.98f;
    public ContinuousBounce continuousBounce;
    public Rigidbody rb;
    //public float maxSpeed;

    private float speed = 0.0070f;
    private Touch touch;
    
    // Set the boundaries for the road
    private float roadWidth = 4.2f;

    private float initialZPosition;


    private void FixedUpdate()
    {
        //mee below 5
        if(StartScreen.StartScreenInstance.GameState)
        {
            MoveForward();
        }
        else{
            // initialZPosition = 0.347f; // Adjust this value to your desired initial z-coordinate
            initialZPosition = 0.362f;
            transform.position = new Vector3(transform.position.x, transform.position.y, initialZPosition);
        }
        // MoveForward();
    }

    private void MoveForward()
    {
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        //me below 3 iff
        // if(StartScreen.StartScreenInstance.GameState)
        //         {
        //             Bounce();
        //         }
        Bounce();
    }

    void Bounce()
    {
        // Reset velocity to avoid unwanted backward movement
        rb.velocity = new Vector3(0f, 0f, 0f);

        // Apply an upward force for a smooth bounce using bounce force from ContinuousBounce script
        rb.AddForce(Vector3.up * continuousBounce.GetBounceForce(), ForceMode.Impulse);
    }

    void Update()
    {      
            // if(forwardSpeed<maxSpeed )
            // {
            //     // forwardSpeed += 0.05f * Time.deltaTime;
            //     forwardSpeed += 0.05f * Time.deltaTime;
            // }
        

        if (Input.touchCount > 0 )//after && && StartScreen.StartScreenInstance.GameState
        {
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                // Update x position with clamped values to stay within the road boundaries
                float minX = -roadWidth / 2f;
                float maxX = roadWidth / 2f;

//if 4 added by me
                // if(StartScreen.StartScreenInstance.GameState)
                // {
                //     float newX = Mathf.Clamp(transform.position.x + touch.deltaPosition.x * speed, minX, maxX);
                // transform.position = new Vector3(newX, transform.position.y, transform.position.z);
                // }

                float newX = Mathf.Clamp(transform.position.x + touch.deltaPosition.x * speed, minX, maxX);
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
    }
}


//working good moves extreme left/right only
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BallMoveRL : MonoBehaviour
// {
//     public float forwardSpeed = 1.63f;
//     public ContinuousBounce continuousBounce;
//     public Rigidbody rb;
//     public float maxSpeed;

//     private float speed = 0.0070f;
//     private Touch touch;
    
//     // Set the boundaries for the road
//     private float roadWidth = 4.2f;

//     private float initialZPosition;


//     private void FixedUpdate()
//     {
//         if(StartScreen.StartScreenInstance.GameState)
//         {
//             MoveForward();
//         }
//         else
//         {
//             initialZPosition = 0.362f;
//             transform.position = new Vector3(transform.position.x, transform.position.y, initialZPosition);
//         }
//     }

//     private void MoveForward()
//     {
//         Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;
//         rb.MovePosition(rb.position + forwardMove);
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         Bounce();
//     }

//     void Bounce()
//     {
//         // Reset velocity to avoid unwanted backward movement
//         rb.velocity = Vector3.zero;

//         // Apply an upward force for a smooth bounce using bounce force from ContinuousBounce script
//         rb.AddForce(Vector3.up * continuousBounce.GetBounceForce(), ForceMode.Impulse);
//     }

//     void Update()
//     {      
//         if(forwardSpeed < maxSpeed)
//         {
//             forwardSpeed += 0.045f * Time.deltaTime;
//         }

//         if (Input.touchCount > 0 )
//         {
//             touch = Input.GetTouch(0);
            
//             if (touch.phase == TouchPhase.Moved)
//             {
//                 // Calculate the distance to move based on the swipe direction
//                 float swipeDirectionX = touch.deltaPosition.x;
//                 float distanceToMove = 1.5f; // Adjust this value as needed

//                 // Update x position based on the swipe direction and the defined distance
//                 float newX = transform.position.x + (swipeDirectionX > 0 ? distanceToMove : -distanceToMove);

//                 // Clamp x position to stay within the road boundaries
//                 float minX = -roadWidth / 2f;
//                 float maxX = roadWidth / 2f;
//                 newX = Mathf.Clamp(newX, minX, maxX);

//                 transform.position = new Vector3(newX, transform.position.y, transform.position.z);
//             }
//         }
//     }
// }

//7 feb
//         if (Input.touchCount > 0)
//         {
//             touch = Input.GetTouch(0);
            
//             if (touch.phase == TouchPhase.Moved)
//             {
//                 float swipeDistance = 2f; // Define the distance to move with each swipe

//                 float minX = -roadWidth / 2f;
//                 float maxX = roadWidth / 2f;

//                 // Update current position based on swipe direction
//                 if (touch.deltaPosition.x > 0) // Swipe right
//                 {
//                     currentXPosition = Mathf.Clamp(currentXPosition + swipeDistance, minX, maxX);
//                 }
//                 else if (touch.deltaPosition.x < 0) // Swipe left
//                 {
//                     currentXPosition = Mathf.Clamp(currentXPosition - swipeDistance, minX, maxX);
//                 }

//                 // Update ball position
//                 transform.position = new Vector3(currentXPosition, transform.position.y, transform.position.z);
//             }
//    } 
