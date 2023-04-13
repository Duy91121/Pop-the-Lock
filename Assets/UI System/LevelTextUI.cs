using UnityEngine;

public class LevelTextUI : MonoBehaviour
{
    public GameData GameData;
    TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "Level: " + GameData.CurrentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level: " + GameData.CurrentLevel.ToString();
    }
}
