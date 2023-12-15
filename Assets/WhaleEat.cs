using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleEat : MonoBehaviour
{
    private UIManager _uIManager;

    void Start()
    {
        _uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();

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
