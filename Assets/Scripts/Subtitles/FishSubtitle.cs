using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSubtitle : Subtitle
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
        generator = subtitleArea.GetComponent<SubtitleGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        Talk();
    }

    public override void Talk()
    {
        if (IsPlayerInRange(talkRange))
        {
            if (talkManager.currentSubtitle == 3)
            {
                if (!generator.isUsingSubtitle)
                {
                    StartCoroutine(ShowSubtitle(talkManager.subtitles[talkManager.currentSubtitle]));
                    talkManager.currentSubtitle += 1;
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

        _stageManager.UpdateStage();
        preview.playMazePlanetPreview();

        generator.isUsingSubtitle = false;
        player.Unlock();
        player.Unfreeze();
    }
}
