using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startSpawnTime;
    private float spawnTime;
    public float spawnTime2;
    public int startSpawnTime2;
    public GameObject coin;
        
    // Start is called before the first frame update
    void Start()
    {
        startSpawnTime2 = Random.Range(1, 7);
        spawnTime2 = startSpawnTime2;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime <= 0)
        {
            Instantiate(coin, new Vector3(6f, 1f, 0f), Quaternion.identity);
            spawnTime = startSpawnTime;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }

        if(spawnTime2 <= 0 )
        {
            Instantiate(coin, new Vector3(6f, 1f, 0f), Quaternion.identity);
            startSpawnTime2 = Random.Range(1, 7);
            spawnTime2 = startSpawnTime2;
        }
        else
        {
            spawnTime2 -= Time.deltaTime;
        }
    }
}
