using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PreviewPlanet : MonoBehaviour
{
    public PlayableDirector timeline;

    public PlayerController player;

    // 之後根據不同 player 的狀態（現在要去哪個星球來播放不同的 timeline）

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            timeline.Play();
            player.isLocked = true;
        }
    }

    void Update()
    {
        if (timeline.state == PlayState.Paused)
        {
            player.isLocked = false;
        }
    }
}
