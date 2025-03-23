using UnityEngine;
using UnityEngine.InputSystem;

public class MousePlayer : MonoBehaviour
{
    [SerializeField] float guessRadius = .2f;
    public bool victory = false;
    public void PlaceTarget(InputAction.CallbackContext context)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if (context.started && targets.Length > 0)
        {
            foreach (var target in targets)
            {
                target.GetComponent<Target>().PlaceTarget();
            }
        }
    }

    public void GuessTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (var target in targets)
        {
            foreach(var nearbyObject in Physics.OverlapSphere(target.transform.position, guessRadius))
            {
                if (nearbyObject.TryGetComponent(out RightTarget success))
                    victory = true;

            }
        }
    }
}
