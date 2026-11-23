using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void BackMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
