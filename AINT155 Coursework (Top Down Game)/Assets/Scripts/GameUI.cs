using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text levelText;
    public int playerLevel = 1;

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

