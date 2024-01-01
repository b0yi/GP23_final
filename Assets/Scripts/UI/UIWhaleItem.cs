using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWhaleItem : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    public int count;
    public int total;

    public void Increase() {
        count += 1;
        textUI.text = count.ToString() + "/" + total.ToString();
        if (count >= total) {
            Invoke("ChangeColor", 0.5f);
        }
    }

    private void ChangeColor() {
        print("test");
        textUI.color = new Color32(255, 255, 255, 255);
    }

    void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        count = 0;
        textUI.text = count.ToString() + "/" + total.ToString();
        textUI.color = new Color32(200, 200, 200, 255);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            Increase();
        }
    }

}
