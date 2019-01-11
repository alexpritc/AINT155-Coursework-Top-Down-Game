using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CursorController : MonoBehaviour {
    
    // Declaring variables.
    public string currentScene;

    public GameObject dialogueBox;



	// Use this for initialization.
	void Start ()
    {
        if (currentScene != "MainMenu")
        {
            // Hides the cursor in-game.
            Cursor.visible = false;
        }
        else
        {
            // Hides the cursor in-game.
            Cursor.visible = true;
        }

	}



    // Shoes the cursor.
    public void ShowCursor()
    {
        Cursor.visible = true;
    }

    // Hides the cursor.
    public void HideCursor()
    {
        Cursor.visible = false;
    }


}
