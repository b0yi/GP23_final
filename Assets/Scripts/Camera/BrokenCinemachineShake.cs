using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BrokenCinemachineShake : MonoBehaviour
{
    
    private CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noisePerlin;
    private float shakeTimer=0.0f;
    private float collideshaketimer=0.0f;
    private float elapsedTime=0f;
    private float shakeTimerTotal=0.3f;
    //public float collideshaketimertotal=1.0f;
    //private float startingIntensity;
    public static bool brokenitem=true;
    bool isShaking=false;
    bool hasShaken=false;
    bool starttiming=false;
    // Start is called before the first frame update

    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        noisePerlin= vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        // brokenitem = true;
    }

    // void Start()
    // {
    //     //noisePerlin.m_AmplitudeGain=0;

    // }

    // Update is called once per frame
    void Update()
    {
        //shakeTimer+=Time.deltaTime;
        if(starttiming)
            shakeTimer+=Time.deltaTime;
        if(brokenitem==false&&hasShaken==false)
		{
			ShakeCamera();
            starttiming=true;
		}
        if(shakeTimer>shakeTimerTotal)
        {
            StopShakeCamera();
            starttiming=false;
        }
        
    }

    void ShakeCamera()
    {
        elapsedTime+=Time.deltaTime;
        
        noisePerlin.m_AmplitudeGain=20;
        noisePerlin.m_FrequencyGain=1f;
        isShaking=true;
        shakeTimer=0f;
        hasShaken=true;
    }


    void StopShakeCamera()
    {
        noisePerlin.m_AmplitudeGain=0;
        noisePerlin.m_FrequencyGain=0;
        isShaking=false;
        //iscollided=false;
    }

}
