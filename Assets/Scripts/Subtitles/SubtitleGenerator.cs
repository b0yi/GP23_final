using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleGenerator : MonoBehaviour
{
    [DisplayOnly] public bool isUsingSubtitle;
    private TextMeshProUGUI subtitleArea;
    public float charPerSec = 20f;
    private float emptyTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        isUsingSubtitle = false;
        subtitleArea = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator GenerateSubtitle(List<string> subtitles) {
        float waitDelay = 1f / charPerSec;
        isUsingSubtitle = true;
        for (int i = 0; i < subtitles.Count; i++) {
            string[] nameAndWord = subtitles[i].Split(": ");
            // foreach (string s in nameAndWord) {
            //     Debug.Log(s);
            // }
            string dispText = nameAndWord[0] + ": ";

            foreach (char c in nameAndWord[1]) {
                dispText += c;
                subtitleArea.text = dispText;
                yield return new WaitForSeconds(waitDelay);
            }

            yield return new WaitForSeconds(emptyTime);
            subtitleArea.text = "";
        }
        isUsingSubtitle = false;
    }
}
