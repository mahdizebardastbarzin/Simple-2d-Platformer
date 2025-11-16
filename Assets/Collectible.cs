using UnityEngine;

// Collectible: Handles collectible item behavior
// آیتم جمع کردنی: مدیریت رفتار آیتم‌های قابل جمع‌آوری
public class Collectible : MonoBehaviour
{
    // Visual effects settings
    // تنظیمات جلوه‌های بصری
    [SerializeField] private int scoreValue = 10;  // Points awarded when collected / امتیاز اعطایی هنگام جمع‌آوری
    [SerializeField] private float rotationSpeed = 100f;  // Rotation speed in degrees per second / سرعت چرخش بر حسب درجه بر ثانیه
    [SerializeField] private float floatAmplitude = 0.5f;  // How high the collectible floats / میزان شناور شدن آیتم
    [SerializeField] private float floatFrequency = 1f;  // How fast the collectible bobs up and down / سرعت حرکت بالا و پایین آیتم

    private Vector3 startPos;  // Initial position for floating effect / موقعیت اولیه برای اثر شناوری

    private void Start()
    {
        // Store the initial position for floating effect
        // ذخیره موقعیت اولیه برای اثر شناوری
        startPos = transform.position;
    }

    private void Update()
    {
        // Rotate the collectible around its Y-axis
        // چرخاندن آیتم به دور محور Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
        // Create a floating up and down motion using sine wave
        // ایجاد حرکت شناور بالا و پایین با استفاده از موج سینوسی
        float newY = startPos.y + (Mathf.Sin(Time.time * floatFrequency) * floatAmplitude);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Called when another collider enters the trigger zone
    // زمانی فراخوانی می‌شود که یک کالایدر دیگر وارد ناحیه تریگر شود
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is the player
        // بررسی می‌کند که آیا کالایدر متعلق به بازیکن است
        if (other.CompareTag("Player"))
        {
            // Add score and destroy the collectible
            // اضافه کردن امتیاز و نابود کردن آیتم
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
