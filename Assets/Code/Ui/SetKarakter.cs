using System;
using Code.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Ui
{
    public class SetKarakter : MonoBehaviour
    {
        public GameObject beerKarakter;
        public GameObject visKarakter;
        public GameObject bijKarakter;
        public void SetKarakterID(int  chosenCharacter)
        {
            SaveDataManager.Instance.chosenCharacter = chosenCharacter;
            SaveManager.Instance.persistenceManager.Save();
        }

        public void OnEnable()
        {
            if(beerKarakter == null || visKarakter == null || bijKarakter == null) return;
            setImage();
        }

        private void setImage()
        {
            int karakter =  SaveDataManager.Instance.chosenCharacter;
            switch (karakter)
            {
                case 0:
                    beerKarakter.SetActive(true);
                    visKarakter.SetActive(false);
                    bijKarakter.SetActive(false);
                    break;
                case 1:
                    beerKarakter.SetActive(false);
                    visKarakter.SetActive(true);
                    bijKarakter.SetActive(false);
                    break;
                case 2:
                    beerKarakter.SetActive(false);
                    visKarakter.SetActive(false);
                    bijKarakter.SetActive(true);
                    break;
                default:
                    beerKarakter.SetActive(true);
                    visKarakter.SetActive(false);
                    bijKarakter.SetActive(false);
                    break;
            }
            
        }
    }
}