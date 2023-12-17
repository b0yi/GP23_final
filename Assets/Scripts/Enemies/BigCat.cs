using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatTalkState {
    FirstTalk,
    KeepTalk,
    WaterTalk,
    FishTalk,
    NoTalk
}

public class BigCat : EnemyController
{
    [Header("Big Cat Script")]
    public float faceRange;
    public float talkRange;
    [DisplayOnly] public bool isTalking;
    [DisplayOnly] public CatTalkState talkState;
    private CatSubtitle catSubtitle;

    // Start is called before the first frame update
    void Start()
    {
        stage = "OnPlanet";
        rb = GetComponent<Rigidbody2D>();
        isTalking = false;
        talkState = CatTalkState.FirstTalk;
        catSubtitle = GetComponent<CatSubtitle>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        FacePlayer();
        Talk();
    }
    
    void FixedUpdate()
    {
        GroundCheck();
    }

    protected override void DetectPlayer()
    {
        if (IsPlayerInRange(faceRange)) {
            CaculateDirection();
        }
        else {
            direction = 0;
        }
    }

    private void Talk() {
        if (IsPlayerInRange(talkRange) && player.GetComponent<PlayerController_new>().playerState == PlayerState.OnPlanet) {
            if (!catSubtitle.subtitleGenerator.isUsingSubtitle) {
                if (talkState == CatTalkState.FirstTalk) {
                    catSubtitle.GenerateSubtitle(catSubtitle.firstTalk);
                    talkState = CatTalkState.NoTalk;
                }
                // else if (talkState == CatTalkState.WaterTalk) {
                //     int pickOne = Random.Range(0, 2);
                //     catSubtitle.GenerateSubtitle(catSubtitle.waterTalk[pickOne]);
                // }
                // else if (talkState == CatTalkState.FishTalk) {
                //     int pickOne = Random.Range(0, 2);
                //     catSubtitle.GenerateSubtitle(catSubtitle.fishTalk[pickOne]);
                // }
                // else if (talkState == CatTalkState.KeepTalk) {
                //     int pickOne = Random.Range(0, 9);
                //     catSubtitle.GenerateSubtitle(catSubtitle.keepTalk[pickOne]);
                // }
                else {
                    
                }
            }
        }
    }

    private void FacePlayer() {
        if (direction == 0) {
            transform.localScale = transform.localScale;
        }
        else {
            transform.localScale = (direction == 1) ? new Vector3(-0.3f, 0.3f, 1f) : new Vector3(0.3f, 0.3f, 1f);
        }
    }
}
