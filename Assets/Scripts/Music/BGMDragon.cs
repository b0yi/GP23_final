using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDragon : MonoBehaviour
{
    public BGMmanager bGMmanager;

    private void Start()
    {
        bGMmanager.DragonSummon();
    }

    
    
}
