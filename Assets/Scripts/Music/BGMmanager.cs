using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    public AudioSource _AudioSource;

	public AudioClip _AudioClipO;
	public AudioClip _AudioClipCat;
    public AudioClip _AudioClipWater;
    public AudioClip _AudioClipMaze;
    public AudioClip _AudioClipDragon;
    public float fadeOutTime = 0.8f;
    public float VolumeO = 0.5f;
    public float VolumeWater = 1f;
    public float VolumeCat = 0.5f;
    public float VolumeMaze = 0.5f;
    public float Volumedragon = 0.5f;
    //[DisplayOnly] public bool boolForO = true;
    //[DisplayOnly] public bool boolForCat = false;

	void Start() 
	{

		_AudioSource.clip = _AudioClipO;
        _AudioSource.volume=VolumeO;
		_AudioSource.Play();
	
	}
	

	void Update () 
	{
		// if (boolForCat&&_AudioSource.clip==_AudioClipO)
		// {
		// 	_AudioSource.clip = _AudioClipCat;
		// 	_AudioSource.Play();
		// }
		// else
		// {
				
		// 	_AudioSource.clip = _AudioClipO;
				
		// 	_AudioSource.Play();

		// }
	}

    public void EnterCatPlanet() {
        if (_AudioSource.clip != _AudioClipCat) {
            StartCoroutine(FadeOutCat());
            // _AudioSource.clip = _AudioClipCat;
            // _AudioSource.Play();
        }
    }

    public void ExitCatPlanet() {
        if (_AudioSource.clip != _AudioClipO) {
            StartCoroutine(FadeOutO());
            // _AudioSource.clip = _AudioClipO;           
            // _AudioSource.Play();
        }
    }

    public void EnterMazePlanet() {
        if (_AudioSource.clip != _AudioClipMaze) {
            StartCoroutine(FadeOutMaze());
            // _AudioSource.clip = _AudioClipMaze;
            // _AudioSource.Play();
        }
    }

    public void ExitMazePlanet() {
        if (_AudioSource.clip != _AudioClipO) {
            StartCoroutine(FadeOutO());
            // _AudioSource.clip = _AudioClipO;           
            // _AudioSource.Play();
        }
    }
	
    public void EnterWaterPlanet() {
        if (_AudioSource.clip != _AudioClipWater) {
            StartCoroutine(FadeOutWater());
            // _AudioSource.clip = _AudioClipWater;
            // _AudioSource.Play();
        }
    }

    public void ExitWaterPlanet() {
        if (_AudioSource.clip != _AudioClipO) {
            StartCoroutine(FadeOutO());
            // _AudioSource.clip = _AudioClipO;           
            // _AudioSource.Play();
        }
    }

    public void DragonSummon() {
        if (_AudioSource.clip != _AudioClipDragon) {
            
            _AudioSource.clip = _AudioClipDragon;
            _AudioSource.Play();
        }
    }
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.name == "Cat Planet")
    //     {
    //         boolForO=false;
    //         boolForCat=true;
    //     }
    // }

    public IEnumerator FadeOutCat()
    {
        //fadeOutTime=2f;
        float timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.volume = Mathf.Lerp(VolumeO, 0, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
        timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.clip = _AudioClipCat;
            _AudioSource.Play();
            _AudioSource.volume = Mathf.Lerp(0, VolumeCat, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator FadeOutWater()
    {
        //float fadeOutTime=2f;
        float timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.volume = Mathf.Lerp(VolumeO, 0, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
        timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.clip = _AudioClipWater;
            _AudioSource.Play();
            _AudioSource.volume = Mathf.Lerp(0, VolumeWater, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator FadeOutMaze()
    {
        //float fadeOutTime=2f;
        float timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.volume = Mathf.Lerp(VolumeO, 0, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
        timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.clip = _AudioClipMaze;
            _AudioSource.Play();
            _AudioSource.volume = Mathf.Lerp(0, VolumeMaze, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator FadeOutO()
    {
        //float timetofade=2f;
        float timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.volume = Mathf.Lerp(0.5f, 0, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
        timeelapsed=0f;
        while(timeelapsed<fadeOutTime)
        {
            _AudioSource.clip = _AudioClipO;
            _AudioSource.Play();
            _AudioSource.volume = Mathf.Lerp(0, VolumeO, timeelapsed/fadeOutTime);
            //print(_AudioSource.volume);
            timeelapsed+=Time.deltaTime;

            yield return null;
        }
    }
}


