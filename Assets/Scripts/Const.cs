using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBasic
{


    public class Const
    {
        // Dat tag cho cac doi tuong trong game
        public const string PLAYER_TAG = "Player";
        public const string ENEMY_TAG = "Enemy";
        public const string ENEMY_WEAPON_TAG = "EnemyWeapon";
        // Dat hang so chi bien tham chieu trang thai cho animator 
        public const string ATTACK_ANIM = "Attacking";
        public const string DEAD_ANIM = "Death";
        // Dat hang so cho layer
        public const string DEAD_LAYER = "Death";
        public const string ENEMY_LAYER = "Enemy";

        // Dat hang so cho cac doi tuong UI va (SAVE and Load)

        public const string BEST_SCORE_PREF = "BestScore";
        public const string PLAYER_PREFIX_PREF = "Player_";
        public const string CUR_PLAYER_ID_PREF = "CurPlayerID";
        public const string COIN_PREF = "Coins";
        public const string MUSIC_VOL_PREF = "MusicVol";
        public const string SFX_VOL_PREF = "SFXVol";

    }
}
