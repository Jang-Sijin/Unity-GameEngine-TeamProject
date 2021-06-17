using System.Collections;
using System.Collections.Generic;
using MiscUtil.Compression.Vcdiff;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator SceneTransition;

    public Button start_button;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            start_button.GetComponent<Button>();
            start_button.onClick.AddListener(fClick);
        }
    }

    void fClick()
    {
            StartCoroutine(transitionNextScene(SceneManager.GetActiveScene().buildIndex));
    }
    
    IEnumerator transitionNextScene(int levelIndex)
    {
        SceneTransition.SetTrigger("Start");
        
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
