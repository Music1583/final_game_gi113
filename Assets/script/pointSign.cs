using UnityEngine;

public class pointSign : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject quest;
    public int showQuest = 0;
    public logic show;

    public bool everShow = false;
    void Start()
    {
        quest.SetActive(false);

    }
    void Update()
    {
        if (showQuest == 1 && !everShow)
        {
            if (show.show == 1 && !everShow)
            {
                
                quest.SetActive(false);
                Time.timeScale = 1f;
                showQuest = 0;
                Debug.Log("ปิด");
                everShow = true;
            }
            else
            {
                Time.timeScale = 0f;
            } 
        } 
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("sign") && !everShow)
        {
            quest.SetActive(true);
            showQuest = 1;
        }

    }
}
