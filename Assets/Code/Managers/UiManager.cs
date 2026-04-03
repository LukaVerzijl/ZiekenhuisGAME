using System;
using System.Collections.Generic;
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
        public GameObject KindChooseModal;
        public GameObject RegisterModal;
        public GameObject OuderChoseModal;
        public GameObject ParentControlModal;
        public GameObject KarakterKiezenModal;
        public GameObject VideoKindModal;
        public GameObject AftelModalKind;
        public GameObject NaamVragenKind;
        public GameObject NaamVragenOuder;
        public GameObject GameModalKind;
        public GameObject ReadModalKind;
        public GameObject VoorMRIModalOuder;
        public GameObject TijdensMRIModalOuder;
        public GameObject NaMRIModalOuder;
        
        #endregion

        private void Start()
        {
            HideAllUI();
            ChooseModal.SetActive(true);
        }

        public void ShowLoginModal()
        {
            LoginModal.SetActive(true);
        }

        public void ShowChooseModal()
        {
            ChooseModal.SetActive(true);
        }

        public void ShowKindChooseModal()
        {
            KindChooseModal.SetActive(true);
        }

        public void ShowRegisterModal()
        {
            RegisterModal.SetActive(true);
        }

        public void ShowOuderChoseModal()
        {
            OuderChoseModal.SetActive(true);
        }

        public void ShowParentControlModal()
        {
            ParentControlModal.SetActive(true);
        }

        public void ShowKarakterKiezenModal()
        {
            KarakterKiezenModal.SetActive(true);
        }

        public void ShowVideoKindModal()
        {
            VideoKindModal.SetActive(true);
        }

        public void ShowAftelModalKind()
        {
            AftelModalKind.SetActive(true);
        }

        public void ShowNaamVragenKind()
        {
            NaamVragenKind.SetActive(true);
        }

        public void ShowNaamVragenOuder()
        {
            NaamVragenOuder.SetActive(true);
        }

        public void ShowGameModalKind()
        {
            GameModalKind.SetActive(true);
        }

        public void ShowReadModalKind()
        {
            ReadModalKind.SetActive(true);
        }

        public void ShowVoorMRIModalOuder()
        {
            VoorMRIModalOuder.SetActive(true);
        }

        public void ShowTijdensMRIModalOuder()
        {
            TijdensMRIModalOuder.SetActive(true);
        }

        public void ShowNaMRIModalOuder()
        {
            NaMRIModalOuder.SetActive(true);
        }


        public void HideAllUI()
        {
            LoginModal.SetActive(false);
            ChooseModal.SetActive(false);
            KindChooseModal.SetActive(false);
            RegisterModal.SetActive(false);
            OuderChoseModal.SetActive(false);
            ParentControlModal.SetActive(false);
            KarakterKiezenModal.SetActive(false);
            VideoKindModal.SetActive(false);
            AftelModalKind.SetActive(false);
            NaamVragenKind.SetActive(false);
            NaamVragenOuder.SetActive(false);
            GameModalKind.SetActive(false);
            ReadModalKind.SetActive(false);
            VoorMRIModalOuder.SetActive(false);
            TijdensMRIModalOuder.SetActive(false);
            NaMRIModalOuder.SetActive(false);
        }

    }
}