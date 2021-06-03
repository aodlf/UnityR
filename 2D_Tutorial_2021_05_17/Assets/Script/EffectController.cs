using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    Animator m_animator;
    public void SetEffect(Vector3 pos)
    {
        transform.position = pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
} 
