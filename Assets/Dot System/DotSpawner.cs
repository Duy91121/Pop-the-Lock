using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour
{
    public AnchorMotor Motor;
    public GameObject DotPrefab;
    public GameObject StarredDotPrefab;
    public GameData GameData;

    GameObject activeDot;
    Transform anchor;

    void Start()
    {
        anchor = GameObject.FindGameObjectWithTag("Anchor").transform;
        Spawn();
        Debug.Log("check");
    }
    public void Spawn()
    {
        if (activeDot)
        {
            Destroy(activeDot.gameObject);
        }
            
        if (GameData.DotsRemaining >= 0)
        {
            Debug.Log("spawned");
            var angle = Random.Range(GameData.MinSpawnAngle, GameData.MaxSpawnAngle);
            activeDot = Instantiate(SelectRandomDot(), Motor.transform.position, Quaternion.identity, transform);
            activeDot.transform.RotateAround(anchor.position, Vector3.forward, -angle * (int)Motor.paddleDirection);
        }
    }

    public void DestroyDots()
    {
        if (activeDot)
        {
            Destroy(activeDot.gameObject);
        }
    }

    GameObject SelectRandomDot()
    {
        if (Random.value < .2)
        {
            return StarredDotPrefab;
        }
        else
        {
            return DotPrefab;
        }
    }
}
