using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData GameData;
    public GameEvent OnWinEvent;
    public GameEvent OnPaddleReset;
    public AnchorMotor Motor;
    public DotSpawner Spawner;
    public HintTextUI HintText;
    bool isFirstTap = true;

    void Start()
    {
        //reset the remaining dots
        GameData.ResetLevel();
    }

    void Update()
    {
        //if tapped and game not running then start game
        if (Input.GetMouseButtonDown(0) && !GameData.isRunning && isFirstTap)
        {
            GameData.isRunning = true;
            isFirstTap = false;
        }
    }

    public void DecrementRemainingDots()
    {
        GameData.DotsRemaining--;

        if (GameData.DotsRemaining <= 0)
        {
            GameData.DotsRemaining = 0;
            OnWinEvent.Raise();
        }
    }

    public void LoadLevel(bool next)
    {
        if (next)
        {
            GameData.CurrentLevel++;
            Motor.paddleDirection = Direction.Clockwise;
            OnPaddleReset.Raise();
        }
        GameData.ResetLevel();
        isFirstTap = true;
    }

    public void ResetGame()
    {
        GameData.isRunning = false;
        HintText.RestartText();
        HintText.gameObject.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            GameData.ResetData();
            Motor.paddleDirection = Direction.Clockwise;
            OnPaddleReset.Raise();
        }
    }
    public void StopGame()
    {
        GameData.isRunning = false;
        Spawner.DestroyDots();
    }
}
