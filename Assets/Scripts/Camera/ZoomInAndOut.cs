using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZoomInAndOut : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public PlayerController_new playerController_New;
    [DisplayOnly] public float targetOrthographicSize;
    public float changeOrthographicSpeed;
    public float orthographicSizeInSpace;
    public float orthographicSizeOnPlanet;
    private PlayerState _playerState;

    // Update is called once per frame
    void Update()
    {
        _playerState = playerController_New.playerState;
        if (_playerState == PlayerState.InSpace)
        {
            targetOrthographicSize = orthographicSizeInSpace;
        }
        else
        {
            targetOrthographicSize = orthographicSizeOnPlanet;
        }

        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, targetOrthographicSize, changeOrthographicSpeed * Time.deltaTime);
    }
}
