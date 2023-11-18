using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("OnPlanet")]
    public float horizontal;
    public bool w;

    public PlayerInput playerInput;

    public void OnHorizontal(InputValue value)
    {
        horizontal = value.Get<float>();
    }
    public void OnW(InputValue value)
    {
        w = value.isPressed;
    }

    public void ChangeActionMap(string mapName)
    {
        playerInput.SwitchCurrentActionMap(mapName);
    }
}