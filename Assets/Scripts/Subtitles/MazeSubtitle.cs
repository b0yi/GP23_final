using System.Collections;
using System.Collections.Generic;
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
        generator = subtitleArea.GetComponent<SubtitleGenerator>();

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
        generator.isUsingSubtitle = true;

        if (talkManager.currentSubtitle == 3) {
            yield return new WaitForSeconds(bFWaitTime);
        }
        else {
            yield return new WaitForSeconds(aFWaitTime);
        }

        float showCharTime = 1f / charPerSec;
        for (int i = 0; i < subtitles.Count; i++) {
            string dispText = "";

            foreach (char c in subtitles[i]) {
                dispText += c;
                subtitleArea.text = dispText;
                yield return new WaitForSeconds(showCharTime);
            }

            yield return new WaitForSeconds(delayTime);
            subtitleArea.text = "";
        }

        generator.isUsingSubtitle = false;
    }
}
