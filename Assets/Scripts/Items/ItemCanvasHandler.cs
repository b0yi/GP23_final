using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCanvasHandler : MonoBehaviour
{
    public GameObject itemGetCanvas;

    // Start is called before the first frame update
    void Start()
    {
        itemGetCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenItemGetCanvas(string itemName) {
        itemGetCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Congradulations!\nYou got \"" + itemName + "\"!";
        itemGetCanvas.SetActive(true);
        Debug.Log("Open item get canvas!");
        StartCoroutine(CloseItemGetCanvas());
    }

    private IEnumerator CloseItemGetCanvas() {
        yield return new WaitForSeconds(2f);
        itemGetCanvas.SetActive(false);
        Debug.Log("Closed item get canvas!");
    }
}
