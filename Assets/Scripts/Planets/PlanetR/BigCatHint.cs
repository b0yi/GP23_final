using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCatHint : MonoBehaviour
{
    public NiceValueUI niceValueUI;
    public CanvasGroup canvasGroup;
    [DisplayOnly] public bool isFinished;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup.alpha = 0f;
        isFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player") {
            if (!niceValueUI.isFull()) {
                StartCoroutine(FadeSubtitleCanvas(0, 1f, 0.5f));
            }
            else {
                isFinished = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player") {
            if (niceValueUI.isFull() && !isFinished) {
                isFinished = true;
                StartCoroutine(FadeSubtitleCanvas(1f, 0, 0.5f));
            }
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player") {
            if (!niceValueUI.isFull()) {
                StartCoroutine(FadeSubtitleCanvas(1f, 0, 0.5f));
            }
        }
    }

    public IEnumerator FadeSubtitleCanvas(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha; // Ensure the final alpha value is set
    }
}
