using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject boxPrefabs;
    private float spawnRangeX = 9.0f;
    private float spawnRangeY = 3.5f;
    public int maxItem = 10;
    private int currentItem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentItem < maxItem)
        {
            SpawnBox();
        }
    }

    void SpawnBox()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
        Instantiate(boxPrefabs, spawnPos, boxPrefabs.transform.rotation);
        currentItem ++;
    }
}
