using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerFuel : MonoBehaviour
{
    private Image _image;
    //public GameObject full;

    public GameObject player;
    private PlayerController _playerPC;
    private float _min;
    private float _max;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _playerPC = player.GetComponent<PlayerController>();
        _min = 0;
        _max = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = _playerPC.fuel / (_max - _min);

        /*if (_playerPC.fuel > 95f)
        {
            full.SetActive(true);
        }
        else
        {
            full.SetActive(false);
        }*/

        if (_playerPC.fuel < 30f)
        {
            _image.color = Color.red;
        }
        else
        {
            _image.color = Color.black;
        }
    }
}
