using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBasic
{


    public class ShopManager : MonoBehaviour
    {
        public ShopItem[] items;

        private void Start()
        {
            Init();
        }
        // Khoi tao cac du lieu ban dau dc luu xuong may nguoi dung trong shop
        private void Init()
        {
            if (items == null || items.Length <= 0) return;
                for(int i =0; i< items.Length; i++ )
                {
                var item = items[i];
                string datakey = Const.PLAYER_PREFIX_PREF + i; // Player_0, Player_1, Player_2
                    if(item != null)
                    {
                        if(i==0)
                        Pref.SetBool(datakey, true);
                    else
                    {
                        if (!PlayerPrefs.HasKey(datakey))
                            Pref.SetBool(datakey, false);
                    }
                    }
                }

            
        }
    }
}
