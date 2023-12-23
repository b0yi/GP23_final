using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITask : MonoBehaviour
{
    public RectTransform container; // 160x60 (x=0, hide; x=-160, hide)
    public TextMeshProUGUI title;
    public TextMeshProUGUI content;
    public bool show;
    public float speed;

    void Start()
    {
        if (container == null)
            container = GetComponent<RectTransform>();
        Hide();
    }

    void Update()
    {
        if (show) {
            container.anchoredPosition -= new Vector2(Time.deltaTime * speed, 0f);
            if (container.anchoredPosition.x <= -160f)
                container.anchoredPosition = new Vector2(-160f, container.anchoredPosition.y);
        }
        else {
            container.anchoredPosition += new Vector2(Time.deltaTime * speed, 0f);
            if (container.anchoredPosition.x >= 0)
                container.anchoredPosition = new Vector2(0f, container.anchoredPosition.y);
        }
    }

    public void Show() {
        show = true;
    }

    public void Hide() {
        show = false;
    }

    public bool IsShowed() {
        return show;
    }

    public void ChangeTitle(string newTitle) {
        title.text = newTitle;
    }

    public void ChangeContent(string newContent) {
        content.text = newContent;
    }

}
