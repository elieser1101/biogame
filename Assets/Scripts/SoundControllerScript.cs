using UnityEngine;

// Make sure there is an Audio Source component on the GameObject
[RequireComponent(typeof(AudioSource))]
public class SoundControllerScript : MonoBehaviour
{
    public float startingPitch = 1/5f;
    public float timeToIncrease = 10f;
    public float fadeIn = 5f;
    AudioSource audioSource;

    void Start()
    {
        // Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        // Initialize the pitch
        audioSource.pitch = startingPitch;
        StartCoroutine(AudioController.FadeIn(audioSource, fadeIn));
    }

    void Update()
    {
        // While the pitch is below 2, increase it as time passes.
        if (audioSource.pitch < 2)
        {
            audioSource.pitch += Time.deltaTime * startingPitch / timeToIncrease;
        }
    }
}