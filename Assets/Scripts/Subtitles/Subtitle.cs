using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public TextMeshPro subtitleArea;
    private float emptyTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowSubtitles(List<string> subtitles) {
        for (int i = 0; i < subtitles.Count; i++) {
            int stringLength = subtitles[i].Length;
            float stringTime = 0.26f * stringLength + 1.5f; // 230wpm + 1.5sec
            subtitleArea.text = subtitles[i]; 
            yield return new WaitForSeconds(stringTime);
            subtitleArea.text = "";
            yield return new WaitForSeconds(emptyTime);
        }
    }
}
