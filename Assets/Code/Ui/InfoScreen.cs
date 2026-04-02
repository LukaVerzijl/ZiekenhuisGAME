using System;
using TMPro;
using UnityEngine;

namespace Code.Ui
{
    public class InfoScreen : MonoBehaviour
    {
        public async void OnEnable()
        {
            if (ApiManager.Instance.isLoggedIn)
            {
                if (await ApiManager.Instance.GetClientData())
                {
                    ReplaceText();
                }
            }
        }
        
        private void ReplaceText()
        {
            string kindNaam = ApiManager.Instance.client.KindNaam;
            string kindLeeftijd = ApiManager.Instance.client.LeeftijdKind.ToString();
            string behandelDatum = ApiManager.Instance.client.BehandelDatum.ToString("dd-MM-yyyy");
            string behandelType = ApiManager.Instance.client.TypeBehandeling;
            string doktorNaam = ApiManager.Instance.client.DokterNaam;
            TMP_Text[] allTexts = FindObjectsByType<TMP_Text>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach (TMP_Text text in allTexts)
            {
                if (text.text.Contains("[kindnaam]"))
                {
                    text.text = text.text.Replace("[kindnaam]", kindNaam);
                }

                if (text.text.Contains("[bdatum]"))
                {
                    text.text = text.text.Replace("[bdatum]", behandelDatum);
                }

                if (text.text.Contains("[bhandeling]"))
                {
                    text.text = text.text.Replace("[bhandeling]", behandelType);
                }

                if (text.text.Contains("[ndoktor]"))
                {
                    text.text = text.text.Replace("[ndoktor]", doktorNaam);
                }

                if (text.text.Contains("[leeftijd]"))
                {
                    text.text = text.text.Replace("[leeftijd]", kindLeeftijd);
                }
            }
        }
    }
}