using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour {

    // Delcaring variables.
    Animator timAnimator;
    bool isLeft = true;
    bool isRight = false;

    // Called at the beginning on the program.
    void Start()
    {

        timAnimator = GetComponent<Animator>();
    }

    // Called once every fame.
    void Update()
    {
        PlayAnimationMovement();
    }

    public void PlayAnimationMovement()
    {
        if (this.timAnimator.GetCurrentAnimatorStateInfo(0).IsName("Tim_Left"))
        {
            isLeft = true;
            isRight = false;
        }
        else
        { 
            isLeft = false;
            isRight = true;
        }

        PlayAnimationSpinning();       
    }

    public void PlayAnimationSpinning()
    {

        if (isLeft == true)
        {
            timAnimator.SetBool("isLeft", true);
        }
        else
        {
            timAnimator.SetBool("isRight", true);
        }

    }

}
