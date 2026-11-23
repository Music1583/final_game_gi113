using UnityEngine;
using TMPro;
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
    public GameObject finish;
    public GameObject menus;
    void Start()
    {
        Time.timeScale = 1f;
        finish.SetActive(false);
        menus.SetActive(false);
    }
    void Update()
    {
        if (isGameOver) return;
        time -= Time.deltaTime;
        if (myItem >= needItem)
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
        }
        timerText.text = time.ToString("F2");

        itemText.text = "have " + myItem + " item";
    }
    public void interact(InputAction.CallbackContext context)
    {
        if (context.performed && !isGameOver)
        {
            Debug.Log("กดปุ่ม E สำเร็จ!");
            myItem++;
            Debug.Log("หยิบของแล้ว! มีของ: " + myItem + " ชิ้น");
        }
        
    }
    public void menu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 0f;
            isGameOver = true;
            menus.SetActive(true);
            Debug.Log("กดปุ่ม esc สำเร็จ!");
        }
        

    }

}