using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInAnimation : MonoBehaviour
{
 public Animator SceneTransition;
    // Start is called before the first frame update
    
    IEnumerator transitionNextScene(int levelIndex)
    {
        
        yield return new WaitForSeconds(3.0f);
        if (levelIndex == 0)
        {
            SceneManager.LoadScene(levelIndex+1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
