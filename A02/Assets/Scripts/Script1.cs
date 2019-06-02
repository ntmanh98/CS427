using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    public Vector2 newPos;
    // Start is called before the first frame update
    void Start()
    {
        newPos = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //FPS: Frame per second. 60fps: 1s - 60 frame   
        GetComponent<Transform>().position = newPos;
        Debug.Log(newPos);

    }
}
