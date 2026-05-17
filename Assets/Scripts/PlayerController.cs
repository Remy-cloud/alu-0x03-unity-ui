using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private Vector3 movement;

    private int score = 0;
    public int health = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        movement = new Vector3(moveX, 0f, moveZ);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // PICKUP LOGIC
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);

            Destroy(other.gameObject);
        }

        // TRAP LOGIC
        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }

        // GOAL LOGIC
        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}