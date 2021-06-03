using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    int m_hp = 10;
    Animator m_animator;
    public void SetDamage()
    {
        m_hp--;
        m_animator.Play("Hit", 0, 0f);
        if (m_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
