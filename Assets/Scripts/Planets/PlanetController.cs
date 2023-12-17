using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [DisplayOnly] public StageManager stageManager;

    public GameObject planetR; // cat
    public GameObject planetWater;
    public GameObject planetMaze;
    public GameObject planetDragon;


    void Start()
    {
        stageManager = GameObject.FindWithTag("UIManager").GetComponent<StageManager>();
    }

    private void Update()
    {

        if (stageManager != null)
        {
            if (stageManager.stage >= Stage.ToCatPlanet)
            {
                planetR.SetActive(true);
            }
            if (stageManager.stage >= Stage.ToWaterPlanet)
            {
                planetWater.SetActive(true);
            }
            if (stageManager.stage >= Stage.ToMazePlanet)
            {
                planetMaze.SetActive(true);
            }
            if (stageManager.stage >= Stage.Dragon)
            {
                planetDragon.SetActive(true);
            }
        }

    }

}