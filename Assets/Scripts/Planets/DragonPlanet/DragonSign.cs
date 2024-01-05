using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSign : MonoBehaviour
{
    public SpriteRenderer sign;
    public float speed;
    public float alpha = 1.0f;
    public bool increase;
    
    // Start is called before the first frame update
    void Start()
    {
        increase = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (increase)
        {
            alpha += Time.deltaTime * speed;
            if (alpha >= 1.0f)
            {
                increase = false;
            }
        }
        else
        {
            alpha -= Time.deltaTime * speed;
            if (alpha <= 0f)
            {
                increase = true;
            }
        }
        sign.color = new Color(sign.color.r, sign.color.g, sign.color.b, alpha);
    }
}
