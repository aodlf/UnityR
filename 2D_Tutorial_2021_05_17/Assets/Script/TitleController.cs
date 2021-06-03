using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleController : MonoBehaviour
{
    bool m_isToggleOn;
    bool m_isSelectWeapon;
    string m_id = "아이디를 입력하세요";
    string m_pass = "1234";
    int m_select;
    string[] m_weaponList = new string[] { "단검", "장검", "양손검", "바스타드", "할버드", "로켓런쳐"  };
    
    public void GoNextScene()
    {
        SceneManager.LoadScene("Game");
    }
    void OnGUI()
    {
        //if(GUI.Button(new Rect((Screen.width - 150)/2, (Screen.height - 50)/2, 150, 50), "START"))
        //{
        //    SceneManager.LoadScene("Game");
        //    Debug.Log("Start game");
       // }
        //GUILayout.BeginArea(new Rect(10, Screen.height - 400, 200, 400), GUI.skin.box);
        //GUILayout.Space(20);
        //GUILayout.Button("START", GUILayout.Width(100), GUILayout.Height(60));
        //m_isToggleOn = GUILayout.Toggle(m_isToggleOn, "무적모드");
        //if(m_isToggleOn)
        //{
        //    GUILayout.Label("무적모드 활성화");
        //}
        //m_id = GUILayout.TextField(m_id);
        //m_pass = GUILayout.PasswordField(m_pass, '*');
        //GUILayout.EndArea();

        //GUILayout.BeginArea(new Rect(Screen.width - 200 - 10, Screen.height - 400, 200, 400), GUI.skin.box);
        //m_isSelectWeapon = GUILayout.Toggle(m_isSelectWeapon, "무기선택", GUI.skin.button);
        //if (m_isSelectWeapon)
        //{
        //    m_select = GUILayout.SelectionGrid(m_select, m_weaponList, 1);
        //}
        //GUILayout.EndArea();
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
