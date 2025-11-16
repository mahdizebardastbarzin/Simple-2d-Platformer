using UnityEngine;

// PlayerController: Handles player movement, jumping, and ground detection
// کنترل‌کننده بازیکن: مدیریت حرکت، پرش و تشخیص زمین
public class PlayerController : MonoBehaviour
{
    // Movement settings
    // تنظیمات حرکتی
    [SerializeField] private float moveSpeed = 5f;  // Player movement speed / سرعت حرکت بازیکن
    [SerializeField] private float jumpForce = 10f;  // Force applied when jumping / نیروی اعمال شده هنگام پرش
    [SerializeField] private LayerMask groundLayer;  // Layer mask for ground detection / لایه‌های تشخیص زمین
    [SerializeField] private Transform groundCheck;  // Transform to check if player is grounded / موقعیت بررسی تماس با زمین
    [SerializeField] private float groundCheckRadius = 0.2f;  // Radius for ground check / شعاع بررسی زمین

    // Component references
    // ارجاعات کامپوننت‌ها
    private Rigidbody2D rb;  // Reference to Rigidbody2D component / ارجاع به کامپوننت Rigidbody2D
    
    // State variables
    // متغیرهای وضعیت
    private bool isGrounded;  // Whether player is on the ground / وضعیت تماس با زمین
    private float horizontalInput;  // Stores horizontal input value / مقدار ورودی افقی

    private void Awake()
    {
        // Get reference to Rigidbody2D component
        // دریافت ارجاع به کامپوننت Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input (A/D or Left/Right arrows)
        // دریافت ورودی افقی (کلیدهای A/D یا چپ/راست)
        horizontalInput = Input.GetAxis("Horizontal");

        // Check if player is touching the ground
        // بررسی تماس بازیکن با زمین
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle jump input
        // مدیریت ورودی پرش
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply upward force for jumping
            // اعمال نیروی رو به بالا برای پرش
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Flip character sprite based on movement direction
        // چرخش اسپرایت کاراکتر بر اساس جهت حرکت
        if (horizontalInput > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);  // Face right / رو به راست
        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);  // Face left / رو به چپ
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement in FixedUpdate for physics consistency
        // اعمال حرکت افقی در FixedUpdate برای ثبات فیزیکی
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
}
