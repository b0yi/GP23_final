using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeLoadScene : MonoBehaviour
{
    private UIManager _uIManager;
    public PlayerController_new player;
    bool loadscene=false;
    bool endscene=false;
    float _loadscenetime = 2.0f;
    float _loadendscenetime = 1.0f;
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
            player.Lock();
            _loadscenetime-= Time.deltaTime;
            //print(_loadscenetime);
            if(_loadscenetime<0)
                _uIManager.LoadPlayScene();
        }
        if(endscene)
        {
            _loadendscenetime-=Time.deltaTime;
            if(_loadendscenetime<0)
                _uIManager.LoadEndScene();
        }
    }

     void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (_uIManager)
            //{
                loadscene=true;
                // _loadscenetime-= Time.deltaTime;
                // print(_loadscenetime);
                // if(_loadscenetime<0)
                //     _uIManager.LoadPlayScene();
            //}

        }
        if (other.name == "Dragon")
        {
            if (_uIManager)
                endscene=true;

        }
    }
}
