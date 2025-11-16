using UnityEngine;

// Hazard: Handles behavior of dangerous objects that can harm the player
// خطر: مدیریت رفتار اشیای خطرناکی که می‌توانند به بازیکن آسیب بزنند
public class Hazard : MonoBehaviour
{
    // Hazard properties
    // ویژگی‌های خطر
    [SerializeField] private float damage = 1f;  // Amount of damage dealt / مقدار آسیب وارد شده
    [SerializeField] private float knockbackForce = 5f;  // Force applied to player on collision / نیروی اعمال شده به بازیکن در هنگام برخورد

    // Called when a collision occurs with another collider
    // زمانی فراخوانی می‌شود که برخورد با یک کالایدر دیگر رخ دهد
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        // بررسی می‌کند که آیا برخورد با بازیکن است
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate knockback direction (away from the hazard)
            // محاسبه جهت پرت شدن (دور از خطر)
            Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
            
            // Apply knockback force to the player
            // اعمال نیروی پرت شدن به بازیکن
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            
            // End the game when player hits a hazard
            // پایان بازی زمانی که بازیکن با خطر برخورد می‌کند
            GameManager.Instance.GameOver();
        }
    }
}
