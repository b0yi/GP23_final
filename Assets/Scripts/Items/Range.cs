using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            if (transform.parent.name == "ClickingItem") {
                transform.parent.GetComponent<ClickingItem>().ShowItemCanvas();
                transform.parent.GetComponent<Item>().isPlayerInRange = true;
            }
            else if (transform.parent.name == "CalibrationItem") {
                transform.parent.GetComponent<CalibrationItem>().ShowItemCanvas();
                transform.parent.GetComponent<Item>().isPlayerInRange = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            if (transform.parent.name == "ClickingItem") {
                transform.parent.GetComponent<ClickingItem>().CloseItemCanvas();
                transform.parent.GetComponent<Item>().isPlayerInRange = false;
            }
            else if (transform.parent.name == "CalibrationItem") {
                transform.parent.GetComponent<CalibrationItem>().CloseItemCanvas();
                transform.parent.GetComponent<Item>().isPlayerInRange = false;
            }
        }
    }
}
