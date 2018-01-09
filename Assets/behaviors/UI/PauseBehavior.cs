using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour {

    public KeyCode key;
    private bool isPaused = false;

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

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            isPaused = !isPaused;

            Time.timeScale = isPaused ? 0 : 1;
            ActivateChildren(isPaused);
        }
    }

    void OnGameWon()
    {
        gameObject.SetActive(false);
    }

    void OnGameLost()
    {
        gameObject.SetActive(false);
    }
}
