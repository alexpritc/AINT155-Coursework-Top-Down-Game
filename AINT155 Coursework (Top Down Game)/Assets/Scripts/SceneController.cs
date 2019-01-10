using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

    public string sceneName;
    public static int saveHealth;
    public static string sendSceneName;

    void Update()
    {
        sendSceneName = sceneName;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("SceneLoader", 0.1f);
        }
    }

    public void SceneLoader()
    {
        SceneManager.LoadScene(sceneName);
        saveHealth = HealthSystem.health;

    }

    public void ExitApp()
    {
        Application.Quit();
    }


}
