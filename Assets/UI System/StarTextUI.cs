using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTextUI : MonoBehaviour
{
    public GameData GameData;
    TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Star: " + GameData.Stars.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Star: " + GameData.Stars.ToString();
    }
}
