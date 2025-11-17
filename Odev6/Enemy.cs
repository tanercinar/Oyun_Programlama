using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    void Start()
    {
        
    }
    void Update()
    {
        this.transform.Translate(Vector3.down * speed*Time.deltaTime);
        if(transform.position.y<-5.5)
        {
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       Movement mov= other.GetComponent<Movement>();
        if (mov.isShielded == true)
        {
            mov.disableShield();
        }
        else
        {   
            mov.takeDamage();
        }
    }

    

}
