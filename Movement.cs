using UnityEngine;

public class Movement : MonoBehaviour
{
    [Tooltip("Nesnenin hareket hızı (birim/saniye).")]
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Oyun başladığında nesnenin başlangıç pozisyonunu belirleyebiliriz.
        // Örneğin: transform.position = new Vector3(0, 0.5f, 0);
        Debug.Log("Hareket Kontrolü Başlatıldı!");
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Kullanıcı Girdisini Al
        // Input.GetAxis, klavyedeki yön tuşları (veya WASD) girdilerini -1 ile 1 arasında yumuşak bir değer olarak alır.
        float verticalInput = Input.GetAxis("Vertical");       // W, S, Yukarı/Aşağı Oklar
        float horizontalInput = Input.GetAxis("Horizontal");   // A, D, Sol/Sağ Oklar

        // 2. Hareket Vektörünü Oluştur
        // Girdileri kullanarak hangi yöne hareket edileceğini belirleyen bir vektör oluşturuyoruz.
        // Y eksenini 0 bırakıyoruz çünkü yukarı/aşağı bir hareket istemiyoruz.
        Vector3 hareketYonu = new Vector3(horizontalInput, 0, verticalInput);

        // 3. Hareketi Uygula
        // transform.Translate, nesneyi mevcut konumundan belirtilen yöne doğru hareket ettirir.
        // speed: Hareketi hızlandırmak için çarpan.
        // Time.deltaTime: Hareketi kare hızından bağımsız hale getirerek saniyeye bağlı (akıcı ve tutarlı) yapar.
        transform.Translate(hareketYonu * speed * Time.deltaTime);
    }
}