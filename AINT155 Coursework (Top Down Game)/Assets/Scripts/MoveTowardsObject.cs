using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    // Declaring variables.
    public Transform target;
    public float speed = 0.2f;



    // Called once every frame.
    private void Update()
    {
        if (target != null)
        {
            Vector3 position = transform.position;

            if (target.position.y > transform.position.y)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            if (target.position.y < transform.position.y)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (target.position.x > transform.position.x)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (target.position.x < transform.position.x)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }


        }
    }



    // Sets the target to follow.
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
