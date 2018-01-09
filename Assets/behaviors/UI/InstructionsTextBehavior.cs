using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsTextBehavior : MonoBehaviour {

    private Text text;
    [TextArea]
    public string textString;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void OnBallLaunched ()
    {
        text.enabled = false;
    }

    void OnBallRetry(int livesLeft)
    {
        text.text = string.Format(textString, livesLeft);
        text.enabled = true;
    }
}
