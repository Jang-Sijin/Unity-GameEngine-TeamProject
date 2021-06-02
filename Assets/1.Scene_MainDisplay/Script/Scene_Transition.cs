using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Scene_Transition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1.0f;
    public void transitionScene()
    {
        StartCoroutine(transitionNextScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator transitionNextScene(int levelIndex)
    {
        transition.SetTrigger("New Trigger");
        
        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelIndex);
    }
}
