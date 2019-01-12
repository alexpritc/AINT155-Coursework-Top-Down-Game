using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {

    public static bool isTouchingColliderX = false;
    public static bool isTouchingColliderY = false;

    public static bool isTouchingPlayer = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "ColliderX")
        {
            isTouchingColliderX = true;
            isTouchingColliderY = false;
        }
        if (other.tag == "ColliderY")
        {
            isTouchingColliderY = true;
            isTouchingColliderX = false;
        }
    }

    // Stop moving when touching the enemy.
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            isTouchingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            isTouchingPlayer = false;
        }
    }
}
