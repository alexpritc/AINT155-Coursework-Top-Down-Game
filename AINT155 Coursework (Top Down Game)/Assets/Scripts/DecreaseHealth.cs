using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealth : MonoBehaviour {

    // Declaring variables.
    public static bool shouldDecreaseHealth = false;

    public AudioSource audioSource;

    public AudioClip audioClip;


    // When the attached GameObject collides with the Player...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldDecreaseHealth = true;
            audioSource.PlayOneShot(audioClip, 0.5F);
        }

        Invoke("Destroy", 2f);
    }

    // Destroys gameObject.
    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
