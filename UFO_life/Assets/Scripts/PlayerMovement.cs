using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed;

    private int pickups;
    private const int ALL_PICKUPS = 9;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        pickups = 0;
    }

    void FixedUpdate()
    {
        var horizontalMov = Input.GetAxis("Horizontal");
        var verticalMov = Input.GetAxis("Vertical");

        rb2d.AddForce(new Vector2(horizontalMov, verticalMov) * speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Destroy(collision.gameObject);
            pickups++;

            CheckGameComplete();
        }
    }

    private void CheckGameComplete()
    {
        if (pickups == ALL_PICKUPS)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
