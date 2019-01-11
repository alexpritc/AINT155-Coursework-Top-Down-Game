using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

    // Declaring varaibles.
    public string currentScene;



    // When the player collides with this trigger,
    // the scene is reloaded.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("ReloadScene", 3f);
        }
    }

    // Reload the scene.
    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
