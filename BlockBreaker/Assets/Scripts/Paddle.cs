using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    // Configuration Parameters
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float xMin = 1.0f, xMax = 15.0f;

    // Cached References
    GameStatus theGameStatus;
    Ball theBall;

    void Start()
    {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {           
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), xMin, xMax);

        // Move Paddle
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if(theGameStatus.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            float xMousePosInUnits = (Input.mousePosition.x / Screen.width * screenWidthInUnits);
            return xMousePosInUnits;
        }
    }

}
