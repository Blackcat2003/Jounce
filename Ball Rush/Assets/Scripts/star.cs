using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class star : MonoBehaviour
{
    // Start is called before the first frame update
    // public static int numberOfStars;
    
    // void Start(){
    //     numberOfStars = 0;
    // }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(100*Time.deltaTime,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            // FindObjectOfType<AudioManager>().PlaySound("star collection");
            // PlayerManager.numberOfStars += 1;
            // Debug.Log("Stars:"+PlayerManager.numberOfStars);
            // PlayerPrefs.SetInt("NumberOfStars",PlayerManager.numberOfStars);
            // PlayerPrefs.Save();
            // Destroy(gameObject);

            FindObjectOfType<AudioManager>().PlaySound("star collection");
            
            // Retrieve the existing TotalStars and add the new stars
            int totalStars = PlayerPrefs.GetInt("TotalStars", 0);
            totalStars += PlayerManager.numberOfStars;

            PlayerPrefs.SetInt("TotalStars", totalStars);
            PlayerPrefs.Save();

            PlayerManager.numberOfStars += 1; // Increment for the current session
            // Debug.Log("Total Stars: " + totalStars);

            Destroy(gameObject);
        }
    }
}
