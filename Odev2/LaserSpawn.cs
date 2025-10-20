using UnityEngine;

public class LaserSpawn: MonoBehaviour
{
    //Laser prefabini tutacak değişken
    public GameObject laserPrefab;
    //Lazerin oluşacağı nokta değişlekein
    public Transform spawnPoint;
    //Ateş sıklığı ve sonraki ateş etme zamanını tutan değişken
    public float fireRate = 0.5f; 
    private float nextFireTime = 0f;

    void Update()
    {
        //Space tuşuna basılma durumu ve sonraki eteş zamanını kontrol edip Fire fonksiyonunu çağıran if bloğu
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
        }
    }
    //Ateş etme fonksiyonu
    void Fire()
    {
        nextFireTime = Time.time + fireRate;
        Instantiate(laserPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
