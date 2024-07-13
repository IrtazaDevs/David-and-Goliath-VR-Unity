using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public Slider slider;
    public float duration = 60f; // Duration in seconds

    private float currentTime = 0f;

    void Start()
    {
        // Initialize the slider value to 0
        if (slider != null)
        {
            slider.value = 0f;
        }
    }

    void Update()
    {
        // Check if the slider and duration are set
        if (slider != null && duration > 0f)
        {
            // Increment the current time
            currentTime += Time.deltaTime;

            // Calculate the slider value based on the current time and duration
            float sliderValue = Mathf.Clamp01(currentTime / duration);

            // Update the slider value
            slider.value = sliderValue;

            // Check if the duration has been reached
            if (currentTime >= duration)
            {
                // Optionally, you can perform some actions when the fill is complete
                Debug.Log("Fill is complete!");

                // Load a new scene (Change the scene index as needed)
                SceneManager.LoadScene(1);
            }
        }
    }

    // Function to be called when the button is clicked (assigned in the Unity Editor)
    public void StartGame()
    {
        // Optionally, you can perform some actions before starting the fill
        Debug.Log("Starting the fill...");

        // Reset the current time when starting the fill
        currentTime = 0f;
    }

    public void startfirstLevel()
    {
        SceneManager.LoadScene(1);
    }

}
