using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerController;
    private InputHandler _inputHandler;

    public ParticleSystem fire;
    public ParticleSystem speed;
    public GameObject playerLight;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _inputHandler = GetComponent<InputHandler>();
    }

    void Update()
    {
        if (_playerController.stage == "OnPlanet")
        {
            playerLight.SetActive(false);
            if (_inputHandler.horizontal != 0)
            {
                _animator.SetInteger("state", 1);
            }
            if (_playerController.direction)
            {
                _animator.SetInteger("state", 2);
            }

            if (_inputHandler.w && _animator.GetCurrentAnimatorStateInfo(0).IsName("Spaceship"))
            {
                fire.Play();
            }



            if ((_inputHandler.horizontal == 0) && (!_playerController.direction))
            {
                _animator.SetInteger("state", 0);
            }
        }

        if (_playerController.stage == "InSpace")
        {
            playerLight.SetActive(true);
            if (_inputHandler.w)
            {
                _animator.SetBool("accel", true);
                fire.Play();
                speed.Play();
            }
            else
            {
                _animator.SetBool("accel", false);
            }
        }


        _animator.SetBool("dead", _playerController.IsHurtByEnemies());
    }
}
