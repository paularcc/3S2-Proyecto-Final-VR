using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickupObject : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private ScoreManager scoreManager;

    void Awake()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();

        if (grabInteractable != null)
        {
            // Subscribe to the selectEntered event (replaces onSelectEntered)
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Increase the score when the star is grabbed
        if (scoreManager != null)
        {
            scoreManager.IncreaseScore();
        }

        // Disable or destroy the star (making it disappear)
        gameObject.SetActive(false);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Optional logic when releasing the object (if needed)
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            // Unsubscribe from the events to prevent memory leaks
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }
}


