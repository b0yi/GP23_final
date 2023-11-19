using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteGenerator : MonoBehaviour
{
    [Header("隕石產生器")]
    public int number;
    public GameObject satellite;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number; ++i)
        {
            Instantiate(satellite);
        }
    }
}
