using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //karakter components
    private KarakterScript KarakterScript; /*Het karakter script moet ingeladen worden aan de hand van de opgeslagen karakter van de gebruiker,
    je krijgt nu een null refrence!*/
    public Transform TransKarakter;
    public Transform StandingPos;

    //bed components
    public RectTransform transBed;
    public Transform LyingPos;
    
    //buttons
    public GameObject StartMRiButton;
    public GameObject StopMRiButton;
    
    //timer variablen
    public TextMeshProUGUI CoutndownText;
    [HideInInspector] public float CountdownTime = 10f;

    public void StartMRI()
    {
        if (KarakterScript.canBeDragged == false)
        {
            transBed.anchoredPosition = new Vector2(-280, -230);
            TransKarakter.position = LyingPos.position;
            StartMRiButton.SetActive(false);
            StartCoroutine(StartCountDown());
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
        }
    }

    IEnumerator StartCountDown()
    {
        while (CountdownTime > 0)
        {
            CoutndownText.text = CountdownTime.ToString("0");
            
            yield return new WaitForSeconds(1f);
            
            Debug.Log(CountdownTime);

            CountdownTime--;
        }
        
        CoutndownText.text = "0";
        StopMRiButton.SetActive(true);
    }
}
