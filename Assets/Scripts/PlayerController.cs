using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    private int score = 0;

    public TMP_Text scoreText;
    public TMP_Text healthText;

    public TMP_Text winLoseText;
    public Image winLoseBG;

    public int health = 5;

    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetScoreText();
        SetHealthText();

        // Hide UI at start
        winLoseText.text = "";
        winLoseText.color = new Color(0, 0, 0, 0);
        winLoseBG.color = new Color(1, 0, 0, 0);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    void FixedUpdate()
    {
        if (isGameOver) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, 0f, moveZ);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (!isGameOver && health <= 0)
        {
            isGameOver = true;

            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;

            Invoke("RestartGame", 2f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }

        if (other.CompareTag("Goal"))
        {
            winLoseText.text = "You Win!";
            winLoseText.color = Color.black;
            winLoseBG.color = Color.green;
        }
    }
}
