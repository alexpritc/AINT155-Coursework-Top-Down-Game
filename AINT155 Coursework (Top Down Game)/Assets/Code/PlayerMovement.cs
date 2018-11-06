using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    // Declaring Variables.
    public float speed;

    // Called every frame.
    void Update()
    {
        {
            Movement();
        }
    }

    // When the player presses W the character will move in an upward 
    // direction. When the player presses S the character will move 
    // in an downward direction. When the player presses A the 
    // character will move in an leftward direction. When the 
    // player presses D the character will move in an rightward 
    // direction. 

    void Movement()
    {
        Vector3 position = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            Debug.Assert(transform.position == position + (Vector3.up * speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            Debug.Assert(transform.position == position + (Vector3.down * speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            Debug.Assert(transform.position == position + (Vector3.left * speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Debug.Assert(transform.position == position + (Vector3.right * speed * Time.deltaTime));
        }
    }
}
