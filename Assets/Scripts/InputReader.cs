using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Control;



[CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/ Input Reader")]
public class InputReader : ScriptableObject, IPlayerActions
{
    public event Action PrimaryFireEvent;
    public event Action<Vector2> MoveEvent;
    private Control control;
    public Vector2 Aimposition { get; private set; }
    private void OnEnable()
    {
        if (control == null)
        {
            control = new Control();
            control.Player.SetCallbacks(this);
        }
        control.Player.Enable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
      //  Debug.Log("the event is firing");
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnPrimaryfire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("the onprimaryfire event is triggering");
            PrimaryFireEvent?.Invoke();
        }
       
      
    }
    private void OnDisable()
    {
        control.Player.Disable();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
       Aimposition = context.ReadValue<Vector2>();
       // Debug.Log("is reading value" +  Aimposition);   
    }
}
