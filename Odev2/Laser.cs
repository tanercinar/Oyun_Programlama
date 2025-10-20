using UnityEngine;

public class Laser: MonoBehaviour
{
    public float speed = 15f;

    void Update()
    {
        //Nesneyi yukarı hareklet ettir
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //Ekranın dışına çıkma durumunu kontrol et
        if (transform.position.y > 7f)
        {
            //Nesneyi yok et
            Destroy(this.gameObject);
        }
    }
}