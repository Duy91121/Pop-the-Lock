using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMotor : MonoBehaviour
{
    public GameData GameData;
    public Direction paddleDirection = Direction.Clockwise;
    Vector3 initialPos;

    Transform anchor;

    // Start is called before the first frame update
    void Start()
    {
        anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        initialPos = GetComponent<Transform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.isRunning)
        {
            transform.RotateAround(anchor.position, Vector3.forward, GameData.currentMotorSpeed * Time.deltaTime * -(int)paddleDirection);
        }
        
        if (didTap && GameData.isRunning)
        {
            ChangeDirection();
        }
    }

    bool didTap
    {
        get
        {
            return Input.GetMouseButtonDown(0);
        }
    }

    void ChangeDirection()
    {
        switch (paddleDirection)
        {
            case Direction.Clockwise:
                paddleDirection = Direction.AntiClockwise;
                break;
            case Direction.AntiClockwise:
                paddleDirection = Direction.Clockwise;
                break;
        }
    }

    public void ResetPosition()
    {
        transform.localPosition = new Vector3(0, initialPos.y, 0);
        transform.localRotation = Quaternion.identity;
    }

    public void increaseSpeed(int value)
    {
        if (value > 0)
        {
            GameData.currentMotorSpeed = Mathf.Min(GameData.currentMotorSpeed + value, GameData.maxMotorSpeed);
        }
        else
        {
            Debug.LogError("Increase speed value must be greater than 0");
        }
    }
    public void reduceSpeed(int value)
    {
        if (value > 0)
        {
            GameData.currentMotorSpeed = Mathf.Max(GameData.currentMotorSpeed + value, GameData.minMotorSpeed);
        }
        else
        {
            Debug.LogError("Reduce speed value must be greater than 0");
        }
    }
}

public enum Direction
{
    Clockwise = 1,
    AntiClockwise = -1
}