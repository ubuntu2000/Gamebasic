using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBasic
{


    public static class Pref 
    {
       public static int bestScore
        {
            set
            {
                int oldBestScore = PlayerPrefs.GetInt(Const.BEST_SCORE_PREF,0);
                if (oldBestScore <= value)
                    PlayerPrefs.SetInt(Const.BEST_SCORE_PREF, value);
            }
            get => PlayerPrefs.GetInt(Const.BEST_SCORE_PREF, 0);

        }
        public static int curPlayerID
        {
            set => PlayerPrefs.SetInt(Const.CUR_PLAYER_ID_PREF, value);
            get => PlayerPrefs.GetInt(Const.CUR_PLAYER_ID_PREF, 0);
        }
        public static int Coins
        {
            set => PlayerPrefs.SetInt(Const.COINS_PREF, value);
            get => PlayerPrefs.GetInt(Const.COINS_PREF, 0);
        }
        public static float musVol
        {
            set => PlayerPrefs.SetFloat(Const.MUSIC_VOL_PREF, value);
            get => PlayerPrefs.GetFloat(Const.MUSIC_VOL_PREF, 0.3f);
        }
        public static float sfxVol
        {
            set => PlayerPrefs.SetFloat(Const.SFX_VOL_PREF, value);
            get => PlayerPrefs.GetFloat(Const.SFX_VOL_PREF, 1f);
        }
        public static void SetBool(string key, bool value)
        {
            if (value)
            {
                PlayerPrefs.SetInt(key, 1);

            }
            else
                PlayerPrefs.SetInt(key, 0);
        }
        public static bool GetBool(string key)
        {
            return PlayerPrefs.GetInt(key) == 1 ? true : false; 
        }
    }
}