using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;

    public Transform leftTurnPoint;
    public Transform rightTurnPoint;

    private bool isTurning;
    private Transform currentTurnPoint;

    private void Update()
    {
        if (isTurning && currentTurnPoint != null)
        {
            // Rotate around the point only while touch is held
            transform.RotateAround(currentTurnPoint.position, Vector3.forward,
                (currentTurnPoint == leftTurnPoint ? 1 : -1) * turnSpeed * Time.deltaTime);
        }

        // Move forward in the current direction
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }

    public void HandleTouch(Vector2 touchPos)
    {
        float halfScreenWidth = Screen.width / 2f;

        if (touchPos.x < halfScreenWidth)
        {
            currentTurnPoint = leftTurnPoint;
        }
        else
        {
            currentTurnPoint = rightTurnPoint;
        }

        isTurning = true;
    }

    public void HandleTouchRelease()
    {
        // Stop rotating immediately
        isTurning = false;
        currentTurnPoint = null;
    }
}
