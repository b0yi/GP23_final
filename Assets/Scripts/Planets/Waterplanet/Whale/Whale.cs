using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public Transform waterPlanetTF;
    public Transform playerTF;
    public float radius;
    public float shift = 0;
    private float timeCounter;
    public bool attack;
    public float attackSpeed;
    private UIManager _uIManager;

    // Start is called before the first frame update
    void Start()
    {
        _uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();

        timeCounter = shift;
    }

    public void Attack()
    {
        attack = true;
    }

    public void Unattack()
    {
        attack = false;
    }

    void Update()
    {
        if (attack)
        {
            transform.position += (playerTF.position - transform.position).normalized * Time.deltaTime * attackSpeed;
            transform.rotation = Quaternion.FromToRotation(transform.right, playerTF.position - transform.position);
        }
        else
        {
            timeCounter += Time.deltaTime;
            float x = radius * Mathf.Cos(timeCounter) + waterPlanetTF.position.x;
            float y = radius * Mathf.Sin(timeCounter) + waterPlanetTF.position.y;
            float z = 0;
            transform.SetPositionAndRotation(new Vector3(x, y, z), Quaternion.Euler(0f, 0f, timeCounter * 180f / Mathf.PI + 90f));

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (_uIManager)
            {
                _uIManager.LoadPlayScene();
            }

        }

    }

}
