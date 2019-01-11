using UnityEngine;

public class HurtTrigger : MonoBehaviour
{
    // Declaring variables.
    public int damage = 1;

    public float resetTime = 5f;



    // When the "Other Tim" collides with the player,
    // the player takes damage.
    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

        GetComponent<Collider2D>().enabled = false;

        Invoke("ResetTrigger", resetTime);
    }

    // This is only allowed to happen every so often.
    private void ResetTrigger()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
