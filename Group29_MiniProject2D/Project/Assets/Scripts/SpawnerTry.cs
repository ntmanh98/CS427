using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTry : MonoBehaviour
{
    public GameObject gold, silver, ice;
    public float spawnRate = 2f;
    float nextSpawn = 0f;
    int whatToSpawn;
    // Start is called before the first frame update


    // Use this for initialization
    /*void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //moveAngle = new Vector2(Random.Range(-500f, -250f), Random.Range(250f, 500f));
        moveAngle = new Vector2(Random.Range(-200f, -100f), Random.Range(250f, 500f));
        rb.AddForce(moveAngle, ForceMode2D.Force);
        deadTime = 0.5f;
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 3);
            Debug.Log(whatToSpawn);
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(gold.gameObject, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(silver.gameObject, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(ice.gameObject, transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }
}
