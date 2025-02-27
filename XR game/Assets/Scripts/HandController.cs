using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    XRController controller;

    public Hand hand;
    public InputActionReference gripAction;
    public InputActionReference triggerAction;


    void Start()
    {
        controller = GetComponent<XRController>();
    }

    void Update()
    {
        hand.SetGrip(gripAction.action.ReadValue<float>());
        hand.SetTrigger(triggerAction.action.ReadValue<float>());


    }
}
