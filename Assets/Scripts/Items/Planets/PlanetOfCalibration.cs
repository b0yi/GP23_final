using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetOfCalibration : MonoBehaviour
{
    public GameObject itemCanvas;
    [SerializeField][DisplayOnly]
    int itemLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DecreaseCanvasNum() {
        itemLeft--;
        itemCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Left click to start/stop the needle\n"+itemLeft+" more to go";
        if (itemLeft > 0) {
            // still item left
            return false;
        }
        else {
            // no item left
            return true;
        }
    }
}
