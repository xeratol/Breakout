using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallBehavior : MonoBehaviour {

    private Rigidbody2D body2d;
    public float initialSpeed = 20;
    public Vector2 initialDir;

    private void Awake()
    {
        Debug.Assert(initialDir.sqrMagnitude > Mathf.Epsilon, "Invalid initial direction", this);
        body2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameManager.BallCreated();
    }

    private void OnDestroy()
    {
        GameManager.BallDestroyed();
    }

    void Launch()
    {
        if (transform.parent != null)
        {
            transform.parent = null;
        }
        body2d.velocity = initialDir.normalized * initialSpeed;
    }

    void Update()
    {
        /*if (body2d.velocity.y < Mathf.Epsilon)
        {
            body2d.velocity = new Vector2(body2d.velocity.x, 0.01f);
        }*/
    }
}
