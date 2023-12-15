using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public Transform waterPlanetTF;
    public float radius;
    public float shift = 0;
    private float timeCounter;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = shift;
    }


    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        float x = radius * Mathf.Cos(timeCounter) + waterPlanetTF.position.x;
        float y = radius * Mathf.Sin(timeCounter) + waterPlanetTF.position.y;
        float z = 0;
        transform.SetPositionAndRotation(new Vector3(x, y, z), Quaternion.Euler(0f, 0f, timeCounter * 180f / Mathf.PI + 90f));
    }
}
