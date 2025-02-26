using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour

{

    [SerializeField] private float treshold = 0.1f;
    [SerializeField] private float deadZone = 0.1f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;
    public ButtonGame teleportManager;

    void Start(){
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update(){

        if(!isPressed && GetValue() >= 1 - treshold){
            Pressed();
        }
        if(isPressed && GetValue() <= deadZone + 0.05f){
            Released();
        }
    }

    private float GetValue(){
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if(Mathf.Abs(value) < deadZone)
            value = 0;

        //Debug.Log($"Button {gameObject.name} Value: {value}");

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed(){
        isPressed = true;
        onPressed.Invoke();
        Debug.Log($"Pressed: {gameObject.name} - Value: {GetValue()}");

        if (teleportManager != null)
        {
        teleportManager.ButtonPressed(gameObject.name);
        }
    }

    private void Released(){
        isPressed = false;
        onReleased.Invoke();
        Debug.Log($"Released: {gameObject.name} - Value: {GetValue()}");

        
    }
}
