
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
