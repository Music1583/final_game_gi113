using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class logic : MonoBehaviour
{
    public GameObject[] waters = new GameObject[4];
    public float time = 15f;   // เวลา 10 วินาที
    public int needItem = 4;   // ผีสั่งของ 3 ชิ้น
    public int myItem = 0;     // ของที่เราหยิบได้ตอนนี้

    public TMP_Text timerText;
    public TMP_Text itemText;
    public TMP_Text statusText;

    bool isGameOver = false;
    bool isPaused = false;
    public GameObject finish;
    public GameObject menus;

    bool inCollision = false;
    GameObject currentItem; // เก็บวัตถุไอเทมที่กำลังชนอยู่
    public Animator anim;

    public pointSign quest;
    public int show;

    void Start()
    {
        Time.timeScale = 1f;
        finish.SetActive(false);
        menus.SetActive(false);
        anim.Play("walk");
    }

    void Update()
    {
        if (isGameOver) return;
        if (quest.showQuest == 1)
        {
            Time.timeScale = 0f;
        }
        if (show  == 1)
        {
            time -= Time.deltaTime;
        } 
        timerText.text = time.ToString("F0");
        itemText.text = myItem + " item";
        if (myItem >= needItem)
        {
            Time.timeScale = 0f;
            finish.SetActive(true);
            statusText.text = "Quest Complete";
        }
        else if (time < 0)
        {
            Time.timeScale = 0f;
            finish.SetActive(true);
            statusText.text = "Quest Fail";
        } 
    }

    public void interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!isGameOver && !isPaused && inCollision && currentItem != null)
            {
                Debug.Log("หยิบของสำเร็จ!");
                myItem++;
                Destroy(currentItem);
                inCollision = false;
                currentItem = null;
            }
            if (quest.showQuest == 1)
            {
                show = 1;
            }
        }
    }

    public void menu(InputAction.CallbackContext context)
    {
        if (isGameOver) return;

        if (context.performed)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f;
                menus.SetActive(true);
                Debug.Log("กดปุ่ม esc: หยุดเกม!");
            }
            else
            {
                Time.timeScale = 1f;
                menus.SetActive(false);
                Debug.Log("กดปุ่ม esc: เล่นต่อ!");
            }
        }
    }

    // ทำงานตลอดเวลาตราบใดที่ตัวละครยังยืนชิด/ทับไอเทมอยู่
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else if (other.CompareTag("water1"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else if(other.CompareTag("water2"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else if (other.CompareTag("water3"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else if (other.CompareTag("snack"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else if (other.CompareTag("snack1"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else if (other.CompareTag("snack2"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else if (other.CompareTag("snack3"))
        {
            inCollision = true;
            currentItem = other.gameObject;
            Debug.Log("เข้ามายืน");
        }
        else
        {
            Debug.Log("ไม่รู้ชื่อ");
        }
        
    }

    // ทำงานตอนเดินถอยห่างออกจากไอเทม
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("water") && other.gameObject == currentItem)
        {
            inCollision = false;
            currentItem = null; // ล้างค่าเมื่อเดินออกห่างแล้ว
            Debug.Log("เดินออกจากระยะไอเทม");
        }
    }
}