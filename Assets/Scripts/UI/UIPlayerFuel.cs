using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerFuel : MonoBehaviour
{
    private Image _image;

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
        _image.fillAmount = _playerPC.fuel * .51f / (_max - _min);
    }
}
