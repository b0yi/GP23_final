using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeLoadScene : MonoBehaviour
{
    private UIManager _uIManager;
    bool loadscene=false;
    float _loadscenetime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        _uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(loadscene)
        {
            _loadscenetime-= Time.deltaTime;
            print(_loadscenetime);
            if(_loadscenetime<0)
                _uIManager.LoadPlayScene();
        }

    }

     void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (_uIManager)
            {
                loadscene=true;
                // _loadscenetime-= Time.deltaTime;
                // print(_loadscenetime);
                // if(_loadscenetime<0)
                //     _uIManager.LoadPlayScene();
            }

        }

    }
}
