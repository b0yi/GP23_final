using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    private StageManager _stageManager;

    public GameObject catPlanet; // cat
    public GameObject waterPlanet;
    public GameObject mazePlanet;
    public GameObject dragonPlanet;


    void Start()
    {
        _stageManager = GameObject.FindWithTag("UIManager").GetComponent<StageManager>();
    }

    private void Update()
    {

        if (_stageManager != null)
        {
            if (_stageManager.stage >= Stage.ToCatPlanet && !catPlanet.activeSelf)
            {
                catPlanet.SetActive(true);
            }
            if (_stageManager.stage >= Stage.ToWaterPlanet && !waterPlanet.activeSelf)
            {
                waterPlanet.SetActive(true);
            }
            if (_stageManager.stage >= Stage.ToMazePlanet && !mazePlanet.activeSelf)
            {
                mazePlanet.SetActive(true);
            }
            if (_stageManager.stage >= Stage.Dragon && !dragonPlanet.activeSelf)
            {
                dragonPlanet.SetActive(true);
            }
        }
        else
        {
            print("_stageManager not found");
        }

    }

}