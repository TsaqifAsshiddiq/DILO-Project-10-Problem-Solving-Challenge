using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnController spawnController;

    public float speed = 10.0f;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

    IEnumerator SpawnCountdown()
    {
        yield return new WaitForSeconds(3);
        spawnController.SpawnBox();
    }
}