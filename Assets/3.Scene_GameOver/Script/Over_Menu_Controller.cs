
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over_Menu_Controller : MonoBehaviour
{
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
