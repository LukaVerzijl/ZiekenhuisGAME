using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TtsAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;

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
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void StopAudio()
    {
        if (audioSource == null)
        {
            return;
        }

        audioSource.Stop();
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }
}
