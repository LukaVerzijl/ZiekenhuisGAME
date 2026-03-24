using System;
using Code.Ui;
using Code.Utils;
using UnityEngine;

namespace Code.Managers
{
    public class UiManager :Singleton<UiManager>
    {
        #region Modal

        public GameObject LoginModal;
        public GameObject ChooseModal;
        public GameObject ChooseLevelChildModal;
        public GameObject RegisterModal;
        
        #endregion

        private void Start()
        {
            HideAllUI();
            ShowLoginModal();
        }

        public void ShowLoginModal()
        {
            LoginModal.SetActive(true);
        }

        public void ShowChooseModal()
        {
            ChooseModal.SetActive(true);
        }

        public void ShowChooseLevelModal()
        {
            ChooseLevelChildModal.SetActive(true);
        }

        public void ShowRegisterModal()
        {
            RegisterModal.SetActive(true);
        }


        public void HideAllUI()
        {
            LoginModal.SetActive(false);
            ChooseModal.SetActive(false);
            ChooseLevelChildModal.SetActive(false);
            RegisterModal.SetActive(false);
        }

    }
}