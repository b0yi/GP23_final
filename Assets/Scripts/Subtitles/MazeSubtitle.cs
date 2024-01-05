using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MazeSubtitle : Subtitle
{
    [DisplayOnly] public bool beforeFall;
    [DisplayOnly] public bool afterFall;
    public float waitTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController_new>();
        talkManager = GameObject.FindWithTag("UIManager").GetComponent<TalkManager>();
        
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        textArea = canvas.transform.Find("SubtitleText").GetComponent<TextMeshProUGUI>();
        enterSkipHint = canvas.transform.Find("Images").gameObject;

        beforeFall = false;
        afterFall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player" && talkManager.nextSubtitle == SubtitleStage.outsideMaze) {
            if (!beforeFall) {
                beforeFall = true;
                Talk();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player" && talkManager.nextSubtitle == SubtitleStage.enterMaze) {
            if (!afterFall) {
                afterFall = true;
                Talk();
            }
        }
    }

    public override void Talk()
    {
        if (talkManager.nextSubtitle == subtitleID) {
            StartCoroutine(ShowSubtitle(talkManager.subtitles[(int)talkManager.nextSubtitle]));
            talkManager.nextSubtitle += 1;
        }
    }

    public override IEnumerator ShowSubtitle(List<string> subtitles)
    {
        canvas.isLockingSubtitle = true;

        yield return new WaitForSeconds(waitTime);

        canvas.isTalking = true;
        textArea.text = "";

        string dispText = "";
        string richText = "";
        bool recording = false;

        enterSkipHint.SetActive(false);
        yield return FadeSubtitleCanvas(0, 1f, 1f);

        float showCharTime = 1f / talkManager.charPerSec;
        for (int i = 0; i < subtitles.Count; i++) 
        {
            dispText = "";
            textArea.text = "";
            isEnterDown = false;
            StartCoroutine(WaitForSkip());
            enterSkipHint.SetActive(false);

            foreach (char c in subtitles[i]) {
                if (isEnterDown) {
                    dispText = subtitles[i];
                    textArea.text = dispText;
                    break;
                }
                
                if (c == '<') {
                    recording = true;
                }
                else if (c == '>') {
                    recording = false;
                }

                if (recording) {
                    richText += c;
                    continue;
                }
                else {
                    if (c == '>') {
                        dispText += richText + c;
                        richText = "";
                        textArea.text = dispText;
                    }
                    else {
                        dispText += c;
                        textArea.text = dispText;
                        if (c != ' ') yield return new WaitForSeconds(showCharTime);
                    }
                }
            }

            yield return new WaitForSeconds(talkManager.delayTime);
            // yield return null;
            // yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            // yield return null;
        }

        yield return FadeSubtitleCanvas(1f, 0, 1f);

        canvas.isTalking = false;
        canvas.isLockingSubtitle = false;
    }
}
