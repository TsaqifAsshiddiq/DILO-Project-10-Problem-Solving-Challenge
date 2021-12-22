using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D ballRb;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            PushBall(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PushBall(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PushBall(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PushBall(Vector2.left);
        }
    }

    void PushBall(Vector2 direction)
    {
        ballRb.AddForce(direction * speed);
    }
}