using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName;
    public GameObject canGetItemRange;
    public GameObject itemCanvas;
    public ItemCanvasHandler itemCanvasHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenItemGetCanvas(string itemName) {
        itemCanvasHandler.OpenItemGetCanvas(itemName);
    }

    public virtual void ItemReset() {
        // Reset the item's state
        Debug.Log("Reset the item!");
    }

    public virtual void ShowItemCanvas() {
        itemCanvas.SetActive(true);
    }

    public virtual void CloseItemCanvas() {
        itemCanvas.SetActive(false);
    }
}
