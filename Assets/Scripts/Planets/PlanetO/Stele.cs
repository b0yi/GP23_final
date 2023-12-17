using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stele : MonoBehaviour
{

    public PreviewPlanet preview;
    private StageManager _stageManager;


    private void Start()
    {
        GameObject m = GameObject.FindWithTag("UIManager");
        _stageManager = m.GetComponent<StageManager>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _stageManager.stage == Stage.Intro)
        {
            _stageManager.UpdateStage();
            preview.playCatPlanetPreview();
            //preview.playMazePlanetPreview();
        }
    }
}
