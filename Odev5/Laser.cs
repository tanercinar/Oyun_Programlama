using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 20f;
    public float destroyYPosition = 7.0f;
    private Rigidbody2D rb;

    void Start()
    {

    }

    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y > destroyYPosition)
        {
            Destroy(gameObject);
            if (transform.parent.gameObject != null)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}