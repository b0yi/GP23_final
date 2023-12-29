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

    //[DisplayOnly] public bool boolForO = true;
    //[DisplayOnly] public bool boolForCat = false;

	void Start() 
	{

		_AudioSource.clip = _AudioClipO;

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
            _AudioSource.clip = _AudioClipCat;
            _AudioSource.Play();
        }
    }

    public void ExitCatPlanet() {
        if (_AudioSource.clip != _AudioClipO) {
            _AudioSource.clip = _AudioClipO;
            _AudioSource.Play();
        }
    }

    public void EnterMazePlanet() {
        if (_AudioSource.clip != _AudioClipMaze) {
            _AudioSource.clip = _AudioClipMaze;
            _AudioSource.Play();
        }
    }

    public void ExitMazePlanet() {
        if (_AudioSource.clip != _AudioClipO) {
            _AudioSource.clip = _AudioClipO;
            _AudioSource.Play();
        }
    }
	
    public void EnterWaterPlanet() {
        if (_AudioSource.clip != _AudioClipWater) {
            _AudioSource.clip = _AudioClipWater;
            _AudioSource.Play();
        }
    }

    public void ExitWaterPlanet() {
        if (_AudioSource.clip != _AudioClipO) {
            _AudioSource.clip = _AudioClipO;
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
}


