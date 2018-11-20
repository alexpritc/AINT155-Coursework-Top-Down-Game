using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public Text scoreText;
    public int playerScore = 0;

    private void OnEnable()
    {
        PlayerMovement.OnUpdateHealth += UpdateHealthBar;
        //AddScore.OnSendScore += UpdateScore;
    }
    private void OnDisable()
    {
        PlayerMovement.OnUpdateHealth -= UpdateHealthBar;
        //AddScore.OnSendScore -= UpdateScore;
    }


    private void UpdateHealthBar(int health)
    {
        healthBar.value = health;
    }

    //private void UpdateScore(int theScore)
    //{
    //    playerScore += theScore;
    //    scoreText.text = "SCORE: " + playerScore.ToString();
    //}
}

