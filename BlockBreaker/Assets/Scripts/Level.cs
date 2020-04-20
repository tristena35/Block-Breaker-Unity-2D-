using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    // Variable to tell if we are on the last level
    bool lastLevel = false;

    // Serialized for Debugging purposes
    [SerializeField] int breakableBlocks;

    // Cache Reference
    SceneLoader sceneLoader;
    GameStatus gameStatus;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();

        gameStatus.DisplayLevelOnPage();

        if(SceneManager.GetActiveScene().name == "Level 5")
        {
            lastLevel = true;
            Debug.Log("Last level");
        }
    }

    public void CountBlocks()
    {
        breakableBlocks ++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks --;
        
        if(breakableBlocks <=0 && lastLevel == true)
        { 
            LoadWinScreen();
            Debug.Log("Win!");
        }
        else if(breakableBlocks <= 0 && lastLevel == false)
        {
            sceneLoader.LoadNextScene();
            // Add another life since they made it passed the level
            gameStatus.AddALife();
            // Add one to the level count
            gameStatus.AddToLevel();
            Debug.Log("Didn't win, but on to the next level");
        }
    }

    private void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }
    
}
