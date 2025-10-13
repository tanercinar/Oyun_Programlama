using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed= 10f;
    //private float speed2=10f;
    void Start()
    {
        transform.position= new Vector3(0f, 5f, 0f);
    }
    void Update()
    {
        float verticalInput= Input.GetAxis("Vertical");
        float horizontalInput= Input.GetAxis("Horizontal");
        Vector3 direction= new Vector3(horizontalInput, 0, verticalInput);
        transform.position+= direction * speed * Time.deltaTime;
    }
}
