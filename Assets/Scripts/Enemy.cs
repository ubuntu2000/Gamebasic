using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameBasic
{
        
    public class Enemy : MonoBehaviour, IComponentCheck
    {
        Animator m_anim;
        Rigidbody2D m_rb;
        Player m_player;
        public float movespeed;
        public float EnemyDistance;
        public int minCoinBonus;
        public int maxCoinBonus;
        private bool m_IsDead;

        private GameManager m_gm;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();
            m_gm = FindObjectOfType<GameManager>();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public bool IsComponentsNull()
        {
            return m_anim == null || m_player == null || m_rb == null || m_gm == null;
        }


        // Update is called once per frame
        void Update()
        {
            if (IsComponentsNull()) return;
            float PlayerDistance = Vector2.Distance(m_player.transform.position, transform.position);
           if ( PlayerDistance <= EnemyDistance)
            {
                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_rb.velocity = Vector2.zero;
            }
            else
            {
                m_rb.velocity = new Vector2(-movespeed, m_rb.velocity.y);
            }
        }
        public void Die()
        {
            if (IsComponentsNull() && m_IsDead) return;

             m_IsDead = true;
             m_anim.SetTrigger(Const.DEAD_ANIM);
             m_rb.velocity = Vector2.zero;
             gameObject.layer = LayerMask.NameToLayer(Const.DEAD_ANIM);
             m_gm.Score++;
            int coinsbonus = Random.Range(minCoinBonus, maxCoinBonus);
            Pref.Coins += coinsbonus;

            if (m_gm.guiMng)
                m_gm.guiMng.UpdateGamePlayCoin();
            if (m_gm.auCtr)
                m_gm.auCtr.PlaySound(m_gm.auCtr.enemyDead);

            Destroy(gameObject, 2f);
        }
    }
}