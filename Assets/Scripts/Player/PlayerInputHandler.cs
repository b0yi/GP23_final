using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Movement")]
    public float movement;
    public float turn;

    [Space(10)]
    public bool jump;

    [Space(10)]
    public bool ignition;

    public PlayerInput playerInput;

    public void OnMovement(InputValue value)
    {
        movement = value.Get<float>();
    }


    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }

    public void OnIgnition(InputValue value)
    {
        ignition = value.isPressed;
    }


    public void OnTurn(InputValue value)
    {
        turn = value.Get<float>();
    }

    public void ChangeActionMap(string mapName)
    {
        playerInput.SwitchCurrentActionMap(mapName);
        movement = 0;
        turn = 0;
        jump = false;
        ignition = false;
    }





}