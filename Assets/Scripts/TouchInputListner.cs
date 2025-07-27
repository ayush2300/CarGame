using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TouchInputListener : MonoBehaviour
{
    [Header("Touch Events")]
    public UnityEvent<Vector2> OnTouchPerformed;
    public UnityEvent OnTouchReleased;

    private CarInputActions inputActions;

    private void Awake()
    {
        inputActions = new CarInputActions();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.TouchPress.started += ctx => HandleTouch(ctx);
        inputActions.Gameplay.TouchPress.performed += ctx => HandleTouch(ctx);
        inputActions.Gameplay.TouchPress.canceled += ctx => HandleTouchEnd();
        inputActions.Gameplay.TouchPress.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.TouchPress.Disable();
    }

    private void HandleTouch(InputAction.CallbackContext ctx)
    {
        if (Touchscreen.current == null) return;

        Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
        OnTouchPerformed?.Invoke(touchPos);
    }

    private void HandleTouchEnd()
    {
        OnTouchReleased?.Invoke();
    }
}
