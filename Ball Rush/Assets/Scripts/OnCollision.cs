using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//shininess 0.1409572

public class OnCollision : MonoBehaviour
{

    public Score score;
    public ParticleSystem destroyParticle;

    public void Start()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "blueCG"||other.gameObject.tag == "redCG"||other.gameObject.tag == "greenCG")
        {
            
            // Material collidedMaterial = other.gameObject.GetComponent<MeshRenderer>().material;
            // // GetComponent<MeshRenderer>().material.color = collidedMaterial.color;
            // GetComponent<MeshRenderer>().material = collidedMaterial;

            // color added
            Color collidedMaterial = other.gameObject.GetComponent<MeshRenderer>().material.color;
            GetComponent<MeshRenderer>().material.color = collidedMaterial;

//me if 4
            // if(StartScreen.StartScreenInstance.GameState && StartScreen.StartScreenInstance.GameState)
            //     {
            //         score.AddScore(1);
            //     }

            score.AddScore(1);


        }
        else if (other.gameObject.tag == "blueT"||other.gameObject.tag == "greenT"||other.gameObject.tag == "redT")
        {

            //me if 4 
            if(StartScreen.StartScreenInstance.GameState && StartScreen.StartScreenInstance.GameState)
            {
                    score.AddScore(1);
            }
            //score.AddScore(1);


            Color collidedMaterial = other.gameObject.GetComponent<MeshRenderer>().material.color;
            Color myMaterial = GetComponent<MeshRenderer>().material.color;

            // Set a tolerance level for color comparison
            float colorTolerance = 0.01f;

            // Check if the color difference is greater than the tolerance
            if (ColorDifference(myMaterial, collidedMaterial) > colorTolerance)
            {
                score.AddScore(-1);
                Instantiate(destroyParticle.gameObject, transform.position, transform.rotation);
                FindObjectOfType<AudioManager>().StopSound("theme");
                FindObjectOfType<AudioManager>().PlaySound("tryover");

                if (gameObject.activeInHierarchy)
                {
                    // Destroy the game object
                    Destroy(gameObject);
                }
                
                //Debug.Log("GameOver!!");
                
                PlayerManager.isGameOver = true;

                // Save the final score before loading the game over scene
                PlayerPrefs.SetInt("FinalScore", Score.myScore);
                PlayerPrefs.Save();
                
            }
        }

        else if(other.gameObject.tag == "Ground")
        {
            Instantiate(destroyParticle.gameObject, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().StopSound("theme");
            FindObjectOfType<AudioManager>().PlaySound("tryover");

            Destroy(gameObject);
                
            PlayerManager.isGameOver = true;

                // Save the final score before loading the game over scene
                PlayerPrefs.SetInt("FinalScore", Score.myScore);
                PlayerPrefs.Save();
        }

        // Function to calculate the color difference
        float ColorDifference(Color color1, Color color2)
        {
            float diffR = Mathf.Abs(color1.r - color2.r);
            float diffG = Mathf.Abs(color1.g - color2.g);
            float diffB = Mathf.Abs(color1.b - color2.b);

            // You can adjust the weights based on your preference for each color channel
            return (diffR + diffG + diffB) / 3f;
        }
    }

}

