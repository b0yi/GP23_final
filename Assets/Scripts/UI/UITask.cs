using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UITask : MonoBehaviour
{
    public RectTransform container;
    public TextMeshProUGUI title;
    public TextMeshProUGUI content;

    public float showTime;
    public float centerTime;
    public float moveCornerTime;
    public float hideTime;

    public Vector2 centerPosition = new Vector2(0f, 0f);
    public Vector2 cornerPosition = new Vector2(300f, 170f);
    public Vector2 hidePosition = new Vector2(500f, 170f);

    public Vector2 fromPosition;
    public Vector2 toPosition;

    public float duration;
    public float t, s;
    public bool show;

    public event Action AfterShow;

    void Start()
    {
        if (container == null)
            container = GetComponent<RectTransform>();
        
        // 立即藏起來
        container.anchoredPosition = hidePosition;
        fromPosition = hidePosition;
        toPosition = hidePosition;
        t = 1f;
    }

    void Update()
    {
        if (t >= 1f) {
            // complete
            if (toPosition == cornerPosition) {
                if (AfterShow != null) {
                    AfterShow();
                }
            }
        }

        t += Time.deltaTime / duration;
        container.anchoredPosition =  Vector2.Lerp(fromPosition, toPosition, t);
        

        if (s >= 1f) {
            // complete
        }
        s += Time.deltaTime / showTime;
        container.localScale = new Vector3(Mathf.Lerp(0f, 1f, s), Mathf.Lerp(0f, 1f, s), 1f);
    }

    public bool Show() {
        if (show)
            return false;

        show = true;
        container.localScale = new Vector3(0f, 0f, 1f);
        // 立即置中
        container.anchoredPosition = centerPosition;
        fromPosition = centerPosition;
        toPosition = centerPosition;
        t = 1f;
        s = 0f;
        Invoke("MoveCorner", centerTime);

        return true;
    }

    private void MoveCorner() {
        fromPosition = centerPosition;
        toPosition = cornerPosition;
        duration = moveCornerTime;
        t = 0f;
    }

    public bool Hide() {
        if (!show)
            return false;
        
        show = false;
        fromPosition = cornerPosition;
        toPosition = hidePosition;
        duration = hideTime;
        t = 0f;

        return true;
    }

    // public bool IsShowed() {
    //     return show;
    // }

    public void ChangeTitle(string newTitle) {
        title.text = newTitle;
    }

    public void ChangeContent(string newContent) {
        content.text = newContent;
    }

}
