using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator m_anim;

    public float Time_RateAttack;
    float m_CurTime_RateAttack;
    bool m_IsAttack;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_CurTime_RateAttack = Time_RateAttack;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !m_IsAttack)
        {
            if (m_anim)
            
               m_anim.SetBool(Const.ATTACK_ANIM, true);
               m_IsAttack = true;
            
        }
        if(m_IsAttack)
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
        if(m_anim)
        {
            m_anim.SetBool(Const.ATTACK_ANIM, false);
        }
    }
}
