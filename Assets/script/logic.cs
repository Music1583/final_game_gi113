using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class logic : MonoBehaviour
{
    public GameObject[] waters = new GameObject[4];
    public float time = 10f;   // เวลา 10 วินาที
    public int needItem = 3;   // ผีสั่งของ 3 ชิ้น
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

        time -= Time.deltaTime;
        timerText.text = Mathf.Max(0, time).ToString("F2");
        itemText.text = "have " + myItem + " item";
    }

    public void interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // ปริ้นท์ค่าตัวแปรทั้งหมดออกมาดูตอนกดปุ่ม E
            Debug.Log($"กด E -> GameOver:{isGameOver} | Paused:{isPaused} | ชนอยู่:{inCollision} | ของ:{currentItem}");

            if (!isGameOver && !isPaused && inCollision && currentItem != null)
            {
                Debug.Log("หยิบของสำเร็จ!");
                myItem++;
                Destroy(currentItem);
                inCollision = false;
                currentItem = null;
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