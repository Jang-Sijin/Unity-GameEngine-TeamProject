using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopMenuController : MonoBehaviour
{
    private FpsController fps;
    public void StartGame()
    {
        fps = GameObject.Find("Player").GetComponent<FpsController>();
        fps.UiCheck = false;
        Cursor.lockState = CursorLockMode.Locked; // 마우스 포인터가 가운데로 갱신하도록 한다.
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
