using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject ballObj;
    public GameObject boxPrefabs;
    private float spawnRangeX = 9.0f;
    private float spawnRangeY = 3.5f;
    public int maxItem = 10;
    public int currentItem = 0;

    // Start is called before the first frame update
    void Start()
    {
        StarterBox();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBox()
    {
        Vector2 ballPosition = new Vector2(ballObj.transform.position.x, ballObj.transform.position.y);
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
        while(spawnPos == ballPosition)
        {
            spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
        }
        Instantiate(boxPrefabs, spawnPos, boxPrefabs.transform.rotation);
        currentItem++;
    }

    public void StarterBox()
    {
        for (int i = 0; i < maxItem; i++)
        {
            SpawnBox();
        }
    }
}
