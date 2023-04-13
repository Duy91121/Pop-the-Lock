using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public int CurrentLevel;
    public int DotsRemaining;
    public int Stars;
    public bool isRunning = false;
    public int MinSpawnAngle = 30;
    public int MaxSpawnAngle = 90;
    public int currentMotorSpeed = 50;
    public int maxMotorSpeed = 100;
    public int minMotorSpeed = 50;

    public void ResetLevel()
    {
        isRunning = false;
        DotsRemaining = CurrentLevel;
    }

    public void ResetData()
    {
        CurrentLevel = 1;
        DotsRemaining = CurrentLevel;
        currentMotorSpeed = minMotorSpeed;
    }
}
