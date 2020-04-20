using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    // Cached References
    GameStatus gameStatus;
    Ball theBall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();

        /*
            If number of lives is less than or equal to 0, Game Over
        */
        if(gameStatus.getNumberOfLives() == 0)
        {
            UpdateLives();
            SceneManager.LoadScene("Game Over");
            Debug.Log("Game Over!");
        }
        else
        {
            UpdateLives();
            ResetBall();
        }
    }

    private void UpdateLives()
    {
        gameStatus.LoseALife();
        gameStatus.DisplayLivesOnPage();
        Debug.Log("Lives Remaining: " + gameStatus.getNumberOfLives());
    }

    private void ResetBall()
    {
        theBall.setGameHasStartedToFalse();
        theBall.LockBallToPaddle();
    }

}
