using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text levelText;
    public int playerLevel = 1;

    public int newHealth;

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

    private void ChangedActiveScene(Scene current, Scene next)
    {
        PlayerMovement.OnUpdateHealth += UpdateHealthBar;
    }

    private void OnEnable()
    {
        PlayerMovement.OnUpdateHealth += UpdateHealthBar;
        PlayerMovement.OnSendLevel += UpdateLevel;
    }
    private void OnDisable()
    {
        PlayerMovement.OnUpdateHealth -= UpdateHealthBar;
        PlayerMovement.OnSendLevel -= UpdateLevel;
    }


    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    private void UpdateLevel(int theLevel)
    {
        playerLevel += theLevel;
        levelText.text = "LEVEL: " + playerLevel.ToString();
    }

}

