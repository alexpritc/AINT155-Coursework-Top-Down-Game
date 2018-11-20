using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    public Transform target;
    public float speed = 0.2f;

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

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

}
