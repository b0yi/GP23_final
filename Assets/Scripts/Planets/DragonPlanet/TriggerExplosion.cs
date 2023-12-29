using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using TMPro;
using System.Collections.Generic;

//[RequireComponent(typeof(Explodable))]
public class TriggerExplosion : Subtitle
{

    public Explodable explodable;
    [DisplayOnly] public float delayExplosionTimer;
    [DisplayOnly] bool explode;
    public float delayExplosionTime;
    public GameObject dragon;
    public GameObject sun;
    private StageManager _stageManager;

    private void Start()
    {
        GameObject m = GameObject.FindWithTag("UIManager");
        explode = false;
        dragon.SetActive(false);
        CinemachineShake.finalitem = true;
        _stageManager = m.GetComponent<StageManager>();

        // For subtitle
        player = GameObject.Find("Player").GetComponent<PlayerController_new>();
        talkManager = GameObject.FindWithTag("UIManager").GetComponent<TalkManager>();
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        textArea = canvas.transform.Find("SubtitleText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (explode)
        {
            delayExplosionTimer -= Time.deltaTime;

            if (delayExplosionTimer <= 0)
            {
                explodable.explode();
                player.Unlock();
                Destroy(gameObject);
                dragon.SetActive(true);
            }

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !explode)
        {
            Talk();
        }
    }

    public override void Talk()
    {
        if (!canvas.isLockingSubtitle) {
            if (talkManager.currentSubtitle == subtitleID) {
                StartCoroutine(ShowSubtitle(talkManager.subtitles[talkManager.currentSubtitle]));
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
            
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            yield return null;
        }

        yield return FadeCanvasGroup(1f, 0, 1f);

        canvas.isTalking = false;
        canvas.isLockingSubtitle = false;
        // player.Unlock();
        // player.Unfreeze();

        explode = true;
        delayExplosionTimer = delayExplosionTime;
        // player.Lock();
        player.Transform();
        CinemachineShake.finalitem = false;
        sun.SetActive(false);
        //_stageManager.UpdateStage();
        if (_stageManager.stage == Stage.ToDragonPlanet) {
            _stageManager.UpdateStage();
        }
    }
}
