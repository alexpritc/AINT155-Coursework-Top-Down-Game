using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorController : MonoBehaviour {
    
    // Declaring variables.
    public string currentScene;


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


}
