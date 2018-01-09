using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControls : MonoBehaviour {

    public float ltLimit = -15;
    public float rtLimit = 15;

    public float speed = 10;

    void Awake()
    {
        Debug.Assert(ltLimit < rtLimit, "Invalid limits", this);
        Debug.Assert(speed > 0, "Invalid speed", this);
    }

    void Update ()
    {
        var xInc = Input.GetAxis("Horizontal") * speed;
        if (Mathf.Abs(xInc) < Mathf.Epsilon)
        {
            return;
        }
        var position = transform.position;
        position.x += xInc;
        position.x = Mathf.Clamp(position.x, ltLimit, rtLimit);
        transform.position = position;
    }
}
