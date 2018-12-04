using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {

    // Declaring variables.
    public Dialogue dialogue;

    public GameObject stairsToNextLevel;

    public string sceneName, currentDialogue;

    public float timer = 0f;

    bool level1HasBeenCalled = false;


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
            if (level1HasBeenCalled == false)
            {
                TriggerDialogue();
                level1HasBeenCalled = true;

                currentDialogue = "WASD";
            }

            // N/A says something whilst the Player is moving.
            if (timer >= 5f && currentDialogue == "WASD")
            {
                dialogue.sentences[0] = "This is good. Keep going.";
                dialogue.sentences[1] = "Excellent.";
                
                TriggerDialogue();

                currentDialogue = "Next Level";

            }

            // N/A says something to indicate the player
            // needs to go to the next Level.
            if (timer >= 15f && currentDialogue == "Next Level")
            {

                dialogue.sentences[0] = "Well done, Tim. Now, I think we should talk more.";
                dialogue.sentences[1] = "Walk into the stairs to explore deeper.";

                TriggerDialogue();
                stairsToNextLevel.SetActive(true);

                currentDialogue = "End Of Level";

            }
        }

    }

    // Triggers dialogue.
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
