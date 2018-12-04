using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {

    // Declaring variables.
    public Dialogue dialogue;

    public GameObject stairsToNextLevel;

    public string sceneName;
    string currentDialogue;

    public float timer = 0f;

    bool hasLevel1Trigger1BeenCalled = false;
    bool hasLevel1Trigger2BeenCalled = false;
    bool hasLevel1Trigger3BeenCalled = false;


    // Called once at initialisation.
    void Start()
    {
        stairsToNextLevel.SetActive(false);
    }

    // Called once every frame.
    void Update()
    {

        DialogueSequence();
    
        timer += Time.fixedDeltaTime;
    }

    // Decides the appropriate dialogue for each
    // section of each level.
    public void DialogueSequence()
    {
        if (sceneName == "Level1")
        {
            if (hasLevel1Trigger1BeenCalled == false)
            {
                Invoke("TriggerDialogue", 1f);

                currentDialogue = "WASD";
                hasLevel1Trigger1BeenCalled = true;

            }

            // N/A says something whilst the Player is moving.
            if (timer >= 5f && currentDialogue == "WASD" && hasLevel1Trigger1BeenCalled == true)
            {
                dialogue.sentences[0] = "This is good. Keep going.";
                dialogue.sentences[1] = "Excellent.";

                Invoke("TriggerDialogue", 2f);

                currentDialogue = "Next Level";
                hasLevel1Trigger2BeenCalled = true;

            }

            // N/A says something to indicate the player
            // needs to go to the next Level.
            if (timer >= 15f && currentDialogue == "Next Level" && hasLevel1Trigger2BeenCalled == true)
            {

                dialogue.sentences[0] = "Well done, Tim. Now, I think we should talk more.";
                dialogue.sentences[1] = "Walk into the stairs to explore deeper.";

                Invoke("TriggerDialogue", 1f);

                currentDialogue = "End Of Level";
                hasLevel1Trigger3BeenCalled = true;

                if (hasLevel1Trigger3BeenCalled == true)
                {
                    stairsToNextLevel.SetActive(true);
                }

            }
        }

    }

    // Triggers dialogue.
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
