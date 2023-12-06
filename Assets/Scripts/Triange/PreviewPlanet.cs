using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PreviewPlanet : MonoBehaviour
{
    public PlayableDirector timelinePlanetR;
    public PlayableDirector timelinePlanetE;
    public PlayableDirector timelinePlanetF;

    public PlayerController player;
    [DisplayOnly] public UIManager uIManager;

    // 之後根據不同 player 的狀態（現在要去哪個星球來播放不同的 timeline）

    void Start()
    {
        uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {

            if (uIManager.stage == GameProgressStage.PlanetR)
            {
                timelinePlanetR.Play();
                player.isLocked = true;
            }
            if (uIManager.stage == GameProgressStage.PlanetE)
            {
                timelinePlanetE.Play();
                player.isLocked = true;
            }
            if (uIManager.stage == GameProgressStage.PlanetF)
            {
                timelinePlanetF.Play();
                player.isLocked = true;
            }



        }
    }

    void Update()
    {
        if (uIManager.stage == GameProgressStage.PlanetR && timelinePlanetR.state == PlayState.Paused)
        {
            player.isLocked = false;
        }
        if (uIManager.stage == GameProgressStage.PlanetE && timelinePlanetE.state == PlayState.Paused)
        {
            player.isLocked = false;
        }
        if (uIManager.stage == GameProgressStage.PlanetF && timelinePlanetF.state == PlayState.Paused)
        {
            player.isLocked = false;
        }

    }
}
