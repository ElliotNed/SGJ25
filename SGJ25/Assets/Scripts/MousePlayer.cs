using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MousePlayer : MonoBehaviour
{
    [SerializeField] float guessRadius = .2f;
    private bool victory = false;
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
        if(context.performed && targets.Length > 0)
        {
            foreach(var target in targets)
            {
                if(!target.GetComponent<Target>().isPlaced)
                {
                    target.GetComponent<Target>().Rotate(context.ReadValue<Vector2>().y);
                }
            }
        }
    }

    public void GuessTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (var target in targets)
        {
            bool foundTarget = false;
            foreach(var nearbyObject in Physics.OverlapSphere(target.transform.position, guessRadius))
            {
                //victory
                if (nearbyObject.TryGetComponent(out RightTarget success))
                {
                    SceneManager.LoadScene(0);
                    foundTarget = true;
                    if(!victory)
                        ScoreManager.Victory();

                    victory = true;
                    Debug.Log("victory " + ScoreManager.score);
                }
                if (!foundTarget)
                {
                    Destroy(target);
                    //afficher erreur
                    ScoreManager.Loose();
                    Debug.Log("loose " +ScoreManager.score);
                }
            }
        }

        if(victory)
            LevelManager.NextLevel();
    }
}
