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
            base.Show(isShow);

            m_shopMng = FindObjectOfType<ShopManager>();
            m_gm = FindObjectOfType<GameManager>();

            UpdayeUI();
        }

        public bool IsComponentsNull()
        {
            return m_shopMng == null || m_gm == null || gridRoot == null ;
        }

        private void UpdayeUI()
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