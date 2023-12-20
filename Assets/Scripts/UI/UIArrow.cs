using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIArrow : MonoBehaviour
{
    private Image _arrow;

    public RectTransform dashboard;
    public Camera cam;
    public GameObject player;
    public GameObject target;
    //public GameObject text;

    public float paddingTop;
    public float paddingRight;
    public float paddingBottom;
    public float paddingLeft;

    [DisplayOnly]
    public List<Vector2> boundary;

    void Start()
    {
        _arrow = GetComponent<Image>();

        boundary = new List<Vector2>();

        float w = dashboard.rect.width;
        float h = dashboard.rect.height;

        boundary.Add(new Vector2(w / 2 - paddingRight, h / 2 - paddingTop));
        boundary.Add(new Vector2(-w / 2 + paddingLeft, h / 2 - paddingTop));
        boundary.Add(new Vector2(-w / 2 + paddingLeft, -h / 2 + paddingBottom));
        boundary.Add(new Vector2(w / 2 - paddingRight, -h / 2 + paddingBottom));
        boundary.Add(new Vector2(w / 2 - paddingRight, h / 2 - paddingTop)); // 繞一圈



    }

    void Update()
    {
        Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector2 targetScreenPosition = Camera.main.WorldToScreenPoint(target.transform.position);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            dashboard,
            playerScreenPosition,
            cam,
            out Vector2 playerRectPosition
        );
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            dashboard,
            targetScreenPosition,
            cam,
            out Vector2 targetRectPosition
        );

        for (int i = 0; i < 4; ++i)
        {
            Vector2 arrowPosition = Vector2.zero;
            if (SegmentsInterPoint(playerRectPosition, targetRectPosition, boundary[i], boundary[i + 1], ref arrowPosition))
            {

                _arrow.rectTransform.anchoredPosition = Vector2.Lerp(_arrow.rectTransform.anchoredPosition, arrowPosition, 10f * Time.deltaTime);
                // _arrow.rectTransform.anchoredPosition = arrowPosition;
                _arrow.rectTransform.localEulerAngles = new Vector3(0, 0, 90f * i);



                //if (i == 0)
                //{       // top
                //    text.transform.position = _arrow.transform.position;
                //    text.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
                //}
                //else if (i == 1)    // left
                //{
                //    text.transform.position = _arrow.transform.position + new Vector3(5f, 0, 0);
                //    text.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
                //}
                //else if (i == 2)    // bottom
                //{
                //    text.transform.position = _arrow.transform.position;
                //    text.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Center;
                //}
                //else if (i == 3)    // right
                //{
                //    text.transform.position = _arrow.transform.position + new Vector3(5f, 0, 0);
                //    text.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Right;
                //}




                break;
            }
        }


    }

    // 外積
    public static float Cross(Vector2 a, Vector2 b)
    {
        return a.x * b.y - b.x * a.y;
    }

    // 交點
    public static bool SegmentsInterPoint(Vector2 a, Vector2 b, Vector2 c, Vector2 d, ref Vector2 interPoint)
    {
        // 判斷 ab 和 cd 是否有交點，如果有，就回傳交點座標


        // 判斷 c, d 是否在直線 ab 的兩側
        Vector2 ab = b - a;
        Vector2 ac = c - a;
        Vector2 ad = d - a;
        if (Cross(ab, ac) * Cross(ab, ad) >= 0)
        {
            return false;
        }

        // 判斷 a, b 是否在直線 cd 的兩側
        Vector2 cd = d - c;
        Vector2 ca = a - c;
        Vector2 cb = b - c;
        if (Cross(cd, ca) * Cross(cd, cb) >= 0)
        {
            return false;
        }

        // 計算交點
        // P = A + t * AB, t = 0 ~ 1
        // t 可以透過計算兩塊平行四邊形的比例得到
        float t = Cross(ca, cd) / Cross(cd, ab);


        interPoint = new Vector2(a.x + t * (b.x - a.x), a.y + t * (b.y - a.y));
        return true;
    }
}
