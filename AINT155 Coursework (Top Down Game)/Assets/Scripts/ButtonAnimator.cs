using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour {

    // Declaring variables.
    Animator button;



    // Use this for initialization
    void Start () {

        button = GetComponent<Animator>();
        button.SetBool("isSelected", false);

	}



    // When the mouse is deselected.
    public void OnEnter()
    {
        button.SetBool("isSelected", true);
    }

    // When the button is deselected.
    public void OnExit()
    {
        button.SetBool("isSelected", false);
    }
    
}
