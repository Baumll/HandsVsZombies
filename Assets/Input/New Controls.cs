//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/New Controls.inputactions
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

public partial class @NewControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Fireball"",
            ""id"": ""19f38221-2cb0-42fd-8730-71683268876b"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Value"",
                    ""id"": ""50244aa6-8d62-4f75-a601-fe751d66ca4b"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TriggerLeft"",
                    ""type"": ""Value"",
                    ""id"": ""123a14c5-db7d-4b9f-9eb4-efd4eaf7088a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TriggerRight"",
                    ""type"": ""Value"",
                    ""id"": ""4135d167-bfc0-453a-813b-dfd377643b84"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FireLeft"",
                    ""type"": ""Button"",
                    ""id"": ""4d69ad30-31fc-4f8a-8672-d07afbd29705"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FireRight"",
                    ""type"": ""Button"",
                    ""id"": ""f800cd9f-70bd-4b98-8707-cf42051e2fa4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1b69fc26-127e-41ff-867e-899120a3ca33"",
                    ""path"": ""<XRController>{LeftHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9286e42-c67d-4480-94b4-565fb27c7f06"",
                    ""path"": ""<XRController>{LeftHand}/{Trigger}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e70ead4b-c74b-4a57-a371-478a31b94228"",
                    ""path"": ""<XRController>{LeftHand}/{TriggerTouch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9b9a84c-a295-4188-a9cd-defae1e7305a"",
                    ""path"": ""<XRController>{LeftHand}/{Trigger}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b843c975-2a2a-4cdf-8a84-3a6e3e8480a2"",
                    ""path"": ""<XRController>{LeftHand}/{TriggerTouch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e92025a-43e5-4a1e-a2a5-edf604329a0f"",
                    ""path"": ""<XRController>{LeftHand}/{PrimaryButton}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9635cd00-0c2e-4b03-96e0-442a980d99d5"",
                    ""path"": ""<XRController>{LeftHand}/{PrimaryTouch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45523968-b8d2-4ffc-a050-1f98a0ca5335"",
                    ""path"": ""<XRController>{RightHand}/{PrimaryButton}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbc9bed3-21b0-4570-b537-b5757310c418"",
                    ""path"": ""<XRController>{RightHand}/{PrimaryTouch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Fireball
        m_Fireball = asset.FindActionMap("Fireball", throwIfNotFound: true);
        m_Fireball_Newaction = m_Fireball.FindAction("New action", throwIfNotFound: true);
        m_Fireball_TriggerLeft = m_Fireball.FindAction("TriggerLeft", throwIfNotFound: true);
        m_Fireball_TriggerRight = m_Fireball.FindAction("TriggerRight", throwIfNotFound: true);
        m_Fireball_FireLeft = m_Fireball.FindAction("FireLeft", throwIfNotFound: true);
        m_Fireball_FireRight = m_Fireball.FindAction("FireRight", throwIfNotFound: true);
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

    // Fireball
    private readonly InputActionMap m_Fireball;
    private List<IFireballActions> m_FireballActionsCallbackInterfaces = new List<IFireballActions>();
    private readonly InputAction m_Fireball_Newaction;
    private readonly InputAction m_Fireball_TriggerLeft;
    private readonly InputAction m_Fireball_TriggerRight;
    private readonly InputAction m_Fireball_FireLeft;
    private readonly InputAction m_Fireball_FireRight;
    public struct FireballActions
    {
        private @NewControls m_Wrapper;
        public FireballActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Fireball_Newaction;
        public InputAction @TriggerLeft => m_Wrapper.m_Fireball_TriggerLeft;
        public InputAction @TriggerRight => m_Wrapper.m_Fireball_TriggerRight;
        public InputAction @FireLeft => m_Wrapper.m_Fireball_FireLeft;
        public InputAction @FireRight => m_Wrapper.m_Fireball_FireRight;
        public InputActionMap Get() { return m_Wrapper.m_Fireball; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FireballActions set) { return set.Get(); }
        public void AddCallbacks(IFireballActions instance)
        {
            if (instance == null || m_Wrapper.m_FireballActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FireballActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
            @TriggerLeft.started += instance.OnTriggerLeft;
            @TriggerLeft.performed += instance.OnTriggerLeft;
            @TriggerLeft.canceled += instance.OnTriggerLeft;
            @TriggerRight.started += instance.OnTriggerRight;
            @TriggerRight.performed += instance.OnTriggerRight;
            @TriggerRight.canceled += instance.OnTriggerRight;
            @FireLeft.started += instance.OnFireLeft;
            @FireLeft.performed += instance.OnFireLeft;
            @FireLeft.canceled += instance.OnFireLeft;
            @FireRight.started += instance.OnFireRight;
            @FireRight.performed += instance.OnFireRight;
            @FireRight.canceled += instance.OnFireRight;
        }

        private void UnregisterCallbacks(IFireballActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
            @TriggerLeft.started -= instance.OnTriggerLeft;
            @TriggerLeft.performed -= instance.OnTriggerLeft;
            @TriggerLeft.canceled -= instance.OnTriggerLeft;
            @TriggerRight.started -= instance.OnTriggerRight;
            @TriggerRight.performed -= instance.OnTriggerRight;
            @TriggerRight.canceled -= instance.OnTriggerRight;
            @FireLeft.started -= instance.OnFireLeft;
            @FireLeft.performed -= instance.OnFireLeft;
            @FireLeft.canceled -= instance.OnFireLeft;
            @FireRight.started -= instance.OnFireRight;
            @FireRight.performed -= instance.OnFireRight;
            @FireRight.canceled -= instance.OnFireRight;
        }

        public void RemoveCallbacks(IFireballActions instance)
        {
            if (m_Wrapper.m_FireballActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFireballActions instance)
        {
            foreach (var item in m_Wrapper.m_FireballActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FireballActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FireballActions @Fireball => new FireballActions(this);
    public interface IFireballActions
    {
        void OnNewaction(InputAction.CallbackContext context);
        void OnTriggerLeft(InputAction.CallbackContext context);
        void OnTriggerRight(InputAction.CallbackContext context);
        void OnFireLeft(InputAction.CallbackContext context);
        void OnFireRight(InputAction.CallbackContext context);
    }
}
