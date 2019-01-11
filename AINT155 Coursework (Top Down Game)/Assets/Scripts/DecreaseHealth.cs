using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealth : MonoBehaviour {

    // Declaring variables.
    public static bool shouldDecreaseHealth = false;



    // When the attached GameObject collides with the Player...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldDecreaseHealth = true;
        }

        gameObject.SetActive(false);
    }
}
