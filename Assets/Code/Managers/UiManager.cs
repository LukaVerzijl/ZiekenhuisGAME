using System;
using Code.Ui;
using Code.Utils;
using UnityEngine;

namespace Code.Managers
{
    public class UiManager :Singleton<UiManager>
    {
        #region Modal

        public GameObject[] panels;

        #endregion

        private void Start()
        {
            showPanel("LoginModal");
        }

        public void showPanel(string panelName)
        {
            foreach (GameObject panel in panels)
            {
                if (panel.name == panelName)
                {
                    panel.SetActive(true);
                }
                else
                {
                    panel.SetActive(false);
                }
            }
        }

    }
}