using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace GameBasic
{
    public class GameOverDialog : Dialog
    {
        public Text bestScoreTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if (bestScoreTxt)
                bestScoreTxt.text = Pref.bestScore.ToString("00000");
        }
        public void RePlay()
        {
            Close();
            SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}