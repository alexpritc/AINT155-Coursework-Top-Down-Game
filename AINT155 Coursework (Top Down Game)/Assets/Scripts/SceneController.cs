﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour {

    // Declaring variables.
    public string sceneName;
    public static int saveHealth;
    public static string sendSceneName;

    public AudioClip newLevelClip;
    public AudioSource newLevelAudio;

    void Awake()
    {
        if (sceneName != "Level1" || sceneName != "Level1.5" || sceneName != "MainMenu" || sceneName != "Controls" || sceneName != "Introduction" ||
            sceneName != "Introduction2")
        {
            newLevelAudio = GetComponent<AudioSource>();
            newLevelAudio.PlayOneShot(newLevelClip, 1F);
        }

    }

    // Called once every frame.
    void Update()
    {
        sendSceneName = sceneName;
    }

    // Called when the GameObject collides with the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("SceneLoader", 0.1f);
        }
    }



    // Load the next scene, and save the current health to carry over.
    public void SceneLoader()
    {
        SceneManager.LoadScene(sceneName);
        saveHealth = HealthSystem.health;

    }



    // Exit the application.
    public void ExitApp()
    {
        Application.Quit();
    }


}
