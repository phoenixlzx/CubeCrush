using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Vector3 falldown = new Vector3(0, -100, 0);
    // private float speed = 20f;

    void Start()
    {
        transform.Rotate(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90), Space.World);
    }

    void Update()
    {
        // transform.position += falldown * Time.deltaTime * speed;
    }
}
