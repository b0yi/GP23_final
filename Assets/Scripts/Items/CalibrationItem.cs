using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalibrationItem : Item
{
    // public GameObject calibrationFailedCanvas;
    private Transform stopArea;
    private Transform needle;

    private bool canCollect;
    private bool isStarted;
    private bool isNeedleStopped;

    [SerializeField][Tooltip("The rotation of the area.")][DisplayOnly]
    float areaRotation;
    [SerializeField][Tooltip("The rotation of the needle.")][DisplayOnly]
    float needleRotation;
    [SerializeField][Tooltip("The rotation speed of the needle.")]
    float needleSpeed = 0.25f;

    public PlanetOfCalibration planet;

    // Start is called before the first frame update
    void Start()
    {
        stopArea = itemCanvas.transform.Find("Area");
        needle = itemCanvas.transform.Find("Needle");

        ItemReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange) {
            isPlayerOnGround = GameObject.Find("Player").GetComponent<PlayerController>().isGrounded;
        }
        if (canCollect && isPlayerOnGround) {
        // if (canCollect) {
            // Player is in the collect range
            if (isNeedleStopped == true) {
                // Is the needle stopped?
                if (IsNeedleInRange()) {
                    // Whether the needle is in the right place
                    // Yes, player succeeded
                    Debug.Log("Succeeded to calibration");
                    if (planet.DecreaseCanvasNum()) {
                        OpenItemGetCanvas(itemName);
                    }
                    ItemReset();
                    Destroy(gameObject);
                }
                else {
                    // No, player failed
                    // StartCoroutine(ShowFailedCanvas());
                    Debug.Log("Failed to calibration.");
                    ItemReset();
                }
            }
            if (isStarted == true && isNeedleStopped == false) {
                // start rotating the needle
                needle.rotation = Quaternion.Euler(0, 0, needle.rotation.eulerAngles.z - needleSpeed);
                needleRotation = needle.rotation.eulerAngles.z;

                if (needleRotation <= 180f) {
                    // needle is over the range
                    isNeedleStopped = true;
                }
            }
            if (Input.GetMouseButtonDown(0)) {
                if (!isStarted) {
                    // Start the mini game
                    isStarted = true;
                }
                else {
                    // Stop the needle
                    isNeedleStopped = true;
                }
            }
        }    
    }

    public override void ShowItemCanvas()
    {
        itemCanvas.SetActive(true);
        canCollect = true;
        areaRotation = Random.Range(205f, 335f);
        stopArea.rotation = Quaternion.Euler(0, 0, areaRotation);
    }

    public override void CloseItemCanvas()
    {
        ItemReset();
    }

    private bool IsNeedleInRange() {
        if (needleRotation <= areaRotation + 6f && needleRotation >= areaRotation - 6f) {
            return true;
        }
        else {
            return false;
        }
    }

    public override void ItemReset() {
        // Reset the item's state
        itemCanvas.SetActive(false);
        canCollect = false;
        isStarted = false;
        isNeedleStopped = false;

        areaRotation = 270f;
        needle.rotation = Quaternion.Euler(0, 0, 359f);
    }

    // private IEnumerator ShowFailedCanvas() {
    //     calibrationFailedCanvas.SetActive(true);
    //     yield return new WaitForSeconds(1.5f);
    //     calibrationFailedCanvas.SetActive(false);
    // }
}
