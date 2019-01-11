using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    // Declaring varaibles.
    public Slider healthBar;
    public int playerLevel = 1;

    public int newHealth;



    // Called at the beginning...
    public void Start()
    {
        if (SceneController.sendSceneName != "Level1")
        {
            healthBar.value = SceneController.saveHealth;
        }
        if (SceneController.sendSceneName == "Level1")
        {
            healthBar.value = 100;
        }
        
    }

    // Called every frame...
    public void Update()
    {
        if (IncreaseHealth.shouldIncreaseHealth == true)
        {
            healthBar.value = healthBar.value + 10;
            IncreaseHealth.shouldIncreaseHealth = false;
        }

        if (DecreaseHealth.shouldDecreaseHealth == true)
        {
            healthBar.value = healthBar.value - 10;
            DecreaseHealth.shouldDecreaseHealth = false;
        }
    }



    // Carries the health data over to the next scene.
    private void ChangedActiveScene(Scene current, Scene next)
    {
        PlayerMovement.OnUpdateHealth += UpdateHealthBar;
    }



    // Updates the health data.
    private void OnEnable()
    {
        PlayerMovement.OnUpdateHealth += UpdateHealthBar;
    }

    private void OnDisable()
    {
        PlayerMovement.OnUpdateHealth -= UpdateHealthBar;
    }



    // Updates the UI.
    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

}

