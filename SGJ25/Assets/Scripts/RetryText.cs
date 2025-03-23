using Unity.VisualScripting;
using UnityEngine;

public class RetryText : MonoBehaviour
{
    [SerializeField] float cooldown = 2;
    float cooldownStart = -100;
    private void OnEnable()
    {
        cooldownStart = Time.time;
    }

    private void Update()
    {
        if (cooldownStart + cooldown < Time.time)
            gameObject.SetActive(false);
    }
}
