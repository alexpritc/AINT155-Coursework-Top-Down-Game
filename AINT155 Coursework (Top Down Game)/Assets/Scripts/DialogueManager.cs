using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;


	void Start () {

        sentences = new Queue<string>();

	}

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


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

	
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
