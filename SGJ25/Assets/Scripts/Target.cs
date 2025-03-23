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

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x-4, 1, mousePos.z-0.3f);
        Debug.Log(mousePos);
    }

    public void PlaceTarget()
    {
        isPlaced = true;
    }
}
