using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMesh scoreText;
    private int score = 0;
    private int bonus = 0;
    private int bonusPoints = 10;

    public void DisplayScore(int value)
    {
        scoreText.text = value.ToString();
    }

    public void AddScore()
    {
        score--;
        DisplayScore(score);
        //Debug.Log("score = " + score);
    }

    public void AddBonus()
    {
        bonus++;
        //Debug.Log("bonus = " + bonus);
    }

    public void CollectBonus()
    {
        for (int i = 0; i < bonus; i++)
        {
            score += bonusPoints;
            DisplayScore(score);
        }
    }
}
