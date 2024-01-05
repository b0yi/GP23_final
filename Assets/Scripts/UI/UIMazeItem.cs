using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMazeItem : MonoBehaviour
{
    private GameObject image;
    private TextMeshProUGUI countText;
    private CanvasGroup portalText;
    public int numOfItems = 3;
    [DisplayOnly] public int collected = 0;
    [DisplayOnly] public bool itemCanShowCanvas;
    [DisplayOnly] public bool enableTeleport;

    // Start is called before the first frame update
    void Start()
    {
        image = transform.Find("Image").gameObject;
        countText = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        portalText = transform.Find("PortalText").GetComponent<CanvasGroup>();
        portalText.gameObject.SetActive(false);

        countText.text = collected + "/" + numOfItems;
        itemCanShowCanvas = false;
        enableTeleport = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCollect() {
        collected++;
        countText.text = collected + "/" + numOfItems;

        if (collected == numOfItems) {
            image.SetActive(false);
            countText.gameObject.SetActive(false);
            enableTeleport = true;
            StartCoroutine(ShowPortalText());
        }
    }

    public IEnumerator ShowPortalText() {
        portalText.gameObject.SetActive(true);
        portalText.alpha = 1f;
        yield return new WaitForSeconds(2f);
        yield return FadeCanvas(portalText, 1f, 0f, 1f);
        portalText.gameObject.SetActive(false);
    }

    public IEnumerator FadeCanvas(CanvasGroup canvasGroup, float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha; // Ensure the final alpha value is set
    }
}
