using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PreviewPlanet : MonoBehaviour
{
    public PlayableDirector timelinePlanetR;
    public PlayableDirector timelinePlanetE;
    public PlayableDirector timelinePlanetF;

    public PlayerController_new player;
    [DisplayOnly] public StageManager stageManager;

    // 之後根據不同 player 的狀態（現在要去哪個星球來播放不同的 timeline）

    void Start()
    {
        stageManager = GameObject.FindWithTag("UIManager").GetComponent<StageManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (stageManager && collider.CompareTag("Player"))
        {

            //if (stageManager.stage == GameProgressStage.PlanetR)
            //{
            //    timelinePlanetR.Play();
            //    player.Lock();
            //}
            //if (stageManager.stage == GameProgressStage.PlanetE)
            //{
            //    timelinePlanetE.Play();
            //    player.Lock();
            //}
            //if (stageManager.stage == GameProgressStage.PlanetF)
            //{
            //    timelinePlanetF.Play();
            //    player.Lock();
            //}

        }
    }

    void Update()
    {
        if (stageManager)
        {
            //if (stageManager.stage == GameProgressStage.PlanetR && timelinePlanetR.state == PlayState.Paused)
            //{
            //    player.Unlock();
            //}
            //if (stageManager.stage == GameProgressStage.PlanetE && timelinePlanetE.state == PlayState.Paused)
            //{
            //    player.Unlock();
            //}
            //if (stageManager.stage == GameProgressStage.PlanetF && timelinePlanetF.state == PlayState.Paused)
            //{
            //    player.Unlock();
            //}

        }

    }
}
