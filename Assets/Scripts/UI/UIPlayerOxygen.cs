using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerOxygen : MonoBehaviour
{
    private Image _image;
    //public GameObject full;

    public GameObject player;
    public Animator animator;
    private PlayerController_new _playerPC;
    private float _min;
    private float _max;

    //private float oxygennumber;
    private bool inWaterPlanet=false;

    private float fillAmount;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _playerPC = player.GetComponent<PlayerController_new>();
        _min = 0;
        _max = 100f;
        _playerPC.oxygennumber=100f;
    }

    // Update is called once per frame
    void Update()
    {
        
        //print(_playerPC.inWater());
        if (_playerPC.oxygennumber < 30f)
        {
            _image.color = new Color(255f, 0f, 0f, 1f); 
            animator.SetBool("lowbattery", true);
        }
        else
        {
            _image.color = new Color(0f, 255f, 235f, 1f);
            animator.SetBool("lowbattery", false);
        }
        if(_playerPC.inWater())
        {
            _playerPC.oxygennumber-=0.1125f;
            print(fillAmount);
        }
        else
        {
            _playerPC.oxygennumber=100f;
        }

        fillAmount = _playerPC.oxygennumber / (_max - _min);
        float alignedFillAmount = Mathf.Round(fillAmount / 0.03125f) * 0.03125f;
        _image.fillAmount = alignedFillAmount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Water Planet")
            inWaterPlanet=true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name=="Water Planet")
        {
            inWaterPlanet=false;
            //oxygennumber=100f;
        }
    }
}
