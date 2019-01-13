using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalDamage : MonoBehaviour {

    // Declaring variables.
    public int damage = 1;

    public float resetTime = 0.25f;

    public static bool isCompletingPuzzle = true;

    // When the player is in the damage zone,
    // they take damage.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerMovement.isSpinning == false)
        {
            isCompletingPuzzle = false;
            GetComponent<Collider2D>().enabled = false;
            collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);  
            Invoke("ResetTrigger", resetTime);  
        }

    }

    // This is only allowed to happen every so often.
    private void ResetTrigger()
    {
        GetComponent<Collider2D>().enabled = true;
    }

}
