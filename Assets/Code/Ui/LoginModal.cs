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
            ApiManager.Instance.user.Email = emailInput.text;
            ApiManager.Instance.user.Password = passwordInput.text;
            if (await ApiManager.Instance.Register())
            { 
                isLoggingIn = false;
                UiManager.Instance.ShowParentControlModal();
            }
            else
            {
                isLoggingIn = false;
                validationText.text = "Registration failed! Please check your credentials and try again.";
            }
        }

        
    }
}