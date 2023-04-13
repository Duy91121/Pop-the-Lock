using UnityEngine;

public class RemainingDotsTextUI : MonoBehaviour
{
    public GameData GameData;
    TMPro.TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TextMeshPro>();
        text.text = GameData.DotsRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameData.DotsRemaining.ToString();
    }
}
