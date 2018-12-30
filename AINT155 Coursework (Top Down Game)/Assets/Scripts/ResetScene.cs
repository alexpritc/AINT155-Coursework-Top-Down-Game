using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour {

    public string currentScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("ReloadScene", 3f);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentScene);
    }
}
