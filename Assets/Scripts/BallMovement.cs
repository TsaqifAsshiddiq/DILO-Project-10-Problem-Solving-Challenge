using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnController spawnController;

    private float xRange = 9.0f;
    private float yRange = 3.5f;
    public float speed = 10.0f;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AreaLock();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        FollowObject(mousePosition);
    }

    void FollowObject(Vector2 objPos)
    {
        transform.position = Vector2.MoveTowards(transform.position, objPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore();
            spawnController.currentItem--;
            StartCoroutine(SpawnCountdown());
        }
    }

    private void AreaLock()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        else if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
    }

    IEnumerator SpawnCountdown()
    {
        yield return new WaitForSeconds(3);
        spawnController.SpawnBox();
    }
}