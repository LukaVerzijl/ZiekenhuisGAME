using System;
using Code.Managers;
using TMPro;
using UnityEngine;

namespace Code.Ui
{
    public class SetNaam : MonoBehaviour
    {
        [SerializeField] public TMP_InputField naamInput;
        public void SetNaamText()
        {
            Debug.Log("Setting name to: " + naamInput.text);
            SaveDataManager.Instance.KindNaam = naamInput.text;
            SaveManager.Instance.persistenceManager.Save();
        }

        public void OnEnable()
        {
            if (!string.IsNullOrEmpty(SaveDataManager.Instance.KindNaam))
            {
                Debug.Log(SaveDataManager.Instance.KindNaam);
                ReplaceNaamInAllTexts();
            }
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