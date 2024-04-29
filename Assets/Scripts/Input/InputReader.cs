using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input Reader")]
public class InputReader : ScriptableObject, PlayerInput.IGameplayActions, PlayerInput.IUIActions
{
    PlayerInput playerInput;

    public event Action<float> MoveEvent;
    public event Action JumpEvent;
    public event Action JumpEndEvent;

    public event Action<Vector2> LookEvent;
    public event Action FireEvent;
    public event Action FireEndEvent;
    public event Action SetFireModeEvent0;
    public event Action SetFireModeEvent1;
    public event Action SetFireModeEvent2;
    public event Action SetFireModeEvent3;
    public event Action SetFireModeEvent4;

    public event Action PauseEvent;
    public event Action ResumeEvent;

    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInput();

            playerInput.Gameplay.SetCallbacks(this);
            playerInput.UI.SetCallbacks(this);

            EnableGameplayInput();
        }
    }

    public void EnableGameplayInput()
    {
        playerInput.Gameplay.Enable();
        playerInput.UI.Disable();
    }

    public void EnableUIInput()
    {
        playerInput.Gameplay.Disable();
        playerInput.UI.Enable();
    }

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpEvent?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            JumpEndEvent?.Invoke();
        }
    }

    void PlayerInput.IGameplayActions.OnLook(InputAction.CallbackContext context)
    {
        LookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    void PlayerInput.IGameplayActions.OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            FireEvent?.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            FireEndEvent?.Invoke();
        }
    }

    void PlayerInput.IGameplayActions.OnSetFireMode0(InputAction.CallbackContext context)
    {
        SetFireModeEvent0?.Invoke();
    }

    void PlayerInput.IGameplayActions.OnSetFireMode1(InputAction.CallbackContext context)
    {
        SetFireModeEvent1?.Invoke();
    }

    void PlayerInput.IGameplayActions.OnSetFireMode2(InputAction.CallbackContext context)
    {
        SetFireModeEvent2?.Invoke();
    }

    void PlayerInput.IGameplayActions.OnSetFireMode3(InputAction.CallbackContext context)
    {
        SetFireModeEvent3?.Invoke();
    }

    void PlayerInput.IGameplayActions.OnSetFireMode4(InputAction.CallbackContext context)
    {
        SetFireModeEvent4?.Invoke();
    }

    public void OnPause(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            PauseEvent?.Invoke();
            EnableUIInput();
        }
    }

    public void OnResume(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ResumeEvent?.Invoke();
            EnableGameplayInput();
        }
    }
}
