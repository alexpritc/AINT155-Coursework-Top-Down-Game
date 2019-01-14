using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

    // Declaring variables.
    public string nextScene;
    public string currentScene;

    public static int saveHealth;
    public static string sendSceneName;

    public static string sceneNameGameOver;

    public AudioClip newLevelClip;
    public AudioSource newLevelAudio;

    void Awake()
    {
        sendSceneName = nextScene;

        if (nextScene != "Level1" || nextScene != "Level1.5" || nextScene != "MainMenu" || nextScene != "Controls" || nextScene != "Introduction" ||
            nextScene != "Introduction2")
        {
            newLevelAudio = GetComponent<AudioSource>();
            newLevelAudio.PlayOneShot(newLevelClip, 1F);
        }

        // TESTING TESTING
        if (nextScene == "Level14")
        {
            saveHealth = 100;
        }
        // TESTING TESTING
    }

    // Called once every frame.
    void Update()
    {
        sendSceneName = nextScene;
        if (nextScene != "Level1" || nextScene != "Level1.5" || nextScene != "MainMenu" || nextScene != "Controls" || nextScene != "Introduction" ||
            nextScene != "Introduction2")
        {
            ResetScene();
        }
            

    }

    // Called when the GameObject collides with the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("SceneLoader", 0.1f);
        }
    }



    // Reset Scene
    public void ResetScene()
    {
        if (Input.GetKey(KeyCode.R))
        {
            saveHealth = HealthSystem.health;
            SceneManager.LoadScene(currentScene);
        }
    }


    // Load the next scene, and save the current health to carry over.
    public void SceneLoader()
    {
        saveHealth = HealthSystem.health;
        SceneManager.LoadScene(nextScene);
    }



    // Exit the application.
    public void ExitApp()
    {
        Application.Quit();
    }

    // Load Game Over scene.
    public void GameOver()
    {
        sceneNameGameOver = sendSceneName;
        SceneManager.LoadScene("GameOver");
    }


}
