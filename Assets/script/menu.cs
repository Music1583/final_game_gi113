using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject menus;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void back()
    {
        menus.SetActive(false);
    }
    public void BackMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
