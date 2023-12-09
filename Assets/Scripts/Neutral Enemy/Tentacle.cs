using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int length;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;
    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    private Vector3[] segmentV;

    private void Start()
    {
        lineRenderer.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        ResetPos();
    }

    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = transform.position;
        for(int i = 1; i< segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i/trailSpeed);
        }
        lineRenderer.SetPositions(segmentPoses);
    }

    private void ResetPos()
    {
        segmentPoses[0] = targetDir.position;
        for(int i = 1; i < length; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * targetDist;
        }
        lineRenderer.SetPositions(segmentPoses);
        
    }
}
