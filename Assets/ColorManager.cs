using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Color StartColor;
    public Color LoseColor;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.backgroundColor = StartColor;
    }

    public void ChangeToLoseColor()
    {
        cam.backgroundColor = LoseColor;
    }

    public void ChangeToStartColor()
    {
        cam.backgroundColor = StartColor;
    }
}
