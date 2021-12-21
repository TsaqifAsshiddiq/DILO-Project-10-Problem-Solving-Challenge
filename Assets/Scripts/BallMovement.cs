using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D ballRb;
    public float speed = 30.0f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        PushBall();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PushBall()
    {
        ballRb.AddForce(direction * speed);
    }
}