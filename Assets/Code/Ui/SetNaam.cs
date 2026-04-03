using System;
using Code.Managers;
using TMPro;
using UnityEngine;

namespace Code.Ui
{
    public class SetNaam : MonoBehaviour
    {
        [SerializeField] public TMP_InputField naamInput;
        private bool _isProcessing = false;
        public void SetNaamText()
        {
            if (string.IsNullOrWhiteSpace(naamInput.text)) 
            {
                Debug.LogWarning("Name cannot be empty!");
            }
            else
            {
                Debug.Log("Setting name to: " + naamInput.text);
                SaveDataManager.Instance.KindNaam = naamInput.text;
                SaveManager.Instance.persistenceManager.Save();
                UiManager.Instance.HideAllUI();
                UiManager.Instance.ShowKarakterKiezenModal();                
            }
        }

        public void OnEnable()
        {
            if (_isProcessing) return;
            _isProcessing = true;
            
            if (!string.IsNullOrEmpty(SaveDataManager.Instance.KindNaam))
            {
                Debug.Log(SaveDataManager.Instance.KindNaam);
                ReplaceNaamInAllTexts();
            }
            
            _isProcessing = false;
            
        }

        private void ReplaceNaamInAllTexts()
        {
            string kindNaam = SaveDataManager.Instance.KindNaam;
            TMP_Text[] allTexts = FindObjectsByType<TMP_Text>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach (TMP_Text text in allTexts)
            {
                if (text.text.Contains("[naam]"))
                {
                    text.text = text.text.Replace("[naam]", kindNaam);
                }
            }
        }

    }
}