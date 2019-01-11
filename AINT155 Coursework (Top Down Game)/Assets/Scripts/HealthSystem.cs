using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }


public class HealthSystem : MonoBehaviour
{
    // Declaring variables. 

    /// <summary>
    /// Player health.
    /// </summary>
    public static int health = 100;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;



    // When the player takes damage, reduce health
    // and allow onDie.
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

