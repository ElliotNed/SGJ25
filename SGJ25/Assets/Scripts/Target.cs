using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    public Vector3 mousePos;

    private bool isPlaced = false;

    private void Update()
    {
        if (isPlaced)
            return;

        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if(Physics.Raycast(mousePos, Vector3.down, out RaycastHit raycastHit))
        {
            Debug.Log(raycastHit.point.y);
            transform.position = new Vector3(mousePos.x, raycastHit.point.y, mousePos.z);
        }
    }

    public void PlaceTarget()
    {
        isPlaced = true;
    }
}
