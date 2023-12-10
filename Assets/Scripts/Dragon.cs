using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public GameObject finalitem;
    public GameObject dragon;
    // Start is called before the first frame update
    void Start()
    {
        dragon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(finalitem+"Not in if");
        if(finalitem==null)
		{
            //Debug.Log(finalitem+" in if");
			dragon.SetActive(true);
		}
    }
}
