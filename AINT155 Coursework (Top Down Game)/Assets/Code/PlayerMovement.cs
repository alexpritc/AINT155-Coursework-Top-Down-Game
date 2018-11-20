using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    // Declaring Variables.
    public float speed;
    public bool isSpinning = false;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;


    // Called at the beginning.
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        playerAnimator.SetBool("isSpinningLeft", false);
        playerAnimator.SetBool("isSpinningRight", false);

    }

    // Called every frame.
    void Update()
    {
        // Only allow Player to move when they have no touched a maze panel.
        if (isSpinning == false)
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

    // When Player collides with GameObjects with the following tags...
    void OnTriggerEnter2D(Collider2D other)
    {
        // The player starts spinning.
        if (other.tag == "MazePanelUp")
        {
            Invoke("SpinningUp", 0.25f);
        }
        if (other.tag == "MazePanelDown")
        {
            Invoke("SpinningDown", 0.25f);
        }
        if (other.tag == "MazePanelLeft")
        {
            Invoke("SpinningLeft", 0.25f);
        }
        if (other.tag == "MazePanelRight")
        {
            Invoke("SpinningRight", 0.25f);
        }

        // The player stops spinning.
        if (other.tag == "Grate")
        {
            Invoke("StopSpinning", 0.1f);
        }


        // If the Player collides with the stairs, the timer resets.
        if (other.tag == "Stairs")
        {
            
        }
    }

    // Creates movement when the player hits a Maze Panel.
    public void SpinningUp()
    {
        isSpinning = true;
        playerRigidBody.velocity = (Vector3.up * speed);
    }
    public void SpinningDown()
    {
        isSpinning = true;
        playerRigidBody.velocity = (Vector3.down * speed);
    }
    public void SpinningLeft()
    {
        isSpinning = true;
        playerRigidBody.velocity = (Vector3.left * speed);

        playerAnimator.SetBool("isSpinningLeft", true);
    }
    public void SpinningRight()
    {
        isSpinning = true;
        playerRigidBody.velocity = (Vector3.right * speed);

        playerAnimator.SetBool("isSpinningRight", true);
    }

    // Stops the player's current velocity when they collide
    // with a Grate.
    public void StopSpinning()
    {
        isSpinning = false;
        playerRigidBody.velocity = (Vector3.zero);

        playerAnimator.SetBool("isSpinningLeft", false);
        playerAnimator.SetBool("isSpinningRight", false);
    }

    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

}
