using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // ลาก SpriteRenderer ของวัตถุมาใส่
    public Sprite[] spriteList;           // ช่องเก็บรายการรูปภาพทั้งหมดที่จะสุ่ม

    void Start()
    {
        ChangeRandomSprite(); // สุ่มเปลี่ยนรูปทันทีตอนเริ่มเกม
    }

    // ฟังก์ชันสำหรับสั่งสุ่มรูป (เรียกใช้ตอนกดปุ่ม หรือตอนเกิดเหตุการณ์ได้)
    public void ChangeRandomSprite()
    {
        // เช็กป้องกัน Error กรณีลืมใส่รูปในช่อง Sprite List
        if (spriteList.Length > 0)
        {
            int randomIndex = Random.Range(0, spriteList.Length);
            spriteRenderer.sprite = spriteList[randomIndex];
        }
    }
}