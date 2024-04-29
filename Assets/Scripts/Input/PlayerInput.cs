//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""3f4ef894-d04b-4736-9506-8d143516498e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b0497752-bf25-42e3-ba8c-32b6a98266ec"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""1bd9dd15-572f-4fa7-95c2-f019dd055888"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""1d7ed74c-0e18-45e1-87b1-3f4e87ed9dc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""faddfb7f-dbec-4ed7-9b03-4101b80180dd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""7d3a9c93-6047-4d60-9e05-5a796db05a83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetFireMode0"",
                    ""type"": ""Button"",
                    ""id"": ""2ace74a0-450a-4355-a0f3-e83b5e040b5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetFireMode1"",
                    ""type"": ""Button"",
                    ""id"": ""395df0c2-baef-4621-a732-d621aae0691c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetFireMode2"",
                    ""type"": ""Button"",
                    ""id"": ""cf0dddc5-74f0-4a83-ad0e-de44ca24ebb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetFireMode3"",
                    ""type"": ""Button"",
                    ""id"": ""67e2443b-a2f3-4acb-b8b4-8eef6d728fcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetFireMode4"",
                    ""type"": ""Button"",
                    ""id"": ""7c5b10b1-07a3-4484-a5d1-2ec40a89d45b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Left/Right"",
                    ""id"": ""d02eb8a2-4b05-482c-9b58-135c38e4357f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2604eeb3-fe5a-4b9f-91c7-131d7e283aff"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b01197d9-d904-4701-8ba7-bbb80a8d9780"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cb9eaef7-2e20-4111-bc90-86c57cc36e1c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b9cd426-cd38-43e8-b92c-20b1031e9300"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afb05b71-4bc6-4d9a-a7bc-3d31f7f29936"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af4ff38f-ce32-4573-ae58-416a70068d74"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71b8e072-a090-4455-94c3-5f9b382b975c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetFireMode0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21abb051-a5be-455e-b702-257d61312ba8"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetFireMode1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""848578df-6fe3-4c4f-94e4-a0ca03d44fe0"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetFireMode2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e655c31f-721c-4397-b474-48ba7c845312"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetFireMode3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9aa77e7e-8c71-46a6-8811-66b5aad22291"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetFireMode4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""53f0dc87-b1e6-498e-88d8-41e7b360615b"",
            ""actions"": [
                {
                    ""name"": ""Resume"",
                    ""type"": ""Button"",
                    ""id"": ""32eb38eb-4296-4f3f-a6ac-375998195ebf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""798c4bd0-7e5f-40dc-99cf-905d96433add"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Resume"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_Look = m_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_Gameplay_Fire = m_Gameplay.FindAction("Fire", throwIfNotFound: true);
        m_Gameplay_SetFireMode0 = m_Gameplay.FindAction("SetFireMode0", throwIfNotFound: true);
        m_Gameplay_SetFireMode1 = m_Gameplay.FindAction("SetFireMode1", throwIfNotFound: true);
        m_Gameplay_SetFireMode2 = m_Gameplay.FindAction("SetFireMode2", throwIfNotFound: true);
        m_Gameplay_SetFireMode3 = m_Gameplay.FindAction("SetFireMode3", throwIfNotFound: true);
        m_Gameplay_SetFireMode4 = m_Gameplay.FindAction("SetFireMode4", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Resume = m_UI.FindAction("Resume", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Look;
    private readonly InputAction m_Gameplay_Fire;
    private readonly InputAction m_Gameplay_SetFireMode0;
    private readonly InputAction m_Gameplay_SetFireMode1;
    private readonly InputAction m_Gameplay_SetFireMode2;
    private readonly InputAction m_Gameplay_SetFireMode3;
    private readonly InputAction m_Gameplay_SetFireMode4;
    public struct GameplayActions
    {
        private @PlayerInput m_Wrapper;
        public GameplayActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Look => m_Wrapper.m_Gameplay_Look;
        public InputAction @Fire => m_Wrapper.m_Gameplay_Fire;
        public InputAction @SetFireMode0 => m_Wrapper.m_Gameplay_SetFireMode0;
        public InputAction @SetFireMode1 => m_Wrapper.m_Gameplay_SetFireMode1;
        public InputAction @SetFireMode2 => m_Wrapper.m_Gameplay_SetFireMode2;
        public InputAction @SetFireMode3 => m_Wrapper.m_Gameplay_SetFireMode3;
        public InputAction @SetFireMode4 => m_Wrapper.m_Gameplay_SetFireMode4;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
            @SetFireMode0.started += instance.OnSetFireMode0;
            @SetFireMode0.performed += instance.OnSetFireMode0;
            @SetFireMode0.canceled += instance.OnSetFireMode0;
            @SetFireMode1.started += instance.OnSetFireMode1;
            @SetFireMode1.performed += instance.OnSetFireMode1;
            @SetFireMode1.canceled += instance.OnSetFireMode1;
            @SetFireMode2.started += instance.OnSetFireMode2;
            @SetFireMode2.performed += instance.OnSetFireMode2;
            @SetFireMode2.canceled += instance.OnSetFireMode2;
            @SetFireMode3.started += instance.OnSetFireMode3;
            @SetFireMode3.performed += instance.OnSetFireMode3;
            @SetFireMode3.canceled += instance.OnSetFireMode3;
            @SetFireMode4.started += instance.OnSetFireMode4;
            @SetFireMode4.performed += instance.OnSetFireMode4;
            @SetFireMode4.canceled += instance.OnSetFireMode4;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
            @SetFireMode0.started -= instance.OnSetFireMode0;
            @SetFireMode0.performed -= instance.OnSetFireMode0;
            @SetFireMode0.canceled -= instance.OnSetFireMode0;
            @SetFireMode1.started -= instance.OnSetFireMode1;
            @SetFireMode1.performed -= instance.OnSetFireMode1;
            @SetFireMode1.canceled -= instance.OnSetFireMode1;
            @SetFireMode2.started -= instance.OnSetFireMode2;
            @SetFireMode2.performed -= instance.OnSetFireMode2;
            @SetFireMode2.canceled -= instance.OnSetFireMode2;
            @SetFireMode3.started -= instance.OnSetFireMode3;
            @SetFireMode3.performed -= instance.OnSetFireMode3;
            @SetFireMode3.canceled -= instance.OnSetFireMode3;
            @SetFireMode4.started -= instance.OnSetFireMode4;
            @SetFireMode4.performed -= instance.OnSetFireMode4;
            @SetFireMode4.canceled -= instance.OnSetFireMode4;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Resume;
    public struct UIActions
    {
        private @PlayerInput m_Wrapper;
        public UIActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Resume => m_Wrapper.m_UI_Resume;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Resume.started += instance.OnResume;
            @Resume.performed += instance.OnResume;
            @Resume.canceled += instance.OnResume;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Resume.started -= instance.OnResume;
            @Resume.performed -= instance.OnResume;
            @Resume.canceled -= instance.OnResume;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSetFireMode0(InputAction.CallbackContext context);
        void OnSetFireMode1(InputAction.CallbackContext context);
        void OnSetFireMode2(InputAction.CallbackContext context);
        void OnSetFireMode3(InputAction.CallbackContext context);
        void OnSetFireMode4(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnResume(InputAction.CallbackContext context);
    }
}
