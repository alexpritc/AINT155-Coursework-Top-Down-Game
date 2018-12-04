using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {

    // Declaring variables.
    public Dialogue dialogue;

    public GameObject stairsToNextLevel;

    public string sceneName;

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
            }

            if (timer >= 5f)
            {
                dialogue.sentences[0] = "This is good. Keep going";
                dialogue.sentences[1] = "test";
                // N/A says something whilst the Player is moving.
                TriggerDialogue();

            }

            if (timer >= 10f)
            {
                // N/A says something to indicate the player
                // needs to go to the next Level.
                TriggerDialogue();
                stairsToNextLevel.SetActive(true);

            }
        }

    }

    // Triggers dialogue.
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
