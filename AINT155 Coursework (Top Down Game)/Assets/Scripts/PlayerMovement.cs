using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Declaring events.
    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public delegate void SendLevel(int theLevel);
    public static event SendLevel OnSendLevel;

    // Declaring Variables.
    public float speed;
    public bool isSpinning = false;
    public int level = 1;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;

    HealthSystem instance;

    public AudioSource playerAudioSource;

    public AudioClip mazePanelAudioClip;
    public AudioClip grateAudioClip;
    public AudioClip stairsAudioClip;



    // Called at the beginning.
    void Start()
    {
        if (OnSendLevel != null)
        {
            OnSendLevel(level);
        }

        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        playerAudioSource = GetComponent<AudioSource>();

        playerAnimator.SetBool("isSpinningLeft", false);
        playerAnimator.SetBool("isSpinningRight", false);
        playerAnimator.SetBool("isSpinningDown", false);
        playerAnimator.SetBool("isSpinningUp", false);

        playerAnimator.SetBool("isSpinningFASTLeft", false);
        playerAnimator.SetBool("isSpinningFASTRight", false);
        playerAnimator.SetBool("isSpinningFASTDown", false);
        playerAnimator.SetBool("isSpinningFASTUp", false);

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
            playerAnimator.SetBool("isSpinningUp", true);
            playerAnimator.SetBool("isSpinningLeft", false);
            playerAnimator.SetBool("isSpinningRight", false);
            playerAnimator.SetBool("isSpinningDown", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            Debug.Assert(transform.position == position + (Vector3.down * speed * Time.deltaTime));
            playerAnimator.SetBool("isSpinningDown", true);
            playerAnimator.SetBool("isSpinningLeft", false);
            playerAnimator.SetBool("isSpinningRight", false);
            playerAnimator.SetBool("isSpinningUp", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            Debug.Assert(transform.position == position + (Vector3.left * speed * Time.deltaTime));
            playerAnimator.SetBool("isSpinningLeft", true);
            playerAnimator.SetBool("isSpinningRight", false);
            playerAnimator.SetBool("isSpinningUp", false);
            playerAnimator.SetBool("isSpinningDown", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            Debug.Assert(transform.position == position + (Vector3.right * speed * Time.deltaTime));
            playerAnimator.SetBool("isSpinningRight", true);
            playerAnimator.SetBool("isSpinningLeft", false);
            playerAnimator.SetBool("isSpinningUp", false);
            playerAnimator.SetBool("isSpinningDown", false);
        }
        else
        {
            playerAnimator.SetBool("isSpinningLeft", false);
            playerAnimator.SetBool("isSpinningRight", false);
            playerAnimator.SetBool("isSpinningUp", false);
            playerAnimator.SetBool("isSpinningDown", false);
        }
    }



    // When Player collides with GameObjects with the following tags...
    void OnTriggerEnter2D(Collider2D other)
    {
        // The player starts spinning.
        if (other.tag == "MazePanelUp")
        {
            Invoke("SpinningUp", 0.25f);
            playerAudioSource.PlayOneShot(mazePanelAudioClip, 0.25F);
        }
        if (other.tag == "MazePanelDown")
        {
            Invoke("SpinningDown", 0.25f);
            playerAudioSource.PlayOneShot(mazePanelAudioClip, 0.25F);
        }
        if (other.tag == "MazePanelLeft")
        {
            Invoke("SpinningLeft", 0.25f);
            playerAudioSource.PlayOneShot(mazePanelAudioClip, 0.25F);
        }
        if (other.tag == "MazePanelRight")
        {
            Invoke("SpinningRight", 0.25f);
            playerAudioSource.PlayOneShot(mazePanelAudioClip, 0.25F);
        }

        // The player stops spinning.
        if (other.tag == "Grate")
        {
            Invoke("StopSpinning", 0.1f);
            playerAudioSource.PlayOneShot(grateAudioClip, 0.25F);
        }


        // If the Player collides with the stairs, the timer resets.
        if (other.tag == "Stairs")
        {
            playerAudioSource.PlayOneShot(stairsAudioClip, 0.25F);
            if (OnSendLevel != null)
            {
                OnSendLevel(level);
            }
        }
    }




    // Creates movement when the player hits a Maze Panel.
    public void SpinningUp()
    {
        SetWeight();
        isSpinning = true;
        playerAnimator.SetBool("isSpinningFASTLeft", false);
        playerAnimator.SetBool("isSpinningFASTRight", false);
        playerAnimator.SetBool("isSpinningFASTDown", false);
        playerAnimator.SetBool("isSpinningFASTUp", true);
        playerRigidBody.velocity = (Vector3.up * speed);

    }
    public void SpinningDown()
    {
        SetWeight();
        isSpinning = true;
        playerAnimator.SetBool("isSpinningFASTLeft", false);
        playerAnimator.SetBool("isSpinningFASTRight", false);
        playerAnimator.SetBool("isSpinningFASTUp", false);
        playerAnimator.SetBool("isSpinningFASTDown", true);
        playerRigidBody.velocity = (Vector3.down * speed);

    }
    public void SpinningLeft()
    {
        SetWeight();
        isSpinning = true;
        playerAnimator.SetBool("isSpinningFASTRight", false);
        playerAnimator.SetBool("isSpinningFASTUp", false);
        playerAnimator.SetBool("isSpinningFASTDown", false);
        playerAnimator.SetBool("isSpinningFASTLeft", true);
        playerRigidBody.velocity = (Vector3.left * speed);

    }
    public void SpinningRight()
    {
        SetWeight();
        isSpinning = true;
        playerAnimator.SetBool("isSpinningFASTLeft", false);
        playerAnimator.SetBool("isSpinningFASTUp", false);
        playerAnimator.SetBool("isSpinningFASTDown", false);
        playerAnimator.SetBool("isSpinningFASTRight", true);
        playerRigidBody.velocity = (Vector3.right * speed);

    }

    // Stops the player's current velocity when they collide
    // with a Grate.
    public void StopSpinning()
    {
        ResetWeight();
        isSpinning = false;

        playerAnimator.SetBool("isSpinningFASTLeft", false);
        playerAnimator.SetBool("isSpinningFASTRight", false);
        playerAnimator.SetBool("isSpinningFASTUp", false);
        playerAnimator.SetBool("isSpinningFASTDown", false);
        playerRigidBody.velocity = (Vector3.zero);

        playerAudioSource.PlayOneShot(grateAudioClip, 0.25F);

    }

    // Resets the layers to their original weights.
    public void ResetWeight()
    {
        playerAnimator.SetLayerWeight(0, 1);
        playerAnimator.SetLayerWeight(1, 0);
    }

    // Changes the weights of the layers so that the currently
    // playing animation shows.
    public void SetWeight()
    {
        playerAnimator.SetLayerWeight(0, 0);
        playerAnimator.SetLayerWeight(1, 1);
    }



    // Sends the health data to the event.
    public void SendHealthData(int health)
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }

}
