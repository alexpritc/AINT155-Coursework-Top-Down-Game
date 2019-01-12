using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsObject : MonoBehaviour {

    // Declaring variables.
    public Transform target;
    public float speed = 0.2f;

    Animator enemyAnimator;
    AudioSource enemyAudioSource;

    public AudioClip enemyMoving;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 position = transform.position;

        if (CollisionDetection.isTouchingPlayer == false)
        {
            if (CollisionDetection.isTouchingColliderY == false)
            {
                MoveOnX();
            }
            else if (CollisionDetection.isTouchingColliderY == true)
            {
                MoveOnY();
            }
            
            if (enemyAudioSource.isPlaying == false)
            {
                enemyAudioSource.PlayOneShot(enemyMoving, 0.01f);
            }

        }
        else
        {
            IsIdle();
        }



    }

    // Move on the X axis.
    public void MoveOnX()
    {
        if (target.position.x < transform.position.x)
        {

            IsIdle();
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            enemyAnimator.SetBool("isLeft", true);

        }
        else if (target.position.x > transform.position.x)
        {
            IsIdle();
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            enemyAnimator.SetBool("isRight", true);

        }

    }

    // Move on the Y axis.
    public void MoveOnY()
    {
        if (target.position.y < transform.position.y)
        {
            IsIdle();
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            enemyAnimator.SetBool("isDown", true);
        }
        else if (target.position.y > transform.position.y)
        {
            IsIdle();
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            enemyAnimator.SetBool("isUp", true);
        }
        
    }


    
    // Not moving. Stop all animations.   
    public void IsIdle()
    {
        enemyAnimator.SetBool("isLeft", false);
        enemyAnimator.SetBool("isUp", false);
        enemyAnimator.SetBool("isDown", false);
        enemyAnimator.SetBool("isRight", false);
    }




    // Sets the target to follow.
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }


}
