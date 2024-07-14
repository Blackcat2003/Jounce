//Best working bounce
using System.Collections;
using System.Collections.Generic;
// using UnityEngine;

// public class ContinuousBounce : MonoBehaviour
// {
//     public float bounceForce = 1f;

//     private Rigidbody rb;
//     private bool isGrounded = true;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
        
//         Bounce();
//     }

//     void Update()
//     {
//         CheckGrounded();
//     }

//     void CheckGrounded()
//     {
//         // You may need to adjust the threshold based on your scene
//         isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
//     }

//     void Bounce()
//     {
//         rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         Bounce(); // Call Bounce method on collision with any object
//     }

//     void FixedUpdate()
//     {
//         if (isGrounded)
//         {
//             rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);
//         }
//     }
// }


// using UnityEngine;

// public class ContinuousBounce : MonoBehaviour
// {
//     private float bounceForce = 2.2f;

//     private Rigidbody rb;
//     private bool isGrounded = true;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         Bounce();
//     }

//     void Update()
//     {
//         CheckGrounded();
//     }

//     void CheckGrounded()
//     {
//         isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
//     }

//     public void Bounce()
//     {
//         rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
//     }

//     public float GetBounceForce()
//     {
//         return bounceForce;
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         Bounce();
//     }

//     void FixedUpdate()
//     {
//         if (isGrounded)
//         {
//             rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);
//         }
//     }
// }

using UnityEngine;

public class ContinuousBounce : MonoBehaviour
{
    //private float bounceForce = 0.98f;
    private float bounceForce = 0.9f;

    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Bounce();
    }

    void Update()
    {
        CheckGrounded();
    }

    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    public void Bounce()
    {
        // Reset velocity to avoid unwanted effects
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // Apply an upward force for a smooth bounce
        rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

        // Set the y-velocity to ensure a consistent height
        rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(2 * bounceForce * Mathf.Abs(Physics.gravity.y)), rb.velocity.z);
    }

    public float GetBounceForce()
    {
        return bounceForce;
    }

    void OnCollisionEnter(Collision collision)
    {
        Bounce();

        //solution to problem I observed
        // if(collision.gameObject.CompareTag("blueT")||collision.gameObject.CompareTag("redT")||collision.gameObject.CompareTag("greenT")||collision.gameObject.CompareTag("redCG")||collision.gameObject.CompareTag("blueCG")||collision.gameObject.CompareTag("greenCG")) // Replace "Ground" with the tag of your ground object
        // {
        //     Bounce(); // Set the flag to true when the ball lands on the ground   
        // }

    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            // Apply a downward force to simulate gravity
            rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);
        }
    }
}


