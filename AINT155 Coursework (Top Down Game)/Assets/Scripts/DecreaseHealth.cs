using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealth : MonoBehaviour {

    public static bool shouldDecreaseHealth = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldDecreaseHealth = true;
        }

        gameObject.SetActive(false);
    }
}
