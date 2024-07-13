using UnityEngine;

public class RotateOnCollision : MonoBehaviour
{
    public float rotationAngle = 180f;
    public float moveSpeed = 5f;

    private void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("invWall"))
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        transform.Rotate(Vector3.up, rotationAngle);
    }

    // Method to set the move speed to zero
    public void SetMoveSpeedToZero()
    {
        moveSpeed = 0f;
    }
}
