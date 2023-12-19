using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class PreviewPlanet : MonoBehaviour
{
    public PlayableDirector timelineCatPlanet;     // cat
    public PlayableDirector timelineWaterPlanet;
    public PlayableDirector timelineMazePlanet;

    public Transform vcamCatPlanetTF;
    public Transform vcamWaterPlanetTF;
    public Transform vcamMazePlanetTF;

    // public PlayerController_new player;
    public GameObject player;

    public void PlayCatPlanetPreview()
    {
        timelineCatPlanet.Play();
        //player.Lock();
    }
    public void PlayWaterPlanetPreview()
    {
        timelineWaterPlanet.Play();
        //player.Lock();
    }
    public void PlayMazePlanetPreview()
    {
        timelineMazePlanet.Play();
        //player.Lock();
    }

    void Update()
    {
        Quaternion r = player.transform.rotation;
        vcamCatPlanetTF.rotation = r;
        vcamWaterPlanetTF.rotation = r;
        vcamMazePlanetTF.rotation = r;
    }

}
