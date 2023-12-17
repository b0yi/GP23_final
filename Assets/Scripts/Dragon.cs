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
        //Debug.Log(finalIem+"Not in if");
        if(finalitem==null)
		{
            //Debug.Log(finalIem+" in if");
			dragon.SetActive(true);
		}
    }
}
