using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// GameSetup: Automatically sets up the game scene with all necessary objects
// تنظیم‌کننده بازی: به صورت خودکار صحنه بازی را با تمام اشیاء لازم راه‌اندازی می‌کند
[ExecuteInEditMode]
public class GameSetup : MonoBehaviour
{
    [Header("References")]
    public Camera mainCamera;
    public GameObject playerPrefab;
    public GameObject groundPrefab;
    public GameObject collectiblePrefab;
    public GameObject hazardPrefab;
    public Canvas uiCanvas;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public Button restartButton;

    [Header("Level Settings")]
    public int numberOfCollectibles = 5;
    public int numberOfHazards = 3;
    public Vector2 levelSize = new Vector2(10f, 5f);

    private void Start()
    {
        // Only run in play mode
        if (!Application.isPlaying) return;
        
        SetupGame();
    }

    [ContextMenu("Setup Game")]
    public void SetupGame()
    {
        // Clear existing objects
        ClearScene();

        // Setup camera
        SetupCamera();

        // Setup UI
        SetupUI();

        // Create player
        GameObject player = CreatePlayer();

        // Create ground
        CreateGround();

        // Create collectibles
        CreateCollectibles();

        // Create hazards
        CreateHazards();
    }

    private void ClearScene()
    {
        // Destroy all game objects except the ones we want to keep
        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj != gameObject && obj.transform.parent == null && 
                obj.GetComponent<Camera>() == null && 
                obj.GetComponent<Canvas>() == null)
            {
                if (Application.isPlaying)
                    Destroy(obj);
                else
                    DestroyImmediate(obj);
            }
        }
    }

    private void SetupCamera()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
            {
                GameObject cameraObj = new GameObject("Main Camera");
                mainCamera = cameraObj.AddComponent<Camera>();
                cameraObj.AddComponent<AudioListener>();
                mainCamera.orthographic = true;
                mainCamera.orthographicSize = 5f;
                mainCamera.transform.position = new Vector3(0, 0, -10);
            }
        }
    }

    private void SetupUI()
    {
        // Create Canvas if it doesn't exist
        if (uiCanvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas");
            uiCanvas = canvasObj.AddComponent<Canvas>();
            uiCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();

            // Add EventSystem if it doesn't exist
            if (FindObjectOfType<UnityEngine.EventSystems.EventSystem>() == null)
            {
                GameObject eventSystem = new GameObject("EventSystem");
                eventSystem.AddComponent<UnityEngine.EventSystems.EventSystem>();
                eventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
            }
        }

        // Create Score Text
        if (scoreText == null)
        {
            GameObject scoreObj = new GameObject("ScoreText");
            scoreObj.transform.SetParent(uiCanvas.transform);
            scoreText = scoreObj.AddComponent<TextMeshProUGUI>();
            scoreText.text = "Score: 0";
            scoreText.fontSize = 24;
            scoreText.alignment = TextAlignmentOptions.TopLeft;
            
            // Position in top-left corner
            RectTransform rect = scoreText.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 1);
            rect.anchorMax = new Vector2(0, 1);
            rect.pivot = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(20, -20);
        }

        // Create Game Over Panel
        if (gameOverPanel == null)
        {
            gameOverPanel = new GameObject("GameOverPanel");
            gameOverPanel.transform.SetParent(uiCanvas.transform);
            Image panelImage = gameOverPanel.AddComponent<Image>();
            panelImage.color = new Color(0, 0, 0, 0.7f);
            
            // Make panel fill the screen
            RectTransform panelRect = gameOverPanel.GetComponent<RectTransform>();
            panelRect.anchorMin = Vector2.zero;
            panelRect.anchorMax = Vector2.one;
            panelRect.sizeDelta = Vector2.zero;
            
            // Add Game Over Text
            GameObject gameOverTextObj = new GameObject("GameOverText");
            gameOverTextObj.transform.SetParent(gameOverPanel.transform);
            TextMeshProUGUI gameOverText = gameOverTextObj.AddComponent<TextMeshProUGUI>();
            gameOverText.text = "Game Over";
            gameOverText.fontSize = 48;
            gameOverText.alignment = TextAlignmentOptions.Center;
            gameOverText.color = Color.white;
            
            // Position Game Over Text
            RectTransform gameOverRect = gameOverTextObj.GetComponent<RectTransform>();
            gameOverRect.anchorMin = new Vector2(0.5f, 0.6f);
            gameOverRect.anchorMax = new Vector2(0.5f, 0.6f);
            gameOverRect.pivot = new Vector2(0.5f, 0.5f);
            gameOverRect.sizeDelta = new Vector2(400, 100);
            gameOverRect.anchoredPosition = Vector2.zero;
            
            // Add Final Score Text
            GameObject finalScoreObj = new GameObject("FinalScoreText");
            finalScoreObj.transform.SetParent(gameOverPanel.transform);
            finalScoreText = finalScoreObj.AddComponent<TextMeshProUGUI>();
            finalScoreText.text = "Final Score: 0";
            finalScoreText.fontSize = 32;
            finalScoreText.alignment = TextAlignmentOptions.Center;
            finalScoreText.color = Color.white;
            
            // Position Final Score Text
            RectTransform finalScoreRect = finalScoreObj.GetComponent<RectTransform>();
            finalScoreRect.anchorMin = new Vector2(0.5f, 0.5f);
            finalScoreRect.anchorMax = new Vector2(0.5f, 0.5f);
            finalScoreRect.pivot = new Vector2(0.5f, 0.5f);
            finalScoreRect.sizeDelta = new Vector2(400, 50);
            finalScoreRect.anchoredPosition = new Vector2(0, -30);
            
            // Add Restart Button
            GameObject buttonObj = new GameObject("RestartButton");
            buttonObj.transform.SetParent(gameOverPanel.transform);
            
            // Add button component
            Button button = buttonObj.AddComponent<Button>();
            
            // Add button background
            Image buttonImage = buttonObj.AddComponent<Image>();
            buttonImage.color = new Color(0.2f, 0.6f, 1f);
            
            // Add button text
            GameObject buttonTextObj = new GameObject("Text");
            buttonTextObj.transform.SetParent(buttonObj.transform);
            TextMeshProUGUI buttonText = buttonTextObj.AddComponent<TextMeshProUGUI>();
            buttonText.text = "Restart Game";
            buttonText.fontSize = 24;
            buttonText.alignment = TextAlignmentOptions.Center;
            buttonText.color = Color.white;
            
            // Position button text
            RectTransform textRect = buttonTextObj.GetComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.sizeDelta = Vector2.zero;
            
            // Position button
            RectTransform buttonRect = buttonObj.GetComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(0.4f, 0.3f);
            buttonRect.anchorMax = new Vector2(0.6f, 0.4f);
            buttonRect.sizeDelta = Vector2.zero;
            
            // Set up button click
            button.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
            
            // Initially hide the game over panel
            gameOverPanel.SetActive(false);
        }
    }

    private GameObject CreatePlayer()
    {
        if (playerPrefab == null)
        {
            // Create player object
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Cube);
            player.name = "Player";
            player.tag = "Player";
            
            // Set player position
            player.transform.position = new Vector3(0, 1, 0);
            
            // Add and configure Rigidbody2D
            Rigidbody2D rb = player.AddComponent<Rigidbody2D>();
            rb.freezeRotation = true;
            
            // Add and configure BoxCollider2D
            BoxCollider2D collider = player.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(0.9f, 0.9f);
            
            // Add PlayerController
            PlayerController playerController = player.AddComponent<PlayerController>();
            
            // Create ground check object
            GameObject groundCheck = new GameObject("GroundCheck");
            groundCheck.transform.SetParent(player.transform);
            groundCheck.transform.localPosition = new Vector3(0, -0.5f, 0);
            
            // Assign ground check to player controller
            playerController.groundCheck = groundCheck.transform;
            
            // Set ground layer
            playerController.groundLayer = LayerMask.GetMask("Ground");
            
            // Set player color
            Renderer renderer = player.GetComponent<Renderer>();
            renderer.material.color = Color.blue;
            
            return player;
        }
        else
        {
            return Instantiate(playerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    private void CreateGround()
    {
        if (groundPrefab == null)
        {
            // Create ground object
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ground.name = "Ground";
            ground.tag = "Ground";
            
            // Set ground position and scale
            ground.transform.position = new Vector3(0, -2, 0);
            ground.transform.localScale = new Vector3(levelSize.x, 1, 1);
            
            // Add and configure BoxCollider2D
            BoxCollider2D collider = ground.AddComponent<BoxCollider2D>();
            
            // Set ground layer
            ground.layer = LayerMask.NameToLayer("Ground");
            
            // Set ground color
            Renderer renderer = ground.GetComponent<Renderer>();
            renderer.material.color = new Color(0.2f, 0.8f, 0.2f); // Green
        }
        else
        {
            Instantiate(groundPrefab, new Vector3(0, -2, 0), Quaternion.identity);
        }
    }

    private void CreateCollectibles()
    {
        for (int i = 0; i < numberOfCollectibles; i++)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(-levelSize.x / 2 + 1, levelSize.x / 2 - 1),
                Random.Range(0, levelSize.y / 2)
            );
            
            if (collectiblePrefab == null)
            {
                GameObject collectible = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                collectible.name = "Collectible";
                collectible.transform.position = randomPos;
                collectible.transform.localScale = Vector3.one * 0.5f;
                
                // Add and configure CircleCollider2D
                CircleCollider2D collider = collectible.AddComponent<CircleCollider2D>();
                collider.isTrigger = true;
                
                // Add Collectible script
                Collectible collectibleScript = collectible.AddComponent<Collectible>();
                
                // Set collectible color
                Renderer renderer = collectible.GetComponent<Renderer>();
                renderer.material.color = Color.yellow;
            }
            else
            {
                Instantiate(collectiblePrefab, randomPos, Quaternion.identity);
            }
        }
    }

    private void CreateHazards()
    {
        for (int i = 0; i < numberOfHazards; i++)
        {
            Vector2 randomPos = new Vector2(
                Random.Range(-levelSize.x / 2 + 1, levelSize.x / 2 - 1),
                Random.Range(0.5f, levelSize.y / 2)
            );
            
            if (hazardPrefab == null)
            {
                GameObject hazard = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                hazard.name = "Hazard";
                hazard.transform.position = randomPos;
                hazard.transform.localScale = new Vector3(0.8f, 0.1f, 0.8f);
                
                // Add and configure BoxCollider2D
                BoxCollider2D collider = hazard.AddComponent<BoxCollider2D>();
                
                // Add Hazard script
                Hazard hazardScript = hazard.AddComponent<Hazard>();
                
                // Set hazard color
                Renderer renderer = hazard.GetComponent<Renderer>();
                renderer.material.color = Color.red;
            }
            else
            {
                Instantiate(hazardPrefab, randomPos, Quaternion.identity);
            }
        }
    }
}
