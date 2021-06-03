using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // mono로 동작, 유니티 기본 동작, 자동상속
{
    [SerializeField]
    float m_speed = 3f;
    [SerializeField]
    Vector3 m_dir;
    [SerializeField]
    Animator m_animator;
    [SerializeField]
    SpriteRenderer m_sprRenderer;
    [SerializeField]
    GameObject m_bulletPrefab;
    [SerializeField]
    GameObject m_explosionPrefab;
    [SerializeField]
    Transform m_firePos;
    bool m_isFall;
    bool m_isGrounded;

    Rigidbody2D m_rigidBody;

    #region Animation Event Methods
    void AnimEvent_CreateBullet()
    {
        var obj = Instantiate(m_bulletPrefab);
        //obj.transform.position = m_firePos.position;
        var bullet = obj.GetComponent<BulletController>();
        bullet.SetBullet(m_firePos.position, transform.eulerAngles.y != 0 ? Vector3.right : Vector3.left, m_explosionPrefab);
    }
    #endregion

    void KeyControll()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_dir = Vector3.zero;
            m_animator.SetBool("IsMove", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_dir = Vector3.zero;
            m_animator.SetBool("IsMove", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_dir = Vector3.left;
            m_animator.SetBool("IsMove", true);
            //m_sprRenderer.flipX = false;
            transform.eulerAngles = new Vector3(0f, 0f, 0f); // 각도 
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_dir = Vector3.right;
            m_animator.SetBool("IsMove", true);
            //m_sprRenderer.flipX = true;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);           
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {          
            m_animator.SetInteger("JumpState", 1);
            m_rigidBody.AddForce(Vector3.up * 8f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_animator.SetBool("IsShoot", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_animator.SetBool("IsShoot", false);
        }
        Debug.Log(m_rigidBody.velocity.y);
        if (!m_isGrounded)
        {
            if (m_rigidBody.velocity.y < 0f)
            {
                if (!m_isFall)
                {
                    m_animator.SetInteger("JumpState", 2);
                    m_isFall = true;
                }
            }
        }
        var stateInfo = m_animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsName("Shoot"))



            gameObject.transform.position += m_dir * m_speed * Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        m_animator = gameObject.GetComponent<Animator>();
        m_sprRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            m_isGrounded = true;
            m_animator.SetInteger("JumpState", 0);
            m_isFall = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            m_isGrounded = false;
    }

    //void FixedUpdate()
    //{
    //    m_rigidBody.AddForce(m_dir * m_speed, ForceMode2D.Force);
    //}

    // Update is called once per frame // 반복
    void Update()
    {
        KeyControll();
    }
        
}
