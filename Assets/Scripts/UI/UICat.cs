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
        Vector2 inScreenPos = Camera.main.WorldToScreenPoint(originPos);

        if (inScreenPos.x > 0 && inScreenPos.x < Screen.width && inScreenPos.y > 0 && inScreenPos.y < Screen.height) {
            transform.SetPositionAndRotation(originPos, originRot);
        }
        else {
            Vector2 newInScreenPos;

            if (inScreenPos.x <= 0) {
                newInScreenPos.x = w/2f*50f;
            }
            else if (inScreenPos.x >= Screen.width) {
                newInScreenPos.x = Screen.width - w/2f*50f;
            }
            else {
                newInScreenPos.x = inScreenPos.x; 
            }
            if (inScreenPos.y <= 0) {
                newInScreenPos.y = h/2f*50f;
            }
            else if (inScreenPos.y >= Screen.height) {
                newInScreenPos.y = Screen.height - h/2f*50f;
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
