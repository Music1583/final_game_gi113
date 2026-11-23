using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class logic : MonoBehaviour
{

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
    public int takeItem = 0;

    public Animator anim; // ลากคอมโพเนนต์ Animator มาใส่ในหน้า Inspector
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
        /*if (myItem >= needItem)
        {
            Debug.Log("เย้! ของครบแล้ว รอดตาย!");
            finish.SetActive(true);
            statusText.text = "complete";
            isGameOver = true;
            Time.timeScale = 0f;
        }
        else if (time <= 0 && myItem < needItem)
        {
            finish.SetActive(true);
            statusText.text = "Die";
            Debug.Log("งั่ม! เวลาหมด โดนผีกิน!");
            isGameOver = true;
            Time.timeScale = 0f;
        }*/
        timerText.text = time.ToString("F2");

        itemText.text = "have " + myItem + " item";

    }
    public void interact(InputAction.CallbackContext context)
    {
        if (context.performed && !isGameOver)
        {
            Debug.Log("กดปุ่ม E สำเร็จ!");
            myItem++;
            takeItem++;
            Debug.Log("หยิบของแล้ว! มีของ: " + myItem + " ชิ้น");
        }
        
    }
    public void menu(InputAction.CallbackContext context)
    {
        if(isGameOver) return;

        if (context.performed)
        {
            isPaused = !isPaused; // สลับค่า true <-> false ทุกครั้งที่กด

            if (isPaused) // กดครั้งแรก: หยุดเกม (Freeze)
            {
                Time.timeScale = 0f;
                menus.SetActive(true);
                Debug.Log("กดปุ่ม esc: หยุดเกม!");
            }
            else // กดครั้งที่สอง: กลับเป็นปกติ
            {
                Time.timeScale = 1f;
                menus.SetActive(false);
                Debug.Log("กดปุ่ม esc: เล่นต่อ!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("water"))
        {
            if (takeItem > 1)
            {
                Destroy(other.gameObject);
                
            }
            
        }
           
    }

    

}