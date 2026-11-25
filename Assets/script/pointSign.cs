using UnityEngine;

public class pointSign : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject quest;
    void Start()
    {
        quest.SetActive(false);
        Debug.Log("ปิด");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("sign"))
        {
            Debug.Log("มอบเควส");
            quest.SetActive(true);
        }

    }
}
