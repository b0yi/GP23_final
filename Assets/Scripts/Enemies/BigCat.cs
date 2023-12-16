using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CatTalkState {
    FirstTalk,
    KeepTalk,
    WaterTalk,
    FishTalk,
}

public class BigCat : EnemyController
{
    [Header("Big Cat Script")]
    public float faceRange;
    public float talkRange;
    [DisplayOnly] public bool isTalking;
    [DisplayOnly] public CatTalkState talkState;

    // Start is called before the first frame update
    void Start()
    {
        stage = "onPlanet";
        rb = GetComponent<Rigidbody2D>();
        isTalking = false;
        talkState = CatTalkState.FirstTalk;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        FacePlayer();
        Talk();
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
            isTalking = true;
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
