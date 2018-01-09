using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    private int numBricks;
    private int numBalls;
    public int numRetries = 3;

    private BallLauncherBehavior ballLauncher;

    public GameObject [] onBallLaunchedListeners;
    public GameObject [] onBallRetryListeners;
    public GameObject [] onGameLostListeners;
    public GameObject [] onGameWonListeners;

    private void Awake()
    {
        Debug.Assert(instance == null, "There should be only one instance", this);
        instance = this;
        Time.timeScale = 1;
    }

    public static void SetBallLauncher(BallLauncherBehavior launcher)
    {
        instance.ballLauncher = launcher;
    }

    public static void BallCreated()
    {
        if (instance == null)
        {
            return;
        }

        ++instance.numBalls;
    }

    public static void BallLaunched()
    {
        foreach (var listener in instance.onBallLaunchedListeners)
        {
            listener.SendMessage("OnBallLaunched");
        }
    }

    public static void BallDestroyed()
    {
        if (instance == null)
        {
            return;
        }

        --instance.numBalls;

        if (instance.numBalls < 1)
        {
            --instance.numRetries;
            if (instance.numRetries < 1)
            {
                foreach (var listener in instance.onGameLostListeners)
                {
                    listener.SendMessage("OnGameLost");
                }
                Time.timeScale = 0;
                Debug.Log("Game Lost");
            }
            else
            {
                instance.ballLauncher.enabled = true;
                foreach (var listener in instance.onBallRetryListeners)
                {
                    listener.SendMessage("OnBallRetry", instance.numRetries);
                }
            }
        }
    }

    public static void BrickCreated()
    {
        if (instance == null)
        {
            return;
        }

        ++instance.numBricks;
    }

    public static void BrickDestroyed()
    {
        if (instance == null)
        {
            return;
        }

        --instance.numBricks;

        if (instance.numBricks < 1)
        {
            foreach (var listener in instance.onGameWonListeners)
            {
                listener.SendMessage("OnGameWon");
            }
            Time.timeScale = 0;
            Debug.Log("Game Won");
        }
    }
}
