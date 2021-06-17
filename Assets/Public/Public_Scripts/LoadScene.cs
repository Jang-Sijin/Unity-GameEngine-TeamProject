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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(transitionNextScene(SceneManager.GetActiveScene().buildIndex,1));
        }
    }
    
    void fClick()
    {
            StartCoroutine(transitionNextScene(SceneManager.GetActiveScene().buildIndex,0));
    }
    
    // value 버튼 클릭인가 아님 충돌처리인가로 씬 이동 결정
    // 0 : 메인씬 1~: 다른 씬이동
    public IEnumerator transitionNextScene(int levelIndex,int value)
    {
        SceneTransition.SetTrigger("Start");
        
        yield return new WaitForSeconds(3.0f);
        if (levelIndex == 0)
        {
            SceneManager.LoadScene(levelIndex+1);
        }
        else
        {
            if (value == 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    
}
