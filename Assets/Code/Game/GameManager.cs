using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //karakter components
    [HideInInspector]public KarakterScript KarakterScript; /*VOOR LUKA: het probleem met de null refrence is gefixed*/
    public Transform TransKarakter;
    public Transform StandingPos;

    //bed components
    public RectTransform transBed;
    public Transform LyingPos;
    
    //mri component
    public AudioSource MRIAudio;
    
    //buttons
    public GameObject StartMRiButton;
    public GameObject StopMRiButton;
    
    //timer variablen
    public TextMeshProUGUI GameFeedBackText;
    [HideInInspector] public float CountdownTime = 10f;

    public void StartMRI()
    {
        if (KarakterScript.canBeDragged == false)
        {
            StartCoroutine(StartMRICoroutine());
            CountdownTime = 10f;
        }
    }

    public void StopMRI()
    {
        if (KarakterScript.canBeDragged == false)
        {
            transBed.anchoredPosition = new Vector2(-20, -230);
            TransKarakter.position = StandingPos.position;
            KarakterScript.ChangeToNormal();
            KarakterScript.canBeDragged = true;
            StopMRiButton.SetActive(false);
            StartMRiButton.SetActive(true);
            GameFeedBackText.color = Color.green;
            GameFeedBackText.text = "De MRI is klaar, goed gedaan!";
        }
    }

    IEnumerator StartMRICoroutine()
    {
        //verplaatsen van dier en bed
        transBed.anchoredPosition = new Vector2(-280, -230);
        TransKarakter.position = LyingPos.position;
        MRIAudio.Play();
        
        StartMRiButton.SetActive(false);// verdwijnen MRI start knop
        
        GameFeedBackText.color = Color.white;
        GameFeedBackText.text = "De MRI is begonnen! blijf voor 10 seconden wachten";
        
        //coutndown loop
        while (CountdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(CountdownTime);
            CountdownTime--;
        }
        
        CountdownTime = 0;
        StopMRiButton.SetActive(true);
        
        GameFeedBackText.text = "De MRI is klaar, druk op de stop knop!";
        MRIAudio.Stop();
    }
}
