using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MazeSubtitle : Subtitle
{
    [DisplayOnly] public bool beforeFall;
    [DisplayOnly] public bool afterFall;
    public float bFWaitTime = 3f;
    public float aFWaitTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController_new>();
        talkManager = GameObject.FindWithTag("UIManager").GetComponent<TalkManager>();
        
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        textArea = canvas.transform.Find("SubtitleText").GetComponent<TextMeshProUGUI>();

        beforeFall = false;
        afterFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player" && talkManager.currentSubtitle == subtitleID) {
            if (!beforeFall) {
                beforeFall = true;
                Talk();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && talkManager.currentSubtitle == subtitleID) {
            if (!afterFall) {
                afterFall = true;
                Talk();
            }
        }
    }

    public override void Talk()
    {
        if (talkManager.currentSubtitle == subtitleID) {
            StopCoroutine(nameof(ShowSubtitle));
            StartCoroutine(ShowSubtitle(talkManager.subtitles[talkManager.currentSubtitle]));
            talkManager.currentSubtitle += 1;
        }
    }

    public override IEnumerator ShowSubtitle(List<string> subtitles)
    {
        canvas.isLockingSubtitle = true;

        if (talkManager.currentSubtitle == 3) {
            yield return new WaitForSeconds(bFWaitTime);
        }
        else {
            yield return new WaitForSeconds(aFWaitTime);
        }

        canvas.isTalking = true;

        float showCharTime = 1f / talkManager.charPerSec;
        for (int i = 0; i < subtitles.Count; i++) {
            string dispText = "";

            // isEnterDown = false;
            // StartCoroutine(WaitForSkip());

            foreach (char c in subtitles[i]) {
                // if (isEnterDown) {
                //     isEnterDown = false;
                //     dispText = subtitles[i];
                //     textArea.text = dispText;
                //     break;
                // }
                
                dispText += c;
                textArea.text = dispText;
                yield return new WaitForSeconds(showCharTime);
            }

            yield return new WaitForSeconds(talkManager.delayTime);
            // yield return null;
            // yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            // yield return null;
            textArea.text = "";
        }

        canvas.isTalking = false;
        canvas.isLockingSubtitle = false;
    }
}
