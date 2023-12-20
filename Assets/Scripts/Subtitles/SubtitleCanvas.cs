using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleCanvas : MonoBehaviour
{
    [DisplayOnly] public bool isLockingSubtitle;
    [DisplayOnly] public bool isTalking;

    // Start is called before the first frame update
    void Start()
    {
        isLockingSubtitle = false;
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
