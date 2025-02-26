using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour

{

    [SerializeField] private float treshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;

    void Start(){
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update(){

        if(!isPressed && GetValue() + treshold >= 1)
            Pressed();
        if(isPressed && GetValue() + treshold <= 0)
            Released();
    }

    private float GetValue(){
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;

        if(Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed(){
        isPressed = true;
        onPressed.Invoke();
    }

    private void Released(){
        isPressed = false;
        onReleased.Invoke();

    }
}
