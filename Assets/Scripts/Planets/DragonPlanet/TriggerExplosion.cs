using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using TMPro;
using System.Collections.Generic;

//[RequireComponent(typeof(Explodable))]
public class TriggerExplosion : Subtitle
{
    public BGMmanager bGMmanager;

    public Explodable explodable;
    [DisplayOnly] public float delayExplosionTimer;
    [DisplayOnly] bool explode;
    public float delayExplosionTime;
    public GameObject dragon;
    public GameObject sun;
    public GameObject planetO;
    public GameObject planetCat;
    public GameObject planetWater;
    public GameObject planetMaze;
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
        enterSkipHint = canvas.transform.Find("Images").gameObject;
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
            if (talkManager.nextSubtitle == SubtitleStage.crystal) {
                StartCoroutine(ShowSubtitle(talkManager.subtitles[(int)SubtitleStage.crystal]));
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

        enterSkipHint.SetActive(false);
        yield return FadeSubtitleCanvas(0, 1f, 1f);

        float showCharTime = 1f / talkManager.charPerSec;
        
        int start = subtitles.Count - 2;
        if (!talkManager.dragonCrystalBool) {
            talkManager.dragonCrystalBool = true;
            start = 0;
        }

        for (int i = start; i < subtitles.Count; i++)
        {
            string[] nameAndWord;
            string word = "";

            if (subtitles[i][1] == '-') {
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
            enterSkipHint.SetActive(false);

            foreach (char c in word)
            {
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
            
            enterSkipHint.SetActive(true);
            // yield return new WaitForSeconds(talkManager.delayTime);
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            yield return null;
        }

        yield return FadeSubtitleCanvas(1f, 0, 1f);

        canvas.isTalking = false;
        canvas.isLockingSubtitle = false;
        // player.Unlock();
        // player.Unfreeze();


        explode = true;
        delayExplosionTimer = delayExplosionTime;
        // player.Lock();
        player.Transform();
        CinemachineShake.finalitem = false;
        bGMmanager.DragonSummon();
        sun.SetActive(false);
        planetO.SetActive(false);
        planetCat.SetActive(false);
        planetMaze.SetActive(false);
        planetWater.SetActive(false);
        //_stageManager.UpdateStage();
        if (_stageManager.stage == Stage.ToDragonPlanet) {
            _stageManager.UpdateStage();
        }
    }
}
