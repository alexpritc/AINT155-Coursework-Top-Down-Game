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
    bool hasInitialLevel1DialogueBeenCalled = false;
    bool hasNASpokenWhilstPlayerMoves = false;
    bool hasTheEndOfLevelDialogueBeenCalled = false;

    // Level 1.5 triggers.
    bool hasInitialLevel1AndAHalfDialogueBeenCalled = false;
    bool hasDialogueAboutObstaclesBeenCalled = false;
    bool hasPlayerWalkedIntoWallBeforeNATalks = false;
    bool hasPlayerWalkedIntoWallAfterNATalks = false;

    // Level 2 triggers.
    bool hasInitialLevel2DialogueBeenCalled = false;
    bool hasSteppedOnMazePanel = false;
    bool hasPlayerNotOnMazePanelDialogueBeenCalled = false;
    bool hasPlayerNotOnMazePanelDialogueCompleted = false;



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



    // Triggers dialogue.
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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
        if (hasInitialLevel1DialogueBeenCalled == false)
        {
            Invoke("TriggerDialogue", 1f);

            currentDialogue = "WASD";
            hasInitialLevel1DialogueBeenCalled = true;

        }

        // N/A says something whilst the Player is moving.
        if (timer >= 5f && currentDialogue == "WASD" && hasInitialLevel1DialogueBeenCalled == true)
        {
            dialogue.sentences[0] = "This is good. Keep going.";
            dialogue.sentences[1] = "Excellent.";

            Invoke("TriggerDialogue", 2f);

            currentDialogue = "Next Level";
            hasNASpokenWhilstPlayerMoves = true;

        }

        // N/A says something to indicate the player
        // needs to go to the next Level.
        if (timer >= 15f && currentDialogue == "Next Level" && hasNASpokenWhilstPlayerMoves == true)
        {

            dialogue.sentences[0] = "Well done, Tim. Now, I think we should talk more.";
            dialogue.sentences[1] = "Walk into the stairs to explore deeper.";

            Invoke("TriggerDialogue", 1f);

            currentDialogue = "End Of Level";
            hasTheEndOfLevelDialogueBeenCalled = true;

            if (hasTheEndOfLevelDialogueBeenCalled == true)
            {
                stairsToNextLevel.SetActive(true);
            }

        }
    }

    public void Level1AndAHalf()
    {
        // The initial conversation.
        if (hasInitialLevel1AndAHalfDialogueBeenCalled == false)
        {
            TriggerDialogue();
            hasInitialLevel1AndAHalfDialogueBeenCalled = true;

            timer = 0f;
        }

        // NA introduces the player to obstacles.
        if (timer >= 5f && hasInitialLevel1AndAHalfDialogueBeenCalled == true &&
            hasDialogueAboutObstaclesBeenCalled == false)
        {
            dialogue.sentences[0] = "Also, there are obstacles that block your path.";
            dialogue.sentences[1] = "Find your way to the next level.";

            Invoke("TriggerDialogue", 0.5f);
            hasDialogueAboutObstaclesBeenCalled = true;
        }
    }

    public void Level2()
    {
        // Initial level dialogue.
        if (hasInitialLevel2DialogueBeenCalled == false)
        {
            TriggerDialogue();

            hasInitialLevel2DialogueBeenCalled = true;
        }

        // If the player doesn't trust NA.
        if (hasSteppedOnMazePanel == false && hasPlayerNotOnMazePanelDialogueBeenCalled == false && timer >= 10f)
        {

            hasPlayerNotOnMazePanelDialogueBeenCalled = true;

            dialogue.sentences[0] = "Fine. Have it your way.";
            dialogue.sentences[1] = "";
            dialogue.sentences[2] = "";
            Invoke("TriggerDialogue", 0.5f);

            hasPlayerNotOnMazePanelDialogueCompleted = true;
        }

        // Calls the next level.
        if (hasSteppedOnMazePanel == true && timer >= 10f || hasPlayerNotOnMazePanelDialogueCompleted == true && timer >= 15f)
        {
            SceneManager.LoadScene("Level3");
        }

    }



    // Dialogue changes depending on collisions.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ("Player"))
        {
            // Level 1.5.
            if (sceneName == "Level1.5" && hasInitialLevel1AndAHalfDialogueBeenCalled == true 
                && hasPlayerWalkedIntoWallBeforeNATalks == false)
            {
                // If the player walks into a wall before NA talks about it.
                dialogue.sentences[0] = "Well that wasn't very smart.";
                dialogue.sentences[1] = "Pay more attention, Tim.";

                hasPlayerWalkedIntoWallBeforeNATalks = true;

                // If the player walks into a wall after NA talks about it.
                if (sceneName == "Level1.5" & hasDialogueAboutObstaclesBeenCalled == true &&
                    hasPlayerWalkedIntoWallAfterNATalks == false)
                {
                    dialogue.sentences[0] = "What did I just say?";
                    dialogue.sentences[1] = "Pay more attention, Tim.";

                    hasPlayerWalkedIntoWallAfterNATalks = true;
                }

                Invoke("TriggerDialogue", 0.5f);
            }

            // Level 2.
            if (sceneName == "Level2" && hasInitialLevel2DialogueBeenCalled == true
                && timer <= 15f && hasSteppedOnMazePanel == false)
            {
                // If the player does stand on the Maze Panels.
                dialogue.sentences[0] = "Looks like we're going around in circles.";
                dialogue.sentences[1] = "Now how do you plan to get out of this one, Tim?";
                dialogue.sentences[2] = "";

                TriggerDialogue();

                dialogue.sentences[0] = "I suppose you'll be wanting my help.";
                dialogue.sentences[1] = "";
                dialogue.sentences[2] = "";

                Invoke("TriggerDialogue", 5f);

                hasSteppedOnMazePanel = true;
            }
            
        }
       
    }
}
