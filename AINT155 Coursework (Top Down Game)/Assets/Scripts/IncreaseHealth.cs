using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour {

    // Declaring variables.
    public static bool shouldIncreaseHealth = false;
    public bool hasIncreasedHealth = false;

    public AudioSource audioSource;

    public AudioClip audioClip;



    // When the player collides with this, it increases the health.
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && hasIncreasedHealth == false && HealthSystem.health < 100)
        {
            shouldIncreaseHealth = true;
            hasIncreasedHealth = true;
            audioSource.PlayOneShot(audioClip, 0.75F);            
        }
    }
}
