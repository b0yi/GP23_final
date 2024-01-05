using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CollideCinemachineshake : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noisePerlin;
    private float shakeTimer=0.0f;
    private float elapsedTime=0f;
    public float collideshaketimertotal=5.0f;
    //private float startingIntensity;
    public static bool finalitem=true;
    public static bool iscollided=false;
    bool isShaking=false;
    bool hasShaken=false;
    bool starttiming=false;
    // Start is called before the first frame update

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        noisePerlin= vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // void Start()
    // {
    //     //noisePerlin.m_AmplitudeGain=0;

    // }

    // Update is called once per frame
    void Update()
    {
        if(starttiming)
            shakeTimer+=Time.deltaTime;
        if(iscollided==true&&isShaking==false)
		{
			CollideShakeCamera();
            starttiming=true;
            
            //print("shaking");
		}
        // print(shakeTimer);
        // print(iscollided);
        if(shakeTimer>collideshaketimertotal)
        {
            StopShakeCamera();
            starttiming=false;
        }
        
    }

    void CollideShakeCamera()
    {
        noisePerlin.m_AmplitudeGain=10;
        noisePerlin.m_FrequencyGain=1;
        isShaking=true;
        shakeTimer=0f;
    }

    void StopShakeCamera()
    {
        noisePerlin.m_AmplitudeGain=0;
        noisePerlin.m_FrequencyGain=0;
        isShaking=false;
        iscollided=false;
    }

}
