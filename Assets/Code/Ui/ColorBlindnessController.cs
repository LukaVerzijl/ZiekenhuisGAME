using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorBlindnessController : MonoBehaviour
{
    public Volume globalVolume;
    private ChannelMixer channelMixer;

    void Start()
    {
        // Zoek de Channel Mixer override in het profiel
        if (globalVolume.profile.TryGet(out channelMixer))
        {
            Debug.Log("Channel Mixer gevonden!");
        }
    }

    // Methode voor Protanopie
    public void SetProtanopia()
    {
        channelMixer.redOutRedIn.value = 15f;
        channelMixer.redOutGreenIn.value = 85f;
        channelMixer.redOutBlueIn.value = 0f;

        channelMixer.greenOutRedIn.value = 15f;
        channelMixer.greenOutGreenIn.value = 85f;
        channelMixer.greenOutBlueIn.value = 0f;

        channelMixer.blueOutRedIn.value = 0f;
        channelMixer.blueOutGreenIn.value = 0f;
        channelMixer.blueOutBlueIn.value = 100f;
    }
    
    // Methode voor Deuteranopie
    public void SetDeuteranopie()
    {
        channelMixer.redOutRedIn.value = 62.5f;
        channelMixer.redOutGreenIn.value = 37.5f;
        channelMixer.redOutBlueIn.value = 0f;

        channelMixer.greenOutRedIn.value = 70f;
        channelMixer.greenOutGreenIn.value = 30f;
        channelMixer.greenOutBlueIn.value = 0f;

        channelMixer.blueOutRedIn.value = 0f;
        channelMixer.blueOutGreenIn.value = 30f;
        channelMixer.blueOutBlueIn.value = 70f;
    }
    
    //Methode voor Tritanopie
    public void SetTritanopie()
    {
        channelMixer.redOutRedIn.value = 95f;
        channelMixer.redOutGreenIn.value = 5f;
        channelMixer.redOutBlueIn.value = 0f;

        channelMixer.greenOutRedIn.value = 0f;
        channelMixer.greenOutGreenIn.value = 43f;
        channelMixer.greenOutBlueIn.value = 57f;

        channelMixer.blueOutRedIn.value = 0f;
        channelMixer.blueOutGreenIn.value = 47f;
        channelMixer.blueOutBlueIn.value = 53f;
    }

    // Methode om alles terug naar normaal te zetten
    public void ResetToNormal()
    {
        channelMixer.redOutRedIn.value = 100f;
        channelMixer.redOutGreenIn.value = 0f;
        channelMixer.redOutBlueIn.value = 0f;

        channelMixer.greenOutRedIn.value = 0f;
        channelMixer.greenOutGreenIn.value = 100f;
        channelMixer.greenOutBlueIn.value = 0f;

        channelMixer.blueOutRedIn.value = 0f;
        channelMixer.blueOutGreenIn.value = 0f;
        channelMixer.blueOutBlueIn.value = 100f;
    }
}
