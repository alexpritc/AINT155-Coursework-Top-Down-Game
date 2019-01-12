using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text displayScore;

    string percentage;

	// Use this for initialization
	void Start () {

        switch (SceneController.sceneNameGameOver)
        {
            case "Level1.5":
                percentage = "10%";
                break;
            case "Level2":
                percentage = "20%";
                break;
            case "Level3":
                percentage = "30%";
                break;
        }

        displayScore.text = percentage;
    }
	
    
}
