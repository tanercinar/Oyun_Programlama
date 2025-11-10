using UnityEngine;

public class bonusSc : MonoBehaviour
{
    [SerializeField]
    float speed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -5.5)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("aa");
            Movement movement = collision.GetComponent<Movement>();
            movement.TripleShotActive();
            Destroy(this.gameObject);
        }   
    }
}
