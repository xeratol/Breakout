using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverBehavior : MonoBehaviour {

    void Start ()
    {
        ActivateChildren(false);
    }

    void ActivateChildren(bool activate)
    {
        for (var i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(activate);
        }
    }

    void OnGameLost ()
    {
        ActivateChildren(true);
    }

    void OnGameWon ()
    {
        ActivateChildren(true);
    }
}
