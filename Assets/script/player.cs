using UnityEngine;
using UnityEngine.InputSystem;
public class player : MonoBehaviour
{
    [SerializeField] string name = "Q";
    [SerializeField] float moveSpeed = 5;
    [SerializeField] int health = 10;
    SpriteRenderer sprite;
    Vector2 move;
    float speedX, speedY;
    Rigidbody2D rb;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
        move = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();

        if (move.x > 0.1f)
        {
            sprite.flipX = false;
        }
        else if (move.x < -0.1f)
        {
            sprite.flipX = true;
        }
    }
    void FixedUpdate()
    {
        rb.linearVelocity = move * moveSpeed; // ตั้งค่าความเร็วการเคลื่อนที่ของ player โดยใช้ค่าของ move และ moveSpeed

    }

    void Animation()
    {
        // x > 0 ขวา x < 0 ซ็าย
        // y > 0 บน y < 0 ด้านล่าง
        Debug.Log($"{move.x} ,{move.y}");
        if (move.x > 0 )
        {
            Debug.Log("Moveright");
            animator.SetBool("isWalking", true);
            animator.SetFloat("inputx", move.x);
            animator.SetFloat("inputy", move.y);
        }
        else 
        {
            Debug.Log("stay");
            animator.SetBool("isWalking", false);
            animator.SetFloat("lastInputX", move.x);
            animator.SetFloat("lastInputY", move.y);
        }
        
    }

}
