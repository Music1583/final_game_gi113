using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject bg;
    public GameObject story;
    public GameObject ui;

    public void Start()
    {
        bg.SetActive(true);
        story.SetActive(false);
    }
    public void Story()
    {
        bg.SetActive(false);
        story.SetActive(true);
        ui.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
