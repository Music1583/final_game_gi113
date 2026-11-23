using UnityEngine;
using UnityEngine.InputSystem;

public class GhostShop : MonoBehaviour
{
    public float time = 10f;   // เวลา 10 วินาที
    public int needItem = 3;   // ผีสั่งของ 3 ชิ้น
    public int myItem = 0;     // ของที่เราหยิบได้ตอนนี้
    Vector2 hh;
    void Update()
    {
        // 1. เวลาลดลงเรื่อยๆ
        time -= Time.deltaTime;

        // 2. กดปุ่ม Spacebar เพื่อหยิบของ 1 ชิ้น
        myItem++;
        Debug.Log("หยิบของแล้ว! มีของ: " + myItem + " ชิ้น");


        // 3. เช็กผลแพ้-ชนะ
        if (myItem >= needItem)
        {
            Debug.Log("เย้! ของครบแล้ว รอดตาย!");
            enabled = false; // จบเกม (หยุดสคริปต์)
        }
        else if (time <= 0)
        {
            Debug.Log("งั่ม! เวลาหมด โดนผีกิน!");
            enabled = false; // จบเกม (หยุดสคริปต์)
        }
    }
}