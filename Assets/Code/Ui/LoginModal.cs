using System;
using Code.Managers;
using TMPro;
using UnityEngine;

namespace Code.Ui
{
    public class LoginModal : MonoBehaviour
    {
        [SerializeField] private TMP_InputField emailInput;
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private TMP_Text validationText;
        [SerializeField] private TMP_InputField naamKind;
        [SerializeField] private TMP_InputField leeftijdKind;
        [SerializeField] private TMP_InputField naamArts;
        [SerializeField] private TMP_InputField behandelDatum;
        [SerializeField] private TMP_InputField TypeBehandeling;
        private bool isLoggingIn = false;


        public async void Login()
        {
            if (isLoggingIn) return;
            isLoggingIn = true;
            ApiManager.Instance.user.Email = emailInput.text;
            ApiManager.Instance.user.Password = passwordInput.text;
            
            
            if (await ApiManager.Instance.Login())
            {
                Debug.Log("Login succes!");
                UiManager.Instance.HideAllUI();
                UiManager.Instance.ShowParentControlModal();
                isLoggingIn = false;
            }
            else
            {
                Debug.Log("Login failed!");
                isLoggingIn = false;
                validationText.text = "Login failed! Please check your credentials and try again.";

            }
        }

        public async void Register()
        {
            if (isLoggingIn) return;
            isLoggingIn = true;
            if (!TryParseDate(behandelDatum.text, out DateTime parsedDate))
            {
                validationText.text = "Behandel datum is invalid!";
                isLoggingIn = false;
                return;
            }
            ApiManager.Instance.user.Email = emailInput.text;
            ApiManager.Instance.user.Password = passwordInput.text;
            ApiManager.Instance.client.KindNaam = naamKind.text;
            ApiManager.Instance.client.LeeftijdKind = int.TryParse(leeftijdKind.text, out int leeftijd) ? leeftijd : 0;
            ApiManager.Instance.client.DokterNaam = naamArts.text;
            ApiManager.Instance.client.BehandelDatum = parsedDate;
            ApiManager.Instance.client.TypeBehandeling = TypeBehandeling.text;
            if (await ApiManager.Instance.Register())
            { 
                isLoggingIn = false;
                if (await ApiManager.Instance.CreateClientData())
                {
                    UiManager.Instance.HideAllUI();
                    UiManager.Instance.ShowParentControlModal();
                }

            }
            else
            {
                isLoggingIn = false;
                validationText.text = "Registration failed! Please check your credentials and try again.";
            }
        }

        private bool TryParseDate(string value, out DateTime result)
        {
            return DateTime.TryParseExact(
                value,
            new [] {"dd/MM/yyyy", "dd-MM-yyyy" },

        System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out result
            );
        }

    }
}