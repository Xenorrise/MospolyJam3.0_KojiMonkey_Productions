using UnityEngine;
using UnityEngine.UI;

public class TipScript : MonoBehaviour
{
    public Vector3 addPosition;
    public Transform thisTR;
    Text tipText;

    void Start()
    {
        tipText = thisTR.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        thisTR.transform.position = Input.mousePosition + addPosition;
    }

    public void TextApper(string text)
    {
        tipText.text = text;
    }
}
