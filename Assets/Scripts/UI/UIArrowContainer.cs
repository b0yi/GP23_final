using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowContainer : MonoBehaviour
{
    private StageManager _stageManager;
    public PlayerController_new pc;

    public GameObject arrowOriginPlanet;
    public GameObject arrowCatPlanet;
    public GameObject arrowWaterPlanet;
    public GameObject arrowMazePlanet;
    public GameObject arrowBlackHole;
    void Start()
    {
        _stageManager = GameObject.FindWithTag("UIManager").GetComponent<StageManager>();
    }

    void Update()
    {
        if (pc.playerState == PlayerState.InSpace)
        {
            arrowOriginPlanet.SetActive(true);
            arrowBlackHole.SetActive(true);
        }
        else { 
            arrowOriginPlanet.SetActive(false); 
            arrowBlackHole.SetActive(false);
        }



        if (_stageManager != null)
        {
            if (pc.playerState == PlayerState.InSpace && _stageManager.stage == Stage.ToCatPlanet)
            {
                arrowCatPlanet.SetActive(true);
            }
            else
            {
                arrowCatPlanet.SetActive(false);
            }


            if (pc.playerState == PlayerState.InSpace && _stageManager.stage == Stage.ToWaterPlanet)
            {
                arrowWaterPlanet.SetActive(true);
            }
            else
            {
                arrowWaterPlanet.SetActive(false);
            }


            if (pc.playerState == PlayerState.InSpace && _stageManager.stage == Stage.ToMazePlanet)
            {
                arrowMazePlanet.SetActive(true);
            }
            else
            {
                arrowMazePlanet.SetActive(false);
            }
        }
    }
}
