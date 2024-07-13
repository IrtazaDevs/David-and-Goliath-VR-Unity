using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Rock"
        if (collision.gameObject.CompareTag("rock"))
        {
            // Destroy the game object this script is attached to
            Destroy(gameObject);
        }
    }
}
