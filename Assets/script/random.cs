using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // ลาก SpriteRenderer ของวัตถุมาใส่
    public Sprite[] spriteList;           // ช่องเก็บรายการรูปภาพทั้งหมดที่จะสุ่ม

    public GameObject[] water;
    public GameObject[] snack;

    int item;

    void Start()
    {
        item = Random.Range(1, 4);
        ChangeRandomSprite(); // สุ่มเปลี่ยนรูปทันทีตอนเริ่มเกม
        SetPointRandomSprite();
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
    public void SetPointRandomSprite()
    {
        if (item == 1)
        {
            water[0].SetActive(true);
            water[1].SetActive(false);
            water[2].SetActive(false);
            water[3].SetActive(true);
            snack[0].SetActive(false);
            snack[1].SetActive(true);
            snack[2].SetActive(true);
            snack[3].SetActive(false);
        }
        else if (item == 2)
        {
            water[0].SetActive(false);
            water[1].SetActive(true);
            water[2].SetActive(true);
            water[3].SetActive(false);
            snack[0].SetActive(true);
            snack[1].SetActive(false);
            snack[2].SetActive(false);
            snack[3].SetActive(true);
        }
        else if (item == 3)
        {
            water[0].SetActive(true);
            water[1].SetActive(false);
            water[2].SetActive(true);
            water[3].SetActive(false);
            snack[0].SetActive(true);
            snack[1].SetActive(true);
            snack[2].SetActive(false);
            snack[3].SetActive(false);
        }
        else
        {
            return;
        }
    }
}