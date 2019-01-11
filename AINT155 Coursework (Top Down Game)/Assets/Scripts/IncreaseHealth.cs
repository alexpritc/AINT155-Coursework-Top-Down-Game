using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour {

    // Declaring variables.
    public static bool shouldIncreaseHealth = false;



    // When the player collides with this, it increases the health.
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldIncreaseHealth = true;
        }
    }
}
