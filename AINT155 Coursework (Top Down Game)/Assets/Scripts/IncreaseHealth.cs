using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour {

    public static bool shouldIncreaseHealth = false;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldIncreaseHealth = true;
        }
    }
}
