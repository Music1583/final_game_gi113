using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject menus;
    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void BackMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
