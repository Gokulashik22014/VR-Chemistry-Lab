using UnityEngine;
using System.Collections.Generic;

public class DeactivateObjects : MonoBehaviour
{
    // List to hold GameObjects to deactivate
    public List<GameObject> objectsToDeactivate;

    // List to hold AudioSources to deactivate
    public List<AudioSource> audioSourcesToDeactivate;

    // Method to deactivate all listed GameObjects
    public void DeactivateAll()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null) // Check if the GameObject is not null
            {
                obj.SetActive(false);
            }
        }
        DeactivateAudioSources();
    }

    // Method to deactivate all listed AudioSources
    public void DeactivateAudioSources()
    {
        foreach (AudioSource audioSource in audioSourcesToDeactivate)
        {
            if (audioSource != null) // Check if the AudioSource is not null
            {
                audioSource.enabled = false; // Disable the AudioSource
            }
        }
    }

    // Optional: Call this method when the script starts
    void Start()
    {
        // You can call these methods here if needed
        // DeactivateAll();
        // DeactivateAudioSources();
    }
}
