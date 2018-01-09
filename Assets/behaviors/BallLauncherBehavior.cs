using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherBehavior : MonoBehaviour {

    public KeyCode key;
    public GameObject ballPrefab;

    private void Start()
    {
        GameManager.SetBallLauncher(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.SendMessage("Launch");
            GameManager.BallLaunched();
            enabled = false;
        }
    }
}
