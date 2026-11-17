using UnityEngine;

public class EnemyAI2D : MonoBehaviour
{
    private Transform playerTransform;

    [Header("Stats")]
    public float moveSpeed = 3f;           // ความเร็วในการเดินตาม
    public float damageToPlayer = 10f;     // ดาเมจที่จะทำต่อครั้ง
    public float attackCooldown = 1.5f;    // เว้นระยะเวลาก่อนจะตีซ้ำ (วินาที)
    private float lastAttackTime = -999f;

    void Start()
    {
        // ค้นหาตำแหน่ง Player จาก Tag "Player" อัตโนมัติ
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("ไม่พบ GameObject ที่มี Tag 'Player' ในฉาก!");
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // 1. ระบบเดินตาม Player (เคลื่อนที่เข้าหาตำแหน่ง Player ใน 2D)
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

        // 2. หันหน้าซ้าย-ขวา ตามตำแหน่ง Player
        if (playerTransform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // เมื่อเริ่มชนกับ Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TryDamagePlayer(collision.gameObject);
        }
    }

    // ถ้ายืนชนค้างไว้ จะเช็คจังหวะโจมตีตาม Cooldown
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TryDamagePlayer(collision.gameObject);
        }
    }

    void TryDamagePlayer(GameObject playerObj)
    {
        // เช็คเวลา Cooldown เพื่อไม่ให้เลือดลดรัวจนหมดหลอดในพริบตา
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            PlayerHealth2D playerHealth = playerObj.GetComponent<PlayerHealth2D>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageToPlayer);
                lastAttackTime = Time.time; // บันทึกเวลาที่โจมตีล่าสุด
            }
        }
    }
}