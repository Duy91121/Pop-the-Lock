using UnityEngine;

public class HintTextUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            gameObject.SetActive(false);
    }

    public void InitialText()
    {
        text.text = "TAP";
    }

    public void RestartText()
    {
        text.text = "TAP to Restart";
    }
}
