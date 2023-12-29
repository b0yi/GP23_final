using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerFuel_new : MonoBehaviour
{
    private Image _image;
    //public GameObject full;

    public GameObject player;
    public Animator animator;
    private PlayerController_new _playerPC;
    private float _min;
    private float _max;


    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _playerPC = player.GetComponent<PlayerController_new>();
        _min = 0;
        _max = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        float fillAmount = _playerPC.fuel / (_max - _min);
        float alignedFillAmount = Mathf.Round(fillAmount / 0.03125f) * 0.03125f;
        _image.fillAmount = alignedFillAmount;

        if (_playerPC.fuel < 10f)
        {
            _image.color = new Color(255f, 0f, 0f, 1f); 
            animator.SetBool("lowbattery", true);
        }
        else
        {
            _image.color = new Color(0f, 255f, 235f, 1f);
            animator.SetBool("lowbattery", false);
        }
    }
}
