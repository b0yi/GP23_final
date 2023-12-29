using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SteleSubtitle : Subtitle
{
    public PreviewPlanet preview;
    private StageManager _stageManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject m = GameObject.FindWithTag("UIManager");
        _stageManager = m.GetComponent<StageManager>();

        player = GameObject.Find("Player").GetComponent<PlayerController_new>();
        talkManager = GameObject.FindWithTag("UIManager").GetComponent<TalkManager>();
        
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        textArea = canvas.transform.Find("SubtitleText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Talk()
    {
        if (talkManager.currentSubtitle == subtitleID) {
            if (!canvas.isLockingSubtitle) {
                StartCoroutine(ShowSubtitle(talkManager.subtitles[talkManager.currentSubtitle]));
                talkManager.currentSubtitle += 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _stageManager.stage == Stage.OnOriginPlanet) {
            Talk();
        }
    }

    public override IEnumerator ShowSubtitle(List<string> subtitles)
    {
        player.Lock();
        // player.Freeze();
        _stageManager.UpdateStage();
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
            dispText = "";
            textArea.text = "";
            isEnterDown = false;
            StartCoroutine(WaitForSkip());

            foreach (char c in subtitles[i])
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

            // yield return new WaitForSeconds(talkManager.delayTime);
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            yield return null;
        }

        yield return FadeCanvasGroup(1f, 0, 1f);

        preview.PlayCatPlanetPreview();

        canvas.isTalking = false;
        canvas.isLockingSubtitle = false;
        player.Unlock();
        // player.Unfreeze();
        _stageManager.UpdateStage();

    }
}
