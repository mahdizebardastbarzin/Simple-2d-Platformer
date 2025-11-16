using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// GameManager: Controls the game state, score, and UI
// مدیریت بازی: کنترل وضعیت بازی، امتیاز و رابط کاربری
public class GameManager : MonoBehaviour
{
    // Singleton instance for global access
    // نمونه سینگلتون برای دسترسی سراسری
    public static GameManager Instance;
    
    // Game variables
    // متغیرهای بازی
    public int score = 0;  // Player's current score / امتیاز فعلی بازیکن
    public TextMeshProUGUI scoreText;  // UI text to display score / متن رابط کاربری برای نمایش امتیاز
    public GameObject gameOverPanel;  // Game over UI panel / پنل پایان بازی
    public TextMeshProUGUI finalScoreText;  // Text to show final score / متن نمایش دهنده امتیاز نهایی

    private void Awake()
    {
        // Implement singleton pattern
        // پیاده‌سازی الگوی سینگلتون
        if (Instance == null)
        {
            Instance = this;  // Set this as the instance if none exists
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances
            return;
        }

        Time.timeScale = 1f;  // Ensure game is not paused / اطمینان از اینکه بازی متوقف نشده است
    }

    // Add points to the player's score
    // اضافه کردن امتیاز به امتیاز بازیکن
    public void AddScore(int points)
    {
        score += points;  // Increase score / افزایش امتیاز
        scoreText.text = "Score: " + score;  // Update UI / به‌روزرسانی رابط کاربری
    }

    // Handle game over state
    // مدیریت وضعیت پایان بازی
    public void GameOver()
    {
        Time.timeScale = 0f;  // Pause the game / توقف بازی
        gameOverPanel.SetActive(true);  // Show game over panel / نمایش پنل پایان بازی
        finalScoreText.text = "Final Score: " + score;  // Display final score / نمایش امتیاز نهایی
    }

    // Restart the current level
    // راه‌اندازی مجدد سطح فعلی
    public void RestartGame()
    {
        // Reload the current scene / بارگذاری مجدد صحنه فعلی
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
