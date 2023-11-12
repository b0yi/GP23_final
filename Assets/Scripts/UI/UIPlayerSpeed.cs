using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerSpeed : MonoBehaviour
{
    private Image _image;

    public GameObject player;
    private Rigidbody2D _playerRB;
    private PlayerController _playerPC;
    private float _min;
    private float _max;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _playerRB = player.GetComponent<Rigidbody2D>();
        _playerPC = player.GetComponent<PlayerController>();
        _min = 0;
        _max = _playerPC.maxDriveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _image.fillAmount = _playerRB.velocity.magnitude * .51f / (_max - _min);
    }
}
