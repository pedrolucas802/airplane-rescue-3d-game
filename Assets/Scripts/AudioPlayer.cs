using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioClip; // Reference to the MP3 audio clip
    public AudioMixerGroup outputMixerGroup; // Optional: specify an audio mixer group for the audio

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        // Set the output mixer group if specified
        if (outputMixerGroup != null)
        {
            audioSource.outputAudioMixerGroup = outputMixerGroup;
        }

        // Load and play the audio clip
        LoadAudio(audioClip);
    }

    void LoadAudio(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Failed to load audio clip: AudioClip is null");
        }
    }

    // Method to stop the audio
    public void StopAudio()
    {
        audioSource.Stop();
    }

    // Method to pause the audio
    public void PauseAudio()
    {
        audioSource.Pause();
    }

    // Method to resume the audio
    public void ResumeAudio()
    {
        audioSource.UnPause();
    }
}