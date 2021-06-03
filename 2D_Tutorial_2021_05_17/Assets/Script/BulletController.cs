using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector3 m_dir = Vector3.left;
    [SerializeField]
    float m_speed = 20f;
    [SerializeField]
    SpriteRenderer m_sprRenderer;
    [SerializeField]
    float m_lifetime = 3f;
    [SerializeField]
    Rigidbody2D m_rigidBody;
    GameObject m_explosionPrefab;

    float m_time;

    public void SetBullet(Vector3 pos, Vector3 dir, GameObject prefab)
    {
        transform.position = pos;
        m_dir = dir;
        m_sprRenderer.flipY = dir == Vector3.right ? true : false;
        m_explosionPrefab = prefab;
        //m_rigidBody.AddForce(m_dir * m_speed, ForceMode2D.Impulse);
    }
    void CreateEffect(Vector3 pos)
    {
        var obj = Instantiate(m_explosionPrefab);
        var effect = obj.GetComponent<EffectController>();
        effect.SetEffect(pos);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Background") || collision.CompareTag("Monster"))
        {
            CreateEffect(transform.position);
            Destroy(gameObject);
            if(collision.CompareTag("Monster"))
            {
                var mon = collision.GetComponent<MonsterController>();
                mon.SetDamage();
            }

            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
    }

    //void OnCollisionEnter2D(Collision2D collision) // 충돌 타이밍
    //{
    //    if(collision.gameObject.CompareTag("Background"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
        
    //}

    //void OnCollisionStay2D(Collision2D collision)
    //{
        
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        if(m_time > m_lifetime)
        {
            m_time = 0f;
            Destroy(gameObject);
        }
        gameObject.transform.position += m_dir * m_speed * Time.deltaTime;
    }
}
