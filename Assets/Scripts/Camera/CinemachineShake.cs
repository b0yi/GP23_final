using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    //public static CinemachineShake Instance {get;private set;}

    private CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noisePerlin;
    private float shakeTimer=0.0f;
    private float collideshaketimer=0.0f;
    private float elapsedTime=0f;
    private float shakeTimerTotal=10f;
    //public float collideshaketimertotal=1.0f;
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
        //shakeTimer+=Time.deltaTime;
        if(starttiming)
            shakeTimer+=Time.deltaTime;
        if(finalitem==false&&hasShaken==false)
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
        
        noisePerlin.m_AmplitudeGain=Mathf.Lerp(8,30,elapsedTime/shakeTimerTotal);
        noisePerlin.m_FrequencyGain=10;
        isShaking=true;
        shakeTimer=0f;
        hasShaken=true;
    }


    void StopShakeCamera()
    {
        noisePerlin.m_AmplitudeGain=0;
        noisePerlin.m_FrequencyGain=0;
        isShaking=false;
        iscollided=false;
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
   
    // void OnCollisionEnter2D(Collision2D other)
    // {
    //     if(other.gameObject.name=="DragonItem")
    //     {
    //         finalitem=false;
    //         print(other.gameObject.name);
    //     }

    // }
}
