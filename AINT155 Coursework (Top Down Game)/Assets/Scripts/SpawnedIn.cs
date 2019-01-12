using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedIn : MonoBehaviour {

    // Declaring variables.
    public GameObject thisObject;

    public AudioClip spawnedIn;
    public AudioSource spawnedInSource;

    public bool isActive;
    public bool spawned = false;


	// Use this for initialization
	void Start ()
    {
        spawnedInSource = thisObject.GetComponent<AudioSource>();

        if (thisObject.activeInHierarchy == false)
        {
            isActive = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckIfActive();
	}



    // If object isn't active, but then becomes active.
    public void CheckIfActive()
    {
        if (isActive == false)
        {
            if (thisObject.activeInHierarchy == true)
            {
                if (spawned == false && SceneController.sendSceneName == "Level1.5")
                {
                    spawnedInSource.PlayOneShot(spawnedIn, 1f);
                    spawned = true;
                }
                if (spawned == false && SceneController.sendSceneName == "Level9")
                {
                    spawnedInSource.PlayOneShot(spawnedIn, 1f);
                    spawned = true;
                }

            }
        }
    }
}
