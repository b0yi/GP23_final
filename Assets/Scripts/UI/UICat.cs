using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICat : MonoBehaviour
{
    private Vector3 originPos;
    private Quaternion originRot;
    private RectTransform rectTransform;
    private float w;
    private float h;

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        originRot = transform.rotation;
        rectTransform = GetComponent<RectTransform>();
        w = rectTransform.rect.width;
        h = rectTransform.rect.height;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CaculatePosition();
    }

    private void CaculatePosition() {
        float wThreshold = w/2f*50f;
        float hThreshold = h/2f*50f;
        Vector2 inScreenPos = Camera.main.WorldToScreenPoint(originPos);

        if (inScreenPos.x > wThreshold && inScreenPos.x < Screen.width - wThreshold && inScreenPos.y > hThreshold && inScreenPos.y < Screen.height - hThreshold) {
            transform.SetPositionAndRotation(originPos, originRot);
        }
        else {
            Vector2 newInScreenPos;

            if (inScreenPos.x <= wThreshold) {
                newInScreenPos.x = wThreshold;
            }
            else if (inScreenPos.x >= Screen.width - wThreshold) {
                newInScreenPos.x = Screen.width - wThreshold;
            }
            else {
                newInScreenPos.x = inScreenPos.x; 
            }
            if (inScreenPos.y <= hThreshold) {
                newInScreenPos.y = hThreshold;
            }
            else if (inScreenPos.y >= Screen.height - hThreshold) {
                newInScreenPos.y = Screen.height - hThreshold;
            }
            else {
                newInScreenPos.y = inScreenPos.y;
            }

            Vector3 newPos = Camera.main.ScreenToWorldPoint(newInScreenPos);
            newPos.z = 0;
            transform.SetPositionAndRotation(newPos, Camera.main.transform.rotation);
        }
    }
}
