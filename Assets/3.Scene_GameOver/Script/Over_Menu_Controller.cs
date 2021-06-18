using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over_Menu_Controller : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; // 마우스 포인터가 움직이도록 한다.
        Cursor.visible = true;// 마우스 포인터가 보이도록 설정한다.
    }

    public void ReStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}