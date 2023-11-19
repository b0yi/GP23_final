using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetOfCalibration : MonoBehaviour
{
    public GameObject itemCanvas;
    [SerializeField]
    int itemLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseAndShow() {
        itemLeft--;
        itemCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Left click to start/stop the needle\n"+itemLeft+" more to go";
    }
}
