using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragonSubtitle : Subtitle
{
    public bool planet;
    public bool crystal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController_new>();
        talkManager = GameObject.FindWithTag("UIManager").GetComponent<TalkManager>();
        
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        textArea = canvas.transform.Find("SubtitleText").GetComponent<TextMeshProUGUI>();
        
        planet = false;
        crystal = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && talkManager.currentSubtitle == subtitleID) {
            planet = true;
            Talk();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Dragon Item" && talkManager.currentSubtitle == subtitleID) {
            crystal = true;
            Talk();
        }
    }

    public override void Talk()
    {
        if (talkManager.currentSubtitle == subtitleID) {
            StartCoroutine(ShowSubtitle(talkManager.subtitles[talkManager.currentSubtitle]));
            if (!crystal) {
                talkManager.currentSubtitle += 1;
            }
        }
    }

    public override IEnumerator ShowSubtitle(List<string> subtitles)
    {
        player.Lock();
        // player.Freeze();

        canvas.isLockingSubtitle = true;
        canvas.isTalking = true;
        textArea.text = "";

        string dispText = "";
        string richText = "";
        bool recording = false;

        yield return FadeCanvasGroup(0, 1f, 1f);

        float showCharTime = 1f / talkManager.charPerSec;
        for (int i = 0; i < subtitles.Count; i++)
        {
            string[] nameAndWord;
            string word = "";

            if (subtitles[i][2] == '-') {
                nameAndWord = subtitles[i].Split(": ");
                dispText = nameAndWord[0] + ": ";
                word = nameAndWord[1];
            }
            else {
                dispText = "";
                word = subtitles[i];
            }

            textArea.text = "";
            isEnterDown = false;
            StartCoroutine(WaitForSkip());

            foreach (char c in word)
            {
                if (isEnterDown) {
                    dispText = subtitles[i];
                    textArea.text = dispText;
                    break;
                }
                
                if (c == '<') {
                    recording = true;
                    richText += c;
                    continue;
                }
                else if (c == '>') {
                    recording = false;
                    richText += c;
                    continue;
                }

                if (recording) {
                    richText += c;
                }
                else {
                    dispText = dispText + richText + c;
                    richText = "";
                    textArea.text = dispText;
                    if (c != ' ') yield return new WaitForSeconds(showCharTime);
                }
            }

            if (planet) {
                yield return null;
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                yield return null;
            }
            if (crystal) {
                yield return new WaitForSeconds(talkManager.delayTime);
            }
        }

        yield return FadeCanvasGroup(1f, 0, 1f);

        canvas.isTalking = false;
        canvas.isLockingSubtitle = false;
        player.Unlock();
        // player.Unfreeze();
    }
}
