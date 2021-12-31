using UnityEngine;
using UnityEngine.SceneManagement;

public class Congrats : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
