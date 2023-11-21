using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOfFlow : MonoBehaviour
{
    public float waterFlowForce = 3f;
    public float drag = 2f;
    public GameObject itemCanvas;
    
    private float playerBeforeDrag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            playerBeforeDrag = other.GetComponent<Rigidbody2D>().drag;
            if (itemCanvas != null) {
                itemCanvas.SetActive(true);
            }
        }
        other.GetComponent<Rigidbody2D>().drag = drag;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ApplyForces(other.GetComponent<Rigidbody2D>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            other.GetComponent<Rigidbody2D>().drag = playerBeforeDrag;
            if (itemCanvas != null) {
                itemCanvas.SetActive(false);
            }
        }
        else {
            other.GetComponent<Rigidbody2D>().drag = 1;
        }
    }

    void ApplyForces(Rigidbody2D rb) {
        // 向心力方向
        Vector2 centripetalDirection = (Vector2)transform.position - rb.position;
        // 離心力方向
        Vector2 direction = -centripetalDirection.normalized;

        if (centripetalDirection.magnitude >= 2.5f) {
            // 距離圓心夠大才對物體施旋轉力
            // 向心力
            Vector2 speed = rb.velocity * Mathf.Sin(Vector2.Angle(direction, rb.velocity));
            float centripetalForceMagnitude = rb.mass * Mathf.Pow(speed.magnitude, 2) / centripetalDirection.magnitude;
            rb.AddForce(centripetalDirection.normalized * centripetalForceMagnitude);
            // 旋轉力(垂直離心力方向)
            Vector2 spinForce = new Vector2(-direction.y, direction.x) * waterFlowForce;
            rb.AddForce(spinForce * rb.mass);
        }
    }
}
