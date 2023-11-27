using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float radius;
    public float frequency = 2f;
    public float speed;
    public float shift;
    public LayerMask layerMask;

    [DisplayOnly]
    public bool power;

    // Start is called before the first frame update
    void Start()
    {
        power = false;

        InvokeRepeating("Create", frequency, frequency);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject planet = GetComponent<PlayerController>().planet;
        if (Vector3.Distance(transform.position, planet.transform.position) > radius + planet.transform.lossyScale.x)
        {
            power = true;
        }
        else
        {
            power = false;
        }
    }

    void Create()
    {
        if (power)
        {
            // float angle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
            // Vector3 position = center + new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0f);
            // Vector3 direction = ((Vector2)(center - position)).normalized;
            Vector3 center = transform.position + transform.up * shift;
            Vector3 position = new Vector3(transform.position.x - 20f, transform.position.y, 0);
            GameObject o = Instantiate(obstaclePrefab, position, Quaternion.identity);
            Vector3 direction = transform.right;
            o.GetComponent<Rigidbody2D>().velocity = speed * direction;
        }
    }




}
