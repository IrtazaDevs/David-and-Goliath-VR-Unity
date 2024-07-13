using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies; // Array to hold your enemy objects

    void Update()
    {
        // Check if all enemies are destroyed
        if (AreAllEnemiesDestroyed())
        {
            // Start a coroutine to load the next scene after a delay
            StartCoroutine(LoadNextSceneWithDelay(2f));
        }
    }

    bool AreAllEnemiesDestroyed()
    {
        // Iterate through the enemies array and check if any of them still exist
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                // At least one enemy is still alive, so not all are destroyed
                return false;
            }
        }

        // All enemies are destroyed
        return true;
    }

    IEnumerator LoadNextSceneWithDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Get the current scene build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Calculate the next scene index (you can adjust this logic as needed)
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }
}
