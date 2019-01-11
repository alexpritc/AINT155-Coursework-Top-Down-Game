using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    // Declaring variables.
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public AudioClip npcAudio;
    public AudioSource npcSource;



    // When the GameObject this script is attatched to is loaded...
    void Start() {

        sentences = new Queue<string>();
        npcSource = GetComponent<AudioSource>();

    }



    // Open the dialogue box, and display next sentence.
    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // When the continue button is clicked.
    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (sentence == "")
        {
            EndDialogue();   
        }
    }

    // Display eachs character in the sentence individually.
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {

            if (letter.ToString() != " " && npcSource.isPlaying == false)
            {
                npcSource.PlayOneShot(npcAudio, 0.25F);
            }
            dialogueText.text += letter;
            yield return null;

        }
    }

	// Closes the diagloue box.
	void EndDialogue()
    {
        if (SceneController.sendSceneName == "Introduction")
        {
            SceneManager.LoadScene("Introduction2");
        }
        if (SceneController.sendSceneName == "Introduction2")
        {
            SceneManager.LoadScene("MainMenu");
        }

        animator.SetBool("isOpen", false);
    }
}
