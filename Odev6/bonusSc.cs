using UnityEngine;

public class bonusSc : MonoBehaviour
{
    [SerializeField]
    float speed = 3;
    [SerializeField]
    int pUpType;
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
            if(pUpType==0)
            {
            movement.TripleShotActive();
                
            }
            if(pUpType==1)
            {
            movement.SpeedBonusActive();

            }
            if (pUpType == 2)
            {
            movement.ShieldBonusActive();
            }

            Destroy(this.gameObject);
        }   
    }
}
