
using UnityEngine;

public class Main_Menu_Controller : MonoBehaviour
{
    public GameObject Start_Button_animation;
    private GameObject animations;
    public void PlayGame()
    {
        Start_Button_animation.SetActive(true);
        animations = GameObject.Find("Transitons_Scene");
        animations.GetComponent<Scene_Transition>().transitionScene();
        
    }
    
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
