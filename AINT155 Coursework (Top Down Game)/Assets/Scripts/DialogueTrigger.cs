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

    // Level 1 triggers.
    bool hasLevel1Trigger1BeenCalled = false;
    bool hasLevel1Trigger2BeenCalled = false;
    bool hasLevel1Trigger3BeenCalled = false;

    // Level 1.5 triggers.
    bool hasLevel1AndAHalfTrigger1BeenCalled = false;
    bool hasLevel1AndAHalfTrigger2BeenCalled = false;
    bool hasLevel1AndAHalfTrigger3BeenCalled = false;
    bool hasLevel1AndAHalfTrigger4BeenCalled = false;

    // Level 2 triggers.
    bool hasLevel2Trigger1BeenCalled = false;


    // Called once at initialisation.
    void Start()
    {
        if (sceneName == "Level1")
        {
            stairsToNextLevel.SetActive(false);
        }
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
            Level1();
        }

        if (sceneName == "Level1.5")
        {
            Level1AndAHalf();
        }

        if (sceneName == "Level2")
        {
            Level2();
        }

    }

    // Methods for calling individual levels,
    // which are in order.
    public void Level1()
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

    public void Level1AndAHalf()
    {
        if (hasLevel1AndAHalfTrigger1BeenCalled == false)
        {
            TriggerDialogue();
            hasLevel1AndAHalfTrigger1BeenCalled = true;
        }

        if (timer >= 5f && hasLevel1AndAHalfTrigger1BeenCalled == true &&
            hasLevel1AndAHalfTrigger2BeenCalled == false)
        {
            dialogue.sentences[0] = "Also, there are obstacles that block your path.";
            dialogue.sentences[1] = "Find your way to the next level.";

            Invoke("TriggerDialogue", 0.5f);
            hasLevel1AndAHalfTrigger2BeenCalled = true;
        }
    }

    public void Level2()
    {
        if (hasLevel2Trigger1BeenCalled == false)
        {
            TriggerDialogue();
            hasLevel2Trigger1BeenCalled = true;
        }
    }

    // Triggers dialogue.
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    // Dialogue changes depending on collisions.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            // Level 1.5.
            if (sceneName == "Level1.5" && hasLevel1AndAHalfTrigger1BeenCalled == true 
                && hasLevel1AndAHalfTrigger3BeenCalled == false)
            {
                dialogue.sentences[0] = "Well that wasn't very smart.";
                dialogue.sentences[1] = "Pay more attention, Tim.";

                hasLevel1AndAHalfTrigger3BeenCalled = true;


                if (sceneName == "Level1.5" & hasLevel1AndAHalfTrigger2BeenCalled == true &&
                    hasLevel1AndAHalfTrigger4BeenCalled == false)
                {
                    dialogue.sentences[0] = "What did I just say?";
                    dialogue.sentences[1] = "Pay more attention, Tim.";

                    hasLevel1AndAHalfTrigger4BeenCalled = true;
                }

                Invoke("TriggerDialogue", 0.5f);
            }
        }
       
    }
}
