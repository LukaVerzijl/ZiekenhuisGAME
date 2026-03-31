using TMPro;
using UnityEngine;

namespace Code.Ui
{
    public class LoginModal : MonoBehaviour
    {
        [SerializeField] private TMP_InputField emailInput;
        [SerializeField] private TMP_InputField passwordInput;


        public async void Login()
        {
            ApiManager.Instance.user.Email = emailInput.text;
            ApiManager.Instance.user.Password = passwordInput.text;
            await ApiManager.Instance.Login();
        }

        public async void Register()
        {
            ApiManager.Instance.user.Email = emailInput.text;
            ApiManager.Instance.user.Password = passwordInput.text;
            await ApiManager.Instance.Register();
        }

        
    }
}