using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPlanetAlpha : MonoBehaviour
{
    [DisplayOnly] public bool boolplayerenter=false;
    float alphatime=1f;
    public float alphalevel=1f;
    // Start is called before the first frame update
    void Start()
    {
        boolplayerenter=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(boolplayerenter==true&&alphalevel>=0.35f)
        {
            alphalevel-=0.03f;
            GetComponent<SpriteRenderer>().color=new Color(0,0,0,alphalevel);
        }
        else if(boolplayerenter==false&&alphalevel<=1f)
        {
             alphalevel+=0.03f;
             GetComponent<SpriteRenderer>().color=new Color(0,0,0,alphalevel);
        }
        // if(boolplayerenter)
        // {
        //     GetComponent<SpriteRenderer>().color=new Color(0,0,0,alphalevel);
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            boolplayerenter=true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            boolplayerenter=false;
        }

    }
}
