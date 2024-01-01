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

    public float showTime;
    public float centerTime;
    public float moveCornerTime;
    public float hideTime;

    public Vector2 centerPosition = new Vector2(0f, 0f);
    public Vector2 cornerPosition = new Vector2(300f, 170f);
    public Vector2 hidePosition = new Vector2(480f, 170f);

    private Vector2 position;
    private float duration;
    public bool show;

    void Start()
    {
        if (container == null)
            container = GetComponent<RectTransform>();
        
        // 立即藏起來
        container.anchoredPosition = hidePosition;
        position = hidePosition;
    }

    void Update()
    {
        float t = Time.deltaTime / duration;
        container.anchoredPosition =  Vector2.Lerp(container.anchoredPosition, position, t);

        float s = Time.deltaTime / showTime;
        container.localScale = new Vector3(Mathf.Lerp(container.localScale.x, 1f, showTime), Mathf.Lerp(container.localScale.x, 1f, showTime), 1f);
    }

    public void Show() {
        show = true;
        container.localScale = new Vector3(0f, 0f, 1f);
        // 立即置中
        container.anchoredPosition = centerPosition;
        position = centerPosition;
        Invoke("MoveCorner", centerTime);
    }

    private void MoveCorner() {
        print("corner");
        position = cornerPosition;
        duration = moveCornerTime;
    }

    public void Hide() {
        show = false;
        position = hidePosition;
        duration = hideTime;
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
