using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public SubtitleCanvas canvas;
    protected CanvasGroup canvasGroup;
    protected TextMeshProUGUI textArea;

    protected PlayerController_new player;
    protected TalkManager talkManager;

    public float talkRange = 0f;
    public float subtitleID = 0f;

    [DisplayOnly] public bool isEnterDown = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController_new>();
        talkManager = GameObject.FindWithTag("UIManager").GetComponent<TalkManager>();

        canvasGroup = canvas.GetComponent<CanvasGroup>();
        textArea = canvas.transform.Find("SubtitleText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Talk() {
        if (IsPlayerInRange(talkRange)) {
            if (talkManager.currentSubtitle == subtitleID) {
                if (!canvas.isLockingSubtitle) {
                    StartCoroutine(ShowSubtitle(talkManager.subtitles[talkManager.currentSubtitle]));
                    talkManager.currentSubtitle += 1;
                }
            }
        }
    }

    protected bool IsPlayerInRange(float rangeToDetect)
    {
        Vector3 playerPos = player.transform.position;
        float distance = (playerPos - transform.position).magnitude;

        if (distance <= rangeToDetect / 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual IEnumerator ShowSubtitle(List<string> subtitles)
    {
        player.Lock();
        player.Freeze();
        canvas.isLockingSubtitle = true;
        canvas.isTalking = true;
        textArea.text = "";

        yield return FadeCanvasGroup(0, 1f, 1f);

        float showCharTime = 1f / talkManager.charPerSec;
        for (int i = 0; i < subtitles.Count; i++)
        {
            string[] nameAndWord = subtitles[i].Split(": ");
            string dispText = nameAndWord[0] + ": ";

            textArea.text = "";
            isEnterDown = false;
            StartCoroutine(WaitForSkip());

            foreach (char c in nameAndWord[1])
            {
                if (isEnterDown) {
                    dispText = subtitles[i];
                    textArea.text = dispText;
                    break;
                }

                dispText += c;
                textArea.text = dispText;
                yield return new WaitForSeconds(showCharTime);
            }

            // yield return new WaitForSeconds(talkManager.delayTime);
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            yield return null;
        }

        yield return FadeCanvasGroup(1f, 0, 1f);

        canvas.isTalking = false;
        canvas.isLockingSubtitle = false;
        player.Unlock();
        player.Unfreeze();
    }

    public IEnumerator WaitForSkip() {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        isEnterDown = true;
    }

    public IEnumerator FadeCanvasGroup(float startAlpha, float endAlpha, float duration)
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
