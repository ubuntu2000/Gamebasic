using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameBasic
{
    public class ShopDialog : Dialog, IComponentCheck
    {
        public Transform gridRoot;
        public ShopItemUI itemUIPrefab;
        private ShopManager m_shopMng;
        private GameManager m_gm;

        public override void Show(bool isShow)
        {
            Pref.Coins = 3000;
            base.Show(isShow);

            m_shopMng = FindObjectOfType<ShopManager>();
            m_gm = FindObjectOfType<GameManager>();

            UpdateUI();
        }

        public bool IsComponentsNull()
        {
            return m_shopMng == null || m_gm == null || gridRoot == null ;
        }

        private void UpdateUI()
        {
            if (IsComponentsNull()) return;

            ClearChilds();

            var items = m_shopMng.items;
            if (items == null || items.Length <= 0) return;
            for(int i = 0; i<items.Length; i++)
            {
                int idx = i;

                var item = items[idx];

                var itemUIClone = Instantiate(itemUIPrefab,Vector3.zero,Quaternion.identity);
               // Gan doi tuong cha cho doi tuong itemUI dc tao ra
                itemUIClone.transform.SetParent(gridRoot);
                // Dat gia tri do lon Scale =1
                itemUIClone.transform.localScale = Vector3.one;

                itemUIClone.transform.localPosition = Vector3.zero;

                itemUIClone.UpdateUI(item, idx);

                if(itemUIClone.btn)
                {
                    itemUIClone.btn.onClick.RemoveAllListeners();
                    itemUIClone.btn.onClick.AddListener(() => ItemEvent( item, idx));
                    Debug.Log("kich chuot");
                }
            }
        }
        private void ItemEvent( ShopItem item, int itemIdx)
        {
            if (item == null) return;
            bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);
            if(isUnlocked)
            {
                if (itemIdx == Pref.curPlayerID) return;

                Pref.curPlayerID = itemIdx;

           

                UpdateUI();  
            }else if(Pref.Coins >= item.price)
            {
                Pref.Coins -= item.price;
                Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemIdx, true);
                Pref.curPlayerID = itemIdx;

               

                UpdateUI();

                if (m_gm.guiMng)
                    m_gm.guiMng.UpdateMainCoin();

            }else
            {
                Debug.Log("Ko du tien");
            }
        }
        public void ClearChilds()
        {
            if (gridRoot == null || gridRoot.childCount <= 0) return;
            for(int i =0; i< gridRoot.childCount; i++)
            {
                var child = gridRoot.GetChild(i);

                if (child)
                    Destroy(child.gameObject);
            }
        }
    }
}