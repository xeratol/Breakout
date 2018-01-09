using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionExit2D : MonoBehaviour {

    public int lives = 1;

    private void OnCollisionExit2D()
    {
        --lives;
        if (lives > 0)
        {
            return;
        }
        Destroy(gameObject);
    }
}
