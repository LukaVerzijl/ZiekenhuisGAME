using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //karakter components
    public BearScript KarakterScript;
    public Transform TransKarakter;

    //bed components
    public RectTransform transBed;
    public Transform BearLyingBed;
    
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
            TransKarakter.position = BearLyingBed.position;
            StartMRiButton.SetActive(false);
            StartCoroutine(StartCountDown());
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
