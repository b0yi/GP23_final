using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NiceValueUI : MonoBehaviour
{    
    private Image _image;
    [Tooltip("Float 0 ~ 1")] public float delta = 0.1f;
    public GameObject bigCat;
    private StageManager _stageManager;

    void Start()
    {
        GameObject m = GameObject.FindWithTag("UIManager");
        _stageManager = m.GetComponent<StageManager>();


        _image = GetComponent<Image>();
        Reset();
        if (bigCat == null) {
            Debug.LogError("No big cat assigned to nice UI.");
        }
    }

    void Update()
    {
        if (isFull()) {
            bigCat.SetActive(true);
            transform.parent.gameObject.SetActive(false);

            if (_stageManager.stage == Stage.Kitten) {
                _stageManager.UpdateStage();
            }
        }
    }

    public void Increase() {
        _image.fillAmount += delta;
    }

    public void Reset() {
        _image.fillAmount = 0f;
    }

    public bool isFull() {
        return _image.fillAmount == 1f;
    }

}
