using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [DisplayOnly] public UIManager uIManager;

    public GameObject planetR;
    public GameObject planetE;
    public GameObject planetF;


    void Start()
    {
        uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();

        if (uIManager)
        {
            switch (uIManager.stage)
            {
                case GameProgressStage.PlanetR:
                    planetR.SetActive(true);
                    planetE.SetActive(false);
                    planetF.SetActive(false);
                    break;
                case GameProgressStage.PlanetE:
                    planetR.SetActive(true);
                    planetE.SetActive(true);
                    planetF.SetActive(false);
                    break;
                case GameProgressStage.PlanetF:
                    planetR.SetActive(true);
                    planetE.SetActive(true);
                    planetF.SetActive(true);
                    break;
                default:
                    planetR.SetActive(true);
                    planetE.SetActive(true);
                    planetF.SetActive(true);
                    break;
            }

        }


    }

}