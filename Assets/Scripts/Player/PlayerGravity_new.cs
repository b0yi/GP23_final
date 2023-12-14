using UnityEngine;

public class PlayerGravity_new : MonoBehaviour
{
    public PlanetGravity planetGravity; // see PlanetGravity.cs

    private PlayerState _playerState;



    void Update()
    {
        _playerState = GetComponent<PlayerController_new>().playerState;
    }

    void FixedUpdate()
    {
        if (_playerState != PlayerState.InSpace)
            planetGravity.AddGravity(transform);
    }
}