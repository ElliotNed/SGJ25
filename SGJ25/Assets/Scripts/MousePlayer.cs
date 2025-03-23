using UnityEngine;
using UnityEngine.InputSystem;

public class MousePlayer : MonoBehaviour
{
    [SerializeField] float guessRadius = .2f;
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

    public void RotateTarget(InputAction.CallbackContext context)
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if(context.started && targets.Length > 0)
        {
            foreach(var target in targets)
            {
                if(!target.GetComponent<Target>().isPlaced)
                {
                    
                }
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
                    LevelManager.NextLevel();
                /*
                else
                    afficher Panel UI défaite avec bouton pour reload Scene
                */
                    
            }
        }
    }
}
