using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameBasic
{
    public class GUIManager : MonoBehaviour
    {
        public GameObject homeGUI;
        public GameObject gameGUI;
        public Dialog GameOverDialog;
        public Text mainCoinTxt;
        public Text gameplayCoinTxt;
        // Start is called before the first frame update
        void Start()
        {

        }
        public void ShowGameGUI(bool isShow)
        {
            if (gameGUI)
                gameGUI.SetActive(isShow);
            if (homeGUI)
                homeGUI.SetActive(!isShow);
        }
        public void UpdateMainCoin()
        {
            if (mainCoinTxt)
                mainCoinTxt.text = Pref.Coins.ToString();
        }
        public void UpdateGamePlayCoin()
        {
            if (gameplayCoinTxt)
                gameplayCoinTxt.text = Pref.Coins.ToString();
        }
    }
}