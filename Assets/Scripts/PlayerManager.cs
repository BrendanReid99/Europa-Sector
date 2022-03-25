using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public float currentOxygen;                         //creating some variables to enable
    public float maxOxygen = 100f;               		//an oxygen system within the player

    private const float healthDecreaseRate = 1.5f;      //oxygen decrease rates
                                                        //oxygen decrease is low due to fun, best for player to
                                                        //to feel like they are always gonna win, not lose
    void Start()
    {
        currentOxygen = maxOxygen;      //sets the player oxygen count to it's max value at the beginning of game
    }

    
    void Update()
    {
        if (currentOxygen > 0.01f) {
            currentOxygen -= healthDecreaseRate * Time.deltaTime;    //decreases player oxygen count over time
        }

        else if (currentOxygen < 50.0f && currentOxygen > 45.0f) {
            Debug.Log("Oxygen Status: Medium");
            Debug.Log("Search for O2 soon...");
        }
        else if (currentOxygen < 25.0f && currentOxygen > 20.0f) {
            Debug.Log("Oxygen Status: Low.");
            Debug.Log("Find O2 Immediately.");
        }
        else 
        {
			currentOxygen = 0.0f;

			// death handling
            gameObject.SetActive(false);
            Debug.Log("You have suffocated due to loss of oxygen.");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //resets the scene
		}
    }
}
