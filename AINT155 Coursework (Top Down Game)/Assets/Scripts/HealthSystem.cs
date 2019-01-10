using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }


public class HealthSystem : MonoBehaviour
{
    /// <summary>
    /// Player health.
    /// </summary>
    public static int health = 100;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    public void TakeDamage(int damage)
    {
        health -= damage;
        onDamaged.Invoke(health);

        if (health < 1)
        {
            onDie.Invoke();
        }
    }
}

