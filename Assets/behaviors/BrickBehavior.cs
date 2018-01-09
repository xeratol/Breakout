using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour {

    private void Start()
    {
        GameManager.BrickCreated();
    }

    private void OnDestroy()
    {
        GameManager.BrickDestroyed();
    }
}
