using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public SubtitleGenerator subtitleGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateSubtitle(List<string> subtitles) {
        if (!subtitleGenerator.isUsingSubtitle) {
            StartCoroutine(subtitleGenerator.GenerateSubtitle(subtitles));
        }
    }
}
