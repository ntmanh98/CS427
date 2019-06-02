using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    private Background[,] allTiles;
    // Start is called before the first frame update
    void Start()
    {
        allTiles = new Background[width, height];
        SetUp();
    }

    private void SetUp()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);
                GameObject background = Instantiate(tilePrefab, tempPosition , Quaternion.identity);
                background.transform.parent = this.transform;
                background.name = "(" + i + ", " + j + ")";
            }
        }
    }




    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
