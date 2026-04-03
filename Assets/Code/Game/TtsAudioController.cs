using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TtsAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    public void StartAudio()
    {
        if (audioSource == null)
        {
            return;
        }

        if (audioClip != null)
        {
            audioSource.clip = audioClip;
        }

        audioSource.Play();
    }

    public void StopAudio()
    {
        if (audioSource == null)
        {
            return;
        }

        audioSource.Stop();
    }
}
