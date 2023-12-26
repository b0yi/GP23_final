using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCat : EnemyController
{
    [Header("Big Cat Script")]
    public float faceRange;

    // Start is called before the first frame update
    void Start()
    {
        stage = "OnPlanet";
        rb = GetComponent<Rigidbody2D>();

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        FacePlayer();
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

    private void FacePlayer() {
        if (direction == 0) {
            transform.localScale = transform.localScale;
        }
        else {
            transform.localScale = (direction == 1) ? new Vector3(-0.3f, 0.3f, 1f) : new Vector3(0.3f, 0.3f, 1f);
        }
    }
}
