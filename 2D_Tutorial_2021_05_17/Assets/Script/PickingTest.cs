using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingTest : MonoBehaviour
{
    Ray m_ray;
    RaycastHit m_rayHit;
    GameObject m_selectObj;

    GameObject GetClickObject()
    {
        m_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(m_ray, out m_rayHit, 1000f))
        {
            return m_rayHit.collider.gameObject;
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            m_selectObj = GetClickObject();
            if(m_selectObj != null)
            {
                m_selectObj.transform.position += Vector3.back * 3f;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(m_selectObj != null)
            {
                m_selectObj.transform.position += Vector3.forward * 3f;
            }
            m_selectObj = null;
        }
        Debug.DrawRay(m_ray.origin, m_ray.direction * (m_selectObj == null ? 1000f : m_rayHit.distance), Color.yellow);
    }
}
