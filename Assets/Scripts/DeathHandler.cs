using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private Animator childAnimator;
    public AudioClip deathSound; // Assign the death sound effect in the Inspector
    private AudioSource audioSource;

    private RotateOnCollision rotateScript; // Reference to the RotateOnCollision script

    private bool isDead = false;
    private float destroyDelay = 3f;

    private void Start()
    {
        // Get the Animator component from the child object
        childAnimator = GetComponentInChildren<Animator>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Get the RotateOnCollision script
        rotateScript = GetComponent<RotateOnCollision>();
        if (rotateScript == null)
        {
            Debug.LogError("RotateOnCollision script not found!");
        }

        if (childAnimator != null)
        {
            Debug.Log("Animator component found!");
        }
        else
        {
            Debug.LogError("Animator component not found!");
        }
    }

    private void Update()
    {
        // Check if isDead is true and start the destruction countdown
        if (isDead)
        {
            destroyDelay -= Time.deltaTime;
            if (destroyDelay <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {
            Debug.Log("Collision with rock detected!");

            // Set the isDead boolean to true in the animator component
            if (childAnimator != null)
            {
                childAnimator.SetBool("isDead", true);

                if (deathSound != null && audioSource != null)
                {
                    // Play the death sound effect
                    audioSource.PlayOneShot(deathSound);
                }
                else
                {
                    Debug.LogWarning("Death sound or Audio Source not set!");
                }
            }
            else
            {
                Debug.LogWarning("Animator component not found. Cannot set isDead.");
            }

            // Modify the moveSpeed variable in RotateOnCollision script
            if (rotateScript != null)
            {
                rotateScript.moveSpeed = 0f;
            }
            else
            {
                Debug.LogWarning("RotateOnCollision script not found. Cannot modify moveSpeed.");
            }

            // Set isDead to true to trigger destruction countdown
            isDead = true;

            // Destroy both objects after collision
            Destroy(collision.gameObject);
        }
    }
}
