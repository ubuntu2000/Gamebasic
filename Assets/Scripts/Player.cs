using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBasic
{


    public class Player : MonoBehaviour, IComponentCheck 
    {

        Animator m_anim;

        public float Time_RateAttack;
        float m_CurTime_RateAttack;
        bool m_IsAttack;
        bool m_IsDead;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_CurTime_RateAttack = Time_RateAttack;
        }
        // Start is called before the first frame update
        void Start()
        {


        }

        public bool  IsComponentsNull()
        {
            return m_anim == null;
        }



        // Update is called once per frame
        void Update()
        {

            if (IsComponentsNull()) return;
            if (Input.GetMouseButtonDown(0) && !m_IsAttack)
            {
         
                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_IsAttack = true;

            }
            if (m_IsAttack)
            {
                m_CurTime_RateAttack -= Time.deltaTime;
                if (m_CurTime_RateAttack <= 0)
                {
                    m_IsAttack = false;
                    m_CurTime_RateAttack = Time_RateAttack;
                }
            }


        }
        public void ReSetAttackAnim()
        {
            if (IsComponentsNull()) return;
            {
                m_anim.SetBool(Const.ATTACK_ANIM, false);
            }
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsComponentsNull()) return;
            if(col.CompareTag(Const.ENEMY_WEAPON_TAG) && !m_IsDead)
            {
                m_anim.SetTrigger(Const.DEAD_ANIM);
                m_IsDead = true;
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
            }
        }
    }

}