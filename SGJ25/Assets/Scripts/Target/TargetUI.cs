using UnityEngine;

public class TargetUI : MonoBehaviour
{
    [SerializeField] GameObject target;
    public void SpawnOnCursor()
    {
        Instantiate(target);
    }
}
