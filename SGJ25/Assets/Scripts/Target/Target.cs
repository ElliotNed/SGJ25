using UnityEngine;
using UnityEngine.InputSystem;

public class Target : MonoBehaviour
{
    public Vector3 mousePos;

    public bool isPlaced = false;

    public bool isRightTarget = false; //have to be only one right target

    private void Update()
    {
        if (isPlaced)
            return;


        

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //screenPointToRay
        
        transform.position = new Vector3(mousePos.x, 1, mousePos.z);
    }

    public void PlaceTarget()
    {
        isPlaced = true;
    }

    public void Rotate(float scrollAmount)
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + scrollAmount*15, transform.rotation.eulerAngles.z));
    }
}
