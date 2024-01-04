using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerDead : MonoBehaviour
{
    private UIManager uIManager;
    public AnimationCurve animationCurve;
    private CanvasGroup bgCanvasGroup;
    private CanvasGroup wordCanvasGroup;
    private TextMeshProUGUI textMeshPro;
    private TalkManager talkManager;

    public float fadeTime = 2f;
    public float wordTime = 1f;
    public float wordWaitTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        bgCanvasGroup = transform.Find("DeadBG").GetComponent<CanvasGroup>();
        wordCanvasGroup = transform.Find("DeadWord").GetComponent<CanvasGroup>();
        textMeshPro = transform.Find("DeadWord").Find("HintText").GetComponent<TextMeshProUGUI>();
        talkManager = uIManager.GetComponent<TalkManager>();

        if (animationCurve.length == 0)
        {
            Debug.Log("Animation curve not assigned: Create a default animation curve");
            animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator FadeUICanvas(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
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

    public void FadePlayerDeadCanvas(int deadString) {
        StartCoroutine(ShowDeadCanvas(deadString));
    }

    public IEnumerator ShowDeadCanvas(int deadString) {
        Debug.Log("start dead bg");
        yield return FadeUICanvas(bgCanvasGroup, 0f, 1f, fadeTime);
        Debug.Log("show dead word");
        textMeshPro.text = talkManager.deadSubtitle[deadString];
        yield return FadeUICanvas(wordCanvasGroup, 0f, 1f, wordTime);
        yield return new WaitForSeconds(wordWaitTime);
        Debug.Log("hide dead word");
        yield return FadeUICanvas(wordCanvasGroup, 1f, 0f, wordTime);
        Debug.Log("start load play");
        uIManager.LoadPlayScene();
    }
}
