
using UnityEngine;
using UnityEngine.SceneManagement;

public class Running_Timer : MonoBehaviour
{
    private float timerCount = 5.0f;

    void Update()
    {
        timerCount -= Time.deltaTime;
        if (timerCount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
}
