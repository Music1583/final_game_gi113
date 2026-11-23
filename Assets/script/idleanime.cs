using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // เอาไว้รีสตาร์ทเกม

public class GhostSystem : MonoBehaviour
{
    public bool isGameEnd = false;      // สถานะว่าเกมจบหรือยัง
    public GameObject ghostJumpscare;   // ช่องใส่ตัวผี (Ghostjump)
    public Text resultText;             // ช่องใส่ข้อความบอกผลแพ้-ชนะ

    // 1. คำสั่งตอนผู้เล่นเติมของครบ (รอดตาย)
    public void PlayerWin()
    {
        isGameEnd = true;
        resultText.text = "รอดแล้ว! ผีพอใจมาก (กด R เพื่อเล่นใหม่)";
        resultText.color = Color.green;
    }

    // 2. คำสั่งตอนเวลาหมด (ผีโผล่มากิน!)
    public void EatPlayer()
    {
        isGameEnd = true;
        ghostJumpscare.SetActive(true); // สั่งเปิดรูปผีโผล่ขึ้นมา!
        resultText.text = "งั่ม! โดนผีกินแล้ว (กด R เพื่อเล่นใหม่)";
        resultText.color = Color.red;
    }

    // 3. กดปุ่ม R บนคีย์บอร์ดเพื่อเริ่มเล่นใหม่
    void Update()
    {
        if (isGameEnd && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
