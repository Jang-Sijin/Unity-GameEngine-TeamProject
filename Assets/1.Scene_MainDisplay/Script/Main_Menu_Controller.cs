
using UnityEngine;

public class Main_Menu_Controller : MonoBehaviour
{
    public GameObject Start_Button_animation;
    private GameObject animations;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; // 마우스 포인터가 움직이도록 한다.
        Cursor.visible = true;// 마우스 포인터가 보이도록 설정한다.
    }
    public void PlayGame()
    {
    }
    
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
