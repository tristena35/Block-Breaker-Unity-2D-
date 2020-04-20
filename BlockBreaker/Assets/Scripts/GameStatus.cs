using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // Configuration Parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelNumberText;
    [SerializeField] TextMeshProUGUI numberOfLivesText;
    [SerializeField] bool isAutoPlayEnabled;

    // State variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int currentLevel = 1;
    [SerializeField] int numberOfLives = 2;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        // If there is already an object existing from previous scenes, dont make a new one
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        DisplayLivesOnPage();
        DisplayScoreOnPage();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed; 
        DisplayScoreOnPage();
    }

    public void AddToLevel()
    {
        currentLevel += 1; 
        DisplayLevelOnPage();
    }

    public void LoseALife()
    {
        numberOfLives --;
    }

    public void AddALife()
    {
        numberOfLives ++;
        Debug.Log("The current number of lifes: " + (numberOfLives + 1));
        DisplayLivesOnPage();
    }

    public int getNumberOfLives()
    {
        return numberOfLives;
    }

    private void DisplayScoreOnPage()
    {
        scoreText.text = currentScore.ToString();
    }

    public void DisplayLevelOnPage()
    {
        Debug.Log("The current level is: " + currentLevel);
        levelNumberText.text = "Level " + currentLevel.ToString();
    }

    public void DisplayLivesOnPage()
    {
        Debug.Log("The current number of lifes: " + (numberOfLives + 1));
        numberOfLivesText.text = "Lives " + (numberOfLives + 1).ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
