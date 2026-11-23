using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class GhostShop : MonoBehaviour
{

    public float time = 10f;   // เวลา 10 วินาที
    public int needItem = 3;   // ผีสั่งของ 3 ชิ้น
    public int myItem = 0;     // ของที่เราหยิบได้ตอนนี้

    public TMP_Text timerText;
    public TMP_Text itemText;
    public TMP_Text statusText;
    void Update()
    {
        time -= Time.deltaTime;
        
        if (myItem >= needItem && time >= 0)
        {
            statusText.text = "complete";
            Debug.Log("เย้! ของครบแล้ว รอดตาย!");
            statusText.gameObject.SetActive(false);
        }
        else if (time <= 0 && myItem < needItem)
        {
            statusText.text = "Die";
            Debug.Log("งั่ม! เวลาหมด โดนผีกิน!");
            statusText.gameObject.SetActive(false);
        }
        timerText.text = time.ToString("F2");
        timerText.gameObject.SetActive(false);
        itemText.text = "have " + myItem + " item";
    }
    public void interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("กดปุ่ม E สำเร็จ!");
            myItem++;
            Debug.Log("หยิบของแล้ว! มีของ: " + myItem + " ชิ้น");

        }
        
    }

}