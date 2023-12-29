using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWhite : MonoBehaviour
{
    private bool enable;
    private float alpha;
    public RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        enable = false;
        alpha = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // >DELETE
        // if (Input.GetKeyDown(KeyCode.M))
        // {
        //     Trigger();
        // }
        // <DELETE
        if (enable)
        {
            alpha += Time.deltaTime*0.5f;
        }
        image.color = new Color(0, 0, 0, alpha);
    }

    public void Trigger()
    {
        enable = true;
    }
}
