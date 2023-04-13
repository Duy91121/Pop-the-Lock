using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDetector : MonoBehaviour
{
    GameObject currentDot;
    GameObject lastEnteredDot;
    public GameData GameData;
    public float loseThreshold = .1f;
    public GameEvent DotMissedEvent;
    public GameEvent DotScoredEvent;

    void OnTriggerEnter2D(Collider2D other)
    {
        currentDot = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        lastEnteredDot = currentDot;
        currentDot = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.isRunning)
        {
            //find distance b/w last dot and current dot; if higher than same threshold, then raise DontMissed Event
            if (lastEnteredDot && getDistanceFromLastDot() > loseThreshold)
            {
                DotMissedEvent.Raise();
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (currentDot != null)
                {
                    if (currentDot.GetComponent<Star>())
                    {
                        GameData.Stars++;
                    }
                    Destroy(currentDot);
                    DotScoredEvent.Raise();
                    Debug.Log("Score++");
                }
                else
                {
                    Debug.Log("Game Over");
                    DotMissedEvent.Raise();
                }
            }
        }
    }

    float getDistanceFromLastDot()
    {
        return (transform.position - lastEnteredDot.transform.position).magnitude;
    }
}
