using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaterForce : MonoBehaviour
{

    // [DisplayOnly] public bool isPlayerInWater;
    public float linearDragInWater;
    public float angularDragInWater;
    
    public GameObject whaleItemUI;

    public Whale[] whales;

    [DisplayOnly] public float linearDrag;
    [DisplayOnly] public float angularDrag;

    // public float idleTime = 2f;
    // [DisplayOnly] public float idleTimer = 0f;


    private Rigidbody2D _playerRB;
    // private Transform _playerTF;

    // public float acceleration;

    public float radius = 56.21403f;

    void Start()
    {
        // isPlayerInWater = false;
        // idleTimer = idleTime;
        whaleItemUI.SetActive(false);
    }

    void Update()
    {
        // if (isPlayerInWater)
        // {
            //Vector2 forceDirection = (Vector2)(_playerTF.position - transform.position).normalized;
            //float magnitude = (_playerTF.position - transform.position).magnitude / radius;
            //_playerRB.AddForce(acceleration / magnitude * _playerRB.mass * forceDirection); // F = m a

            // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) // TODO: 之後改寫
            // {
            //     idleTimer = idleTime;
            // }
            // else
            // {
            //     idleTimer -= Time.deltaTime;
            //     if (idleTimer <= 0f)
            //     {
            //         Vector2 forceDirection = ((Vector2)(_playerTF.position - transform.position)).normalized;
            //         _playerRB.AddForce(acceleration * _playerRB.mass * forceDirection); // F = m a
            //     }
            // }
        // }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            whaleItemUI.SetActive(true);
            // isPlayerInWater = true;
            // _playerTF = collider.transform;
            _playerRB = collider.GetComponent<Rigidbody2D>();
            linearDrag = _playerRB.drag;
            angularDrag = _playerRB.angularDrag;
            _playerRB.drag = linearDragInWater;
            _playerRB.angularDrag = angularDragInWater;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            whaleItemUI.SetActive(false);
            // isPlayerInWater = false;
            for (int i = 0; i < whales.Length; ++i) {
                whales[i].Unattack();
            }
            _playerRB.drag = linearDrag;
            _playerRB.angularDrag = angularDrag;

        }

    }

}
