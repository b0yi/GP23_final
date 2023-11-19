using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOfFlow : MonoBehaviour
{
    public float waterFlowForce = 2f;
    public float drag = 1.5f;
    public GameObject itemCanvas;

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
        other.GetComponent<Rigidbody2D>().drag = drag;
        if (other.name == "Player") {
            if (itemCanvas != null) {
                itemCanvas.SetActive(true);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ApplyForces(other.GetComponent<Rigidbody2D>());
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().drag = 0;
        if (other.name == "Player") {
            if (itemCanvas != null) {
                itemCanvas.SetActive(false);
            }
        }
    }

    void ApplyForces(Rigidbody2D rb) {
        // 向心力方向
        Vector2 centripetalDirection = (Vector2)transform.position - rb.position;
        // 離心力方向
        Vector2 direction = -centripetalDirection.normalized;

        if (centripetalDirection.magnitude >= 3f) {
            // 距離圓心夠大才對物體施旋轉力
            // 向心力
            float centripetalForceMagnitude = rb.mass * Mathf.Pow(rb.velocity.magnitude, 2) / centripetalDirection.magnitude;
            rb.AddForce(centripetalDirection.normalized * centripetalForceMagnitude);
            // 旋轉力(垂直離心力方向)
            Vector2 spinForce = new Vector2(-direction.y, direction.x) * waterFlowForce;
            rb.AddForce(spinForce);
        }
    }
}
