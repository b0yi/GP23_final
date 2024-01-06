using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIndicator : MonoBehaviour
{
    private Transform player;
    private StageManager stageManager;
    public GameObject target;
    public float hideRange;
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        stageManager = GameObject.FindWithTag("UIManager").GetComponent<StageManager>();
        player = GameObject.FindWithTag("Player").transform;
        arrow = transform.Find("Image").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (stageManager.stage == Stage.Cat) {
            var dir = target.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.localScale = player.localScale;

            if (dir.magnitude > hideRange) {
                arrow.SetActive(true);
            }
            else {
                arrow.SetActive(false);
            }
        }
        else {
            arrow.SetActive(false);
        }
    }
}
