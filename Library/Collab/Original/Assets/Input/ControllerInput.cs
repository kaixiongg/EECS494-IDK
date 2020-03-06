// GENERATED AUTOMATICALLY FROM 'Assets/Input/ControllerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControllerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControllerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControllerInput"",
    ""maps"": [
        {
            ""name"": ""Capsule"",
            ""id"": ""4e5536ae-65cc-43ed-a055-3c66b930e272"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3bf010ce-183c-4eaa-a9f5-aa1026bbd0a5"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""6844fd55-3564-4865-b06d-c49203627664"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Color"",
                    ""type"": ""Button"",
                    ""id"": ""7d713c64-b7ce-4203-8c7d-d784e5b60c5e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Team"",
                    ""type"": ""Button"",
                    ""id"": ""49a1aa2b-d037-432e-834e-daaf125d4595"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlaceHookTower"",
                    ""type"": ""Button"",
                    ""id"": ""92ae9a27-5ad5-466a-b939-b7b3f5798550"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dfd822c8-e475-43c7-a393-0d487a85061a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""aea8176e-5ac2-4103-a5ea-13471b66bfa2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e03d83bf-1265-4faf-bda1-59e779c88c4f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d49545c9-8167-4e2b-bcec-628289120ac7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6af1efa1-b692-4343-aca4-23f437691225"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8ba79f93-c17c-4d49-b795-eff374b2843c"",
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
                    ""id"": ""3e01c0a7-149d-45a1-8231-513ac3b4ac67"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24d081f0-1fd1-4976-8aa5-5dd1a5a19d3f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""834a34b1-5351-4558-a1fb-d5d4225343d3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Color"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ad877473-e62f-4e08-883a-2eac79e1dc28"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Color"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9b4f893b-31c2-458a-8800-72230d968dcf"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Color"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""13282ed7-58a5-428a-ba01-6065f55759df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Team"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6de90ccf-0d1e-4ea1-b686-3ffa791720aa"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Team"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""45c96d75-2e21-47ed-b6c8-4c160bd041d0"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Team"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ba756d39-af18-4101-b483-ec81929482e6"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceHookTower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3794ab1c-ddb2-4440-ae8b-91465c12c269"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceHookTower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Capsule
        m_Capsule = asset.FindActionMap("Capsule", throwIfNotFound: true);
        m_Capsule_Move = m_Capsule.FindAction("Move", throwIfNotFound: true);
        m_Capsule_Punch = m_Capsule.FindAction("Punch", throwIfNotFound: true);
        m_Capsule_Color = m_Capsule.FindAction("Color", throwIfNotFound: true);
        m_Capsule_Team = m_Capsule.FindAction("Team", throwIfNotFound: true);
        m_Capsule_PlaceHookTower = m_Capsule.FindAction("PlaceHookTower", throwIfNotFound: true);
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

    // Capsule
    private readonly InputActionMap m_Capsule;
    private ICapsuleActions m_CapsuleActionsCallbackInterface;
    private readonly InputAction m_Capsule_Move;
    private readonly InputAction m_Capsule_Punch;
    private readonly InputAction m_Capsule_Color;
    private readonly InputAction m_Capsule_Team;
    private readonly InputAction m_Capsule_PlaceHookTower;
    public struct CapsuleActions
    {
        private @ControllerInput m_Wrapper;
        public CapsuleActions(@ControllerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Capsule_Move;
        public InputAction @Punch => m_Wrapper.m_Capsule_Punch;
        public InputAction @Color => m_Wrapper.m_Capsule_Color;
        public InputAction @Team => m_Wrapper.m_Capsule_Team;
        public InputAction @PlaceHookTower => m_Wrapper.m_Capsule_PlaceHookTower;
        public InputActionMap Get() { return m_Wrapper.m_Capsule; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CapsuleActions set) { return set.Get(); }
        public void SetCallbacks(ICapsuleActions instance)
        {
            if (m_Wrapper.m_CapsuleActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnMove;
                @Punch.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnPunch;
                @Color.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnColor;
                @Color.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnColor;
                @Color.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnColor;
                @Team.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnTeam;
                @Team.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnTeam;
                @Team.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnTeam;
                @PlaceHookTower.started -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnPlaceHookTower;
                @PlaceHookTower.performed -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnPlaceHookTower;
                @PlaceHookTower.canceled -= m_Wrapper.m_CapsuleActionsCallbackInterface.OnPlaceHookTower;
            }
            m_Wrapper.m_CapsuleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Color.started += instance.OnColor;
                @Color.performed += instance.OnColor;
                @Color.canceled += instance.OnColor;
                @Team.started += instance.OnTeam;
                @Team.performed += instance.OnTeam;
                @Team.canceled += instance.OnTeam;
                @PlaceHookTower.started += instance.OnPlaceHookTower;
                @PlaceHookTower.performed += instance.OnPlaceHookTower;
                @PlaceHookTower.canceled += instance.OnPlaceHookTower;
            }
        }
    }
    public CapsuleActions @Capsule => new CapsuleActions(this);
    public interface ICapsuleActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnColor(InputAction.CallbackContext context);
        void OnTeam(InputAction.CallbackContext context);
        void OnPlaceHookTower(InputAction.CallbackContext context);
    }
}
