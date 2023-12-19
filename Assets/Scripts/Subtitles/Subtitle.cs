using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public TextMeshProUGUI subtitleArea;
    protected SubtitleGenerator generator;
    protected PlayerController_new player;
    protected TalkManager talkManager;

    public float talkRange = 0f;
    public float subtitleID = 0f;

    protected float charPerSec = 20f;
    protected float delayTime = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController_new>();
        talkManager = GameObject.FindWithTag("UIManager").GetComponent<TalkManager>();
        generator = subtitleArea.GetComponent<SubtitleGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Talk() {
        if (IsPlayerInRange(talkRange)) {
            if (talkManager.currentSubtitle == subtitleID) {
                if (!generator.isUsingSubtitle) {
                    StartCoroutine(ShowSubtitle(talkManager.subtitles[talkManager.currentSubtitle]));
                    talkManager.currentSubtitle += 1;
                }
            }
        }
    }

    public void GenerateSubtitle(List<string> subtitles)
    {
        if (!generator.isUsingSubtitle)
        {
            StartCoroutine(ShowSubtitle(subtitles));
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
        generator.isUsingSubtitle = true;

        float showCharTime = 1f / charPerSec;
        for (int i = 0; i < subtitles.Count; i++)
        {
            string[] nameAndWord = subtitles[i].Split(": ");
            string dispText = nameAndWord[0] + ": ";

            foreach (char c in nameAndWord[1])
            {
                dispText += c;
                subtitleArea.text = dispText;
                yield return new WaitForSeconds(showCharTime);
            }

            yield return new WaitForSeconds(delayTime);
            subtitleArea.text = "";
        }

        generator.isUsingSubtitle = false;
        player.Unlock();
        player.Unfreeze();
    }
}
