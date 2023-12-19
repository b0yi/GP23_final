using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSubtitle : Subtitle
{
    public int treeID;

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
        Talk();
    }

    public override void Talk()
    {
        if (IsPlayerInRange(talkRange)) {
            if ((treeID == 0 && !talkManager.tree0) || (treeID == 1 && !talkManager.tree1) || (treeID == 2 && !talkManager.tree2)) {
                if (treeID == 0) {
                    talkManager.tree0 = true;
                }
                else if (treeID == 1) {
                    talkManager.tree1 = true;
                }
                else if (treeID == 2) {
                    talkManager.tree2 = true;
                }

                if (!generator.isUsingSubtitle) {
                    StartCoroutine(ShowSubtitle(talkManager.treeSubtitles[treeID]));
                }
            }
        }
    }

    public override IEnumerator ShowSubtitle(List<string> subtitles)
    {
        player.Lock();
        player.Freeze();
        generator.isUsingSubtitle = true;

        float showCharTime = 1f / charPerSec;
        for (int i = 0; i < subtitles.Count; i++)
        {
            string dispText = "";

            foreach (char c in subtitles[i])
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
