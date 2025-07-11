using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3 (moveX, 0f, moveY);

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        if (moveX != 0)
        {
            transform.Rotate(0f, moveX * Time.deltaTime, 0f);
        }
    }

    public void Die()
    {
        
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager != null)
        {
            manager.EndGame();
        }
        else
        {
            Debug.LogError("GameManager not found");
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            Die();
        }
    }
}
