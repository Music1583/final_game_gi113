using UnityEngine;
using UnityEngine.InputSystem;
public class player : MonoBehaviour
{
    [SerializeField] string Pname = "Q";
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
        
        move = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        //Animation();
        /*if (move.x > 0.1f)
        {
            sprite.flipX = false;
        }
        else if (move.x < -0.1f)
        {
            sprite.flipX = true;
        }*/
    }
    void FixedUpdate()
    {
        rb.linearVelocity = move * moveSpeed; // ตั้งค่าความเร็วการเคลื่อนที่ของ player โดยใช้ค่าของ move และ moveSpeed
    }
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("lastInputX", move.x);
            animator.SetFloat("lastInputY", move.y);
        }
        move = context.ReadValue<Vector2>();
        animator.SetFloat("inputx", move.x);
        animator.SetFloat("inputy", move.y);  
    }

}
