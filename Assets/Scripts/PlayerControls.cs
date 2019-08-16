// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""75cb9dd7-bd8b-490a-bc45-e83c38defabf"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""d5875156-6114-40e8-bfac-9171c0f20f6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""c55ad02d-49fb-42bb-b815-b31198a1837d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""3365860c-8b80-41b1-a9b5-04555a662daf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""717a8809-d33e-4da8-ae65-7714c0c4786e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""e0f68d3d-f1fa-43ea-9291-f182378a283c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fd0e47e5-e571-4e62-a8a7-a06d8ca4cda5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1128cbe0-dca0-4970-8d02-273a008c47d1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0118b7e8-19aa-4dee-b2b1-2246bd0ccb88"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ccfd5f6-60ca-470e-a671-3fbf3859af76"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a483d9fd-6b2d-414e-8492-0109b2c3c79d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65fafd05-9f32-40d5-8c52-f32633aef710"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4f196fa-9d48-49e0-896d-dca31346f77a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca41cf09-99e3-4410-bf20-588c74cde73d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42c71833-e700-4144-bcf1-a46ff4ac6ad0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.GetActionMap("Gameplay");
        m_Gameplay_Left = m_Gameplay.GetAction("Left");
        m_Gameplay_Right = m_Gameplay.GetAction("Right");
        m_Gameplay_Up = m_Gameplay.GetAction("Up");
        m_Gameplay_Down = m_Gameplay.GetAction("Down");
        m_Gameplay_Action = m_Gameplay.GetAction("Action");
    }

    ~PlayerControls()
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Left;
    private readonly InputAction m_Gameplay_Right;
    private readonly InputAction m_Gameplay_Up;
    private readonly InputAction m_Gameplay_Down;
    private readonly InputAction m_Gameplay_Action;
    public struct GameplayActions
    {
        private PlayerControls m_Wrapper;
        public GameplayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Gameplay_Left;
        public InputAction @Right => m_Wrapper.m_Gameplay_Right;
        public InputAction @Up => m_Wrapper.m_Gameplay_Up;
        public InputAction @Down => m_Wrapper.m_Gameplay_Down;
        public InputAction @Action => m_Wrapper.m_Gameplay_Action;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                Left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                Left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                Right.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                Right.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                Right.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                Up.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                Up.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                Up.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                Action.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                Action.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                Action.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Left.started += instance.OnLeft;
                Left.performed += instance.OnLeft;
                Left.canceled += instance.OnLeft;
                Right.started += instance.OnRight;
                Right.performed += instance.OnRight;
                Right.canceled += instance.OnRight;
                Up.started += instance.OnUp;
                Up.performed += instance.OnUp;
                Up.canceled += instance.OnUp;
                Down.started += instance.OnDown;
                Down.performed += instance.OnDown;
                Down.canceled += instance.OnDown;
                Action.started += instance.OnAction;
                Action.performed += instance.OnAction;
                Action.canceled += instance.OnAction;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
    }
}
