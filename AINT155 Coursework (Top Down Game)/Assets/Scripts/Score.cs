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
                percentage = "0%";
                break;
            case "Level2":
                percentage = "5%";
                break;
            case "Level3":
                percentage = "10%";
                break;
            case "Level4":
                percentage = "15%";
                break;
            case "Level5":
                percentage = "20%";
                break;
            case "Level6":
                percentage = "25%";
                break;
            case "Level7":
                percentage = "30%";
                break;
            case "Level8":
                percentage = "35%";
                break;
            case "Level9":
                percentage = "40%";
                break;
            case "Level10":
                percentage = "45%";
                break;
            case "Level11":
                percentage = "50%";
                break;
            case "Level12":
                percentage = "55%";
                break;
            case "Level13":
                percentage = "60%";
                break;
            case "Level14":
                percentage = "65%";
                break;
            case "Level15":
                percentage = "70%";
                break;
            case "Level16":
                percentage = "75%";
                break;
            case "Level17":
                percentage = "80%";
                break;
            case "Level18":
                percentage = "85%";
                break;
            case "Level19":
                percentage = "90%";
                break;
            case "Level20":
                percentage = "95%";
                break;

        }

        displayScore.text = percentage;
    }
	
    
}
