using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
