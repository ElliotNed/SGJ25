using UnityEngine;

public class TargetUI : MonoBehaviour
{
    [SerializeField] GameObject target;
    private Vector3 mousePos;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void SpawnOnCursor()
    {
        Instantiate(target, mousePos, Quaternion.identity);
    }
}
