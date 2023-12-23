using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NiceValueUI : MonoBehaviour
{    
    
    private Image _image;
    public float delta = 10f;

    void Start()
    {
        _image = GetComponent<Image>();
        Reset();
    }

    public void Increase() {
        _image.fillAmount += 10f;
    }

    public void Reset() {
        _image.fillAmount = 0f;
    }

    public bool isFull() {
        return (_image.fillAmount == 100f);
    }

}
