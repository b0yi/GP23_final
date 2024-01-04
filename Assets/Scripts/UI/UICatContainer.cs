using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICatContainer : MonoBehaviour
{
    private StageManager stageManager;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.FindWithTag("UIManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stageManager.stage == Stage.Kitten) {
            transform.Find("CatNiceValueContainer").gameObject.SetActive(true);
        }
    }
}
