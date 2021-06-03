using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CoroutineTest : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer m_sprRenderer;
    float m_time;
    int m_count;
    Coroutine m_counterCoroutine;
    Texture2D m_texture;

    private void OnGUI()
    {
        if (m_texture != null)
        {
            Rect rt = new Rect((Screen.width - m_texture.width) / 2, (Screen.height - m_texture.height) / 2, m_texture.width, m_texture.height);
            GUI.DrawTexture(rt, m_texture);
        }
    }

    IEnumerator LoadTexture(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if(request.isDone)
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
        else if(string.IsNullOrEmpty(request.error))
        {
            Debug.LogError(request.error);
        }
    }
    
    

    IEnumerator OverayScreen()
    {
        while (true)
        {
            if (m_sprRenderer.color.a > 0f)
                m_sprRenderer.color = new Color(m_sprRenderer.color.r, m_sprRenderer.color.g, m_sprRenderer.color.b, m_sprRenderer.color.a - 0.0005f);
            else
                yield break;
            yield return null; // 한프레임 뒤에 재진입
            //yield return new WaitForEndOfFrame();
            //yield return new WWW("naver.com");
        }
    }

    IEnumerator Counter()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(++m_count);

        }
    }

    //IEnumerator DrawMessage()
    //{
    //    yield return new WaitForSeconds(1f); // yield 대기
    //    Debug.Log(1);
    //    yield return new WaitForSeconds(2f); 
    //    Debug.Log(2);
    //    yield return new WaitForSeconds(3f); 
    //    Debug.Log(3);
    //}

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadTexture("https://i.pinimg.com/236x/72/d1/e1/72d1e1447007df5930c350da813840fb.jpg"));

        StartCoroutine("Counter");
        //Debug.Log("Start");
        //StartCoroutine("DrawMessage");
        //Debug.Log("End");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StopCoroutine("Counter");
        }
        //m_time += Time.deltaTime;
        //if (m_time >= 1f)
        //{
        //    Debug.Log(++m_count);
        //    m_time = 0f;
        //}


        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine("OverayScreen");
        //}
        
    }
}
