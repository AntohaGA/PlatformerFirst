using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);

        if (collision.GetComponent<PlayerMovement>())
        {
            Destroy(gameObject);
        }
    }
}