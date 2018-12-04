using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimator : MonoBehaviour {

    Animator button;

	// Use this for initialization
	void Start () {

        button = GetComponent<Animator>();
        button.SetBool("isSelected", false);

	}

    public void OnEnter()
    {
        button.SetBool("isSelected", true);
    }
    public void OnExit()
    {
        button.SetBool("isSelected", false);
    }
    
}
