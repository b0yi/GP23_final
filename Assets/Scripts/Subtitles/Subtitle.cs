using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public CanvasGroup subtitleCanvas;
    public TextMeshProUGUI subtitleArea;
    private float emptyTime = 0.5f;
    [DisplayOnly] public bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowSubtitles(List<string> subtitles) {
        isTalking = true;
        for (int i = 0; i < subtitles.Count; i++) {
            int stringLength = subtitles[i].Length;
            float stringTime = 3f; // 230wpm + 1sec
            subtitleArea.text = subtitles[i]; 
            yield return new WaitForSeconds(stringTime);
            subtitleArea.text = "";
            yield return new WaitForSeconds(emptyTime);
        }
        isTalking = false;
    }
}
