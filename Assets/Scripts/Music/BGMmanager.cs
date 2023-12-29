using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMmanager : MonoBehaviour
{
    public AudioSource _AudioSource;

	public AudioClip _AudioClip1;
	public AudioClip _AudioClip2;

	void Start() 
	{

		_AudioSource.clip = _AudioClip1;

		_AudioSource.Play();
	
	}
	

	void Update () 
	{

		if (Input.GetKeyDown(KeyCode.S))
		{

			if (_AudioSource.clip == _AudioClip1)
			{

				_AudioSource.clip = _AudioClip2;

				_AudioSource.Play();

			}

			else
			{
				
				_AudioSource.clip = _AudioClip1;
				
				_AudioSource.Play();

			}

		}
	
    }

}

