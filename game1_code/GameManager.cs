﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RigidMovement2 playerMovement;
    public TextMesh gameText;
    public float restartDelay = 1f;
    bool gameOver = false;
    private GameObject obstacle;
    
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        obstacle = GameObject.FindGameObjectWithTag("Obstacle");

        if (obstacle)
        {
            if (obstacle.transform.position.y < -1f)
            {
                FindObjectOfType<Score>().AddBonus();
                Destroy(obstacle);
            }
        }
        else
        {
            if (gameOver == false)
            {
                FindObjectOfType<Score>().CollectBonus();
            }
            WinGame();
        }
    }

    public void StartGame()
    {
        gameOver = false;
        gameText.text = "";
        gameText.color = Color.clear;
    }

    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOver = true;
            playerMovement.enabled = false;
            gameText.text = "GAME\nOVER";
            gameText.color = Color.black;
            Invoke("RestartGame", restartDelay);
        }
    }

    public void WinGame()
    {
        gameOver = true;
        playerMovement.enabled = false;
        gameText.text = "YOU WIN!\nPress Space\nto Restart";
        gameText.color = Color.black;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
