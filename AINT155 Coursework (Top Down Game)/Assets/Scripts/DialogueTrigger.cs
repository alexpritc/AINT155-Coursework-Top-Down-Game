﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour {

    // Declaring variables.
    public Dialogue dialogue;

    public GameObject stairsToNextLevel;
    public GameObject fakeStairs;
    public GameObject grate;
    public GameObject fakeGrate;

    public string sceneName;
    string currentDialogue;

    public float timer = 0f;
    public float spinningTimer = 0f;

    // isSpinningTriggers;
    bool hasbeenCalledOnCurrentLevel = false;

    // General Triggers;
    bool hasInitialDialogueBeenCalled = false;

    // Introduction triggers
    bool hasInitialIntroductionDialogueBeenCalled = false;

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
    bool hasSteppedOnMazePanelLevel2 = false;
    bool hasPlayerNotOnMazePanelDialogueBeenCalled = false;
    bool hasPlayerNotOnMazePanelDialogueCompleted = false;

    // Level 3 triggers.
    bool hasInitialLevel3DialogueBeenCalled = false;
    bool hasPlayerSteppedOnMazePanelLevel3 = false;

    // Level 4 triggers.
    bool hasInitialLevel4DialogueBeenCalled = false;
    bool hasNASlowClapped = false;

    // Level 5 triggers.
    bool hasInitialLevel5DialogueBeenCalled = false;
    bool hasPlayerSteppedOnMazePanelLevel5 = false;

    // Level 6 triggers.
    bool hasInitialLevel6DialogueBeenCalled = false;

    // Level 7 triggers.
    bool hasInitialLevel7DialogueBeenCalled = false;

    // Level 8 triggers.
    bool hasInitialLevel8DialogueBeenCalled = false;

    // Level 13 triggers.
    bool hasInitialLevel13DialogueBeenCalled = false;
    bool hasNAContinuedTalkLevel13 = false;

    // Level 16 triggers.
    bool hasInitialLevel16DialogueBeenCalled = false;



    // Called once at initialisation.
    void Start()
    {
        if (sceneName == "Level1")
        {
            stairsToNextLevel.SetActive(false);
        }

        if (sceneName == "Level3")
        {
            fakeStairs.SetActive(true);
            stairsToNextLevel.SetActive(false);
        }

        if (sceneName == "Level5")
        {
            fakeStairs.SetActive(true);
            stairsToNextLevel.SetActive(false);

            fakeGrate.SetActive(true);
            grate.SetActive(false);

        }

    }

    // Called once every frame.
    void Update()
    {
        DialogueSequence();

        if (sceneName != "Level1" && sceneName != "Level1.5" && sceneName != "Level2" &&
              sceneName != "Level3" && sceneName != "Level4" && sceneName != "Level5")
        {
            IsSpinningPrompt();
        }

        timer += Time.fixedDeltaTime;
        
        if (PlayerMovement.isSpinning == true)
        {
            spinningTimer += Time.fixedDeltaTime;
        }
        else
        {
            spinningTimer = 0f;
        }

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
        if (sceneName == "Introduction" || sceneName == "Introduction2")
        {
            Introduction();
        }

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

        if (sceneName == "Level3")
        {
            Level3();
        }

        if (sceneName == "Level4")
        {
            Level4();
        }
        
        if (sceneName == "Level5")
        {
            Level5();
        }

        if (sceneName == "Level6")
        {
            Level6();
        }

        if (sceneName == "Level7")
        {
            Level7();
        }

        if (sceneName == "Level8")
        {
            Level8();
        }

        if (sceneName == "Level12")
        {
            Level12();
        }

        if (sceneName == "Level13")
        {
            Level13();
        }

        if (sceneName == "Level16")
        {
            Level16();
        }
    }

    // Prompts the player to press R if they've been spinning for ages.
    public void IsSpinningPrompt()
    {
        if (PlayerMovement.isSpinning == true)
        {
            if (hasbeenCalledOnCurrentLevel == false)
            {

                if (spinningTimer >= 10f)
                {
                    dialogue.sentences[0] = "Look, it's ok to admit you're bad.";
                    dialogue.sentences[1] = "If you're stuck, press R to reset the level.";
                    dialogue.sentences[2] = "Your parents did say you would fail.";

                    TriggerDialogue();
                    hasbeenCalledOnCurrentLevel = true;
                }

            }
        }

    }



    // Methods for calling individual levels,
    // which are in order.
    public void Introduction()
    {
        if (hasInitialIntroductionDialogueBeenCalled == false)
        {
            TriggerDialogue();

            hasInitialIntroductionDialogueBeenCalled = true;

        }
    }

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
            dialogue.sentences[0] = "Excellent.";
            dialogue.sentences[1] = "";

            Invoke("TriggerDialogue", 2f);

            currentDialogue = "Next Level";
            hasNASpokenWhilstPlayerMoves = true;

        }

        // N/A says something to indicate the player
        // needs to go to the next Level.
        if (timer >= 10f && currentDialogue == "Next Level" && hasNASpokenWhilstPlayerMoves == true)
        {

            dialogue.sentences[0] = "Well done, Tim. Now, I think we should talk more.";
            dialogue.sentences[1] = "Let's go to the next level. Walk into the stairs to explore deeper.";

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
        if (hasSteppedOnMazePanelLevel2 == false && hasPlayerNotOnMazePanelDialogueBeenCalled == false && timer >= 10f)
        {

            hasPlayerNotOnMazePanelDialogueBeenCalled = true;

            dialogue.sentences[0] = "Fine. Have it your way.";
            dialogue.sentences[1] = "";
            dialogue.sentences[2] = "";
            Invoke("TriggerDialogue", 0.5f);

            hasPlayerNotOnMazePanelDialogueCompleted = true;
        }

        // Calls the next level.
        if (hasSteppedOnMazePanelLevel2 == true && timer >= 10f || hasPlayerNotOnMazePanelDialogueCompleted == true && timer >= 15f)
        {
            SceneManager.LoadScene("Level3");
        }

    }

    public void Level3()
    {
        // Initial level dialogue.
        if (hasInitialLevel3DialogueBeenCalled == false)
        {
            hasInitialLevel3DialogueBeenCalled = true;
            TriggerDialogue();
        }

        // If the player doesn't step on the maze panel.
        if (hasInitialLevel3DialogueBeenCalled == true && hasPlayerSteppedOnMazePanelLevel3 == false && timer >= 10f)
        {
            dialogue.sentences[0] = "Step on that maze panel, Tim.";
            dialogue.sentences[1] = "When you do, I'll activate the stairs to the next level";
            dialogue.sentences[2] = "...and it'll propel you down them, ~trust me~.";

            TriggerDialogue();

            timer = 0f;

            hasPlayerSteppedOnMazePanelLevel3 = true;
        }
    }

    public void Level4()
    {
        // Initial level dialogue.
        if (hasInitialLevel4DialogueBeenCalled == false)
        {
            hasInitialLevel4DialogueBeenCalled = true;
            TriggerDialogue();
        }
    }

    public void Level5()
    {
        // Initial level dialogue.
        if (hasInitialLevel5DialogueBeenCalled == false)
        {
            hasInitialLevel5DialogueBeenCalled = true;
            TriggerDialogue();
        }
    }

    public void Level6()
    {
        // Initial level dialogue.
        if (hasInitialLevel6DialogueBeenCalled == false)
        {
            hasInitialLevel6DialogueBeenCalled = true;
            TriggerDialogue();
        }
    }

    public void Level7()
    {
        // Initial level dialogue.
        if (hasInitialLevel7DialogueBeenCalled == false)
        {
            hasInitialLevel7DialogueBeenCalled = true;
            TriggerDialogue();
        }
    }

    public void Level8()
    {
        if (hasInitialLevel8DialogueBeenCalled == false)
        {
            TriggerDialogue();
            hasInitialLevel8DialogueBeenCalled = true;
        }

        if (timer >= 10f)
        {
            stairsToNextLevel.SetActive(true);
        }
    }

    public void Level12()
    {
        if (EnvironmentalDamage.isCompletingPuzzle == false && hasInitialDialogueBeenCalled == false)
        {
            hasInitialDialogueBeenCalled = true;
            TriggerDialogue();
        }
    }

    public void Level13()
    {
        if (hasInitialLevel13DialogueBeenCalled == false)
        {
            TriggerDialogue();
            hasInitialLevel13DialogueBeenCalled = true;
        }

        if (timer >= 12.5f && hasNAContinuedTalkLevel13 == false)
        {
            hasNAContinuedTalkLevel13 = true;

            dialogue.sentences[0] = "~Other Tim~ is what your parents, teachers";
            dialogue.sentences[1] = "and everyone that knows you wishes you were.";
            dialogue.sentences[2] = "Why can't you be more like them, Tim?";
            dialogue.sentences[3] = "... ... ... ... ... ...";
            dialogue.sentences[4] = "Try harder.";

            TriggerDialogue();
        }

        if (timer >= 20f)
        {
            stairsToNextLevel.SetActive(true);
        }
    }

    public void Level16()
    {
        if (hasInitialLevel16DialogueBeenCalled == false)
        {
            hasInitialLevel16DialogueBeenCalled = true;
            TriggerDialogue();
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
                && timer <= 15f && hasSteppedOnMazePanelLevel2 == false)
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

                hasSteppedOnMazePanelLevel2 = true;
            }
            
            // Level 3.
            if (sceneName == "Level3" && hasInitialLevel3DialogueBeenCalled == true)
            {
                hasPlayerSteppedOnMazePanelLevel3 = true;
                stairsToNextLevel.SetActive(true);
            }

            // Level 4.
            if (sceneName == "Level4" && hasInitialLevel4DialogueBeenCalled == true && hasNASlowClapped == false)
            {
                dialogue.sentences[0] = "Clap... Clap... Clap.";
                dialogue.sentences[1] = "";
                dialogue.sentences[2] = "";

                TriggerDialogue();

                hasNASlowClapped = true;
            }
            if (sceneName == "Level4" && hasInitialLevel4DialogueBeenCalled == true && hasNASlowClapped == true
                && timer >= 10f)
            {
                dialogue.sentences[0] = "...";
                dialogue.sentences[1] = "";
                dialogue.sentences[2] = "";

                TriggerDialogue();

                hasNASlowClapped = false;
            }

            // Level 5.
            if (sceneName == "Level5" && hasPlayerSteppedOnMazePanelLevel5 == false)
            {
                hasPlayerSteppedOnMazePanelLevel5 = true;
                grate.SetActive(true);
                stairsToNextLevel.SetActive(true);
            }

        }
       
    }
}
