using UnityEngine;

public class PlayerHealth2D : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // ฟังก์ชันรับดาเมจจากศัตรู
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player Health Left: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // ตรงนี้สามารถใส่โค้ดรีเซ็ตเกมหรือ Game Over ได้ในอนาคต
    }
}