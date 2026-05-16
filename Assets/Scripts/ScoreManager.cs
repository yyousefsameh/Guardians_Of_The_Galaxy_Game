using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]  TMP_Text scoreText;
    private int score = 0;
  public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = score.ToString();
    }
}
