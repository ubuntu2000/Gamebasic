using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameBasic
{


    public class ShopItemUI : MonoBehaviour
    {
        public Text priceTxt;
        public Image hub;
        public Button btn;
        public void UpdateUI(ShopItem item, int itemIdx)
        {
            if (item == null) return;

            if (hub)
                // du lieu o  class data struct 
                hub.sprite = item.previewImg;
            // Ktra da mo khoa nhan vat o class shopManager hay chua
            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);
            // Ktra nhan vat da mo khoa hay chua
            if(isUnlocked)
            {
                // KTra truong hop nhan vat choi hien tai dang dc su dung
                if (Pref.curPlayerID == itemIdx)
                {
                    if (priceTxt)
                        priceTxt.text = "Active";
                } else if (priceTxt)
                {
                    //  da so huu nhung khong dc su dung hien tai
                    priceTxt.text = "Owned";
                }
                
            } else
            { if (priceTxt)
                    priceTxt.text = item.price.ToString();

            }


        }
    }
}