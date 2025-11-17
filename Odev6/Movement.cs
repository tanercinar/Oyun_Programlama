using System;
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int health=3;
    public float speed = 10f;
    public float laserSpeed = 15f;
    public GameObject laserPoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public float speedMultiplier = 2;

    public GameObject laser;
    public GameObject tripleLaser;
    
    [SerializeField]
    public bool isTripleShotActive = false;
    public bool isSpeedBonusActive = false;
    public bool isShielded = false;
    public Transform shield;
    void Start()
    {
        shield.gameObject.SetActive(false);
    }

    void Update()
    {
        CalculateMovement();
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Fire();
        }
    }
    
    void CalculateMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(horizontalInput * Time.deltaTime * speed, verticalInput * Time.deltaTime * speed, 0);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -1.5f, 0.5f), -20);
        
        if (transform.position.x >= 6.2)
        {
            transform.position = new Vector3(-6.2f, transform.position.y, -20);
        }
        
        if (transform.position.x <= -6.2)
        {
            transform.position = new Vector3(6.2f, transform.position.y, -20);
        }
    }

    void Fire()
    {
        nextFireTime = Time.time + fireRate;

        if (!isTripleShotActive)
        {
            Instantiate(laser, laserPoint.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(tripleLaser, laserPoint.transform.position, Quaternion.identity);
        }
    }

    public void TripleShotActive()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotCancelRoutine());
    }
    IEnumerator TripleShotCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isTripleShotActive = false;
    }
    public void SpeedBonusActive()
    {
        isTripleShotActive = true;
        speed*= speedMultiplier;
        StartCoroutine(SpeedBonusCancelRoutine());
    }
    IEnumerator SpeedBonusCancelRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        speed/= speedMultiplier;
    }
    public void ShieldBonusActive()
    {
        isShielded=true;
        shield.gameObject.SetActive(true);

    }
    public void disableShield()
    {
        isShielded=false;
        shield.gameObject.SetActive(false);
    }
    public void takeDamage()
    {
        health=-1;
        if (health <= 0)
        {
            Destroy(this);
        }
    }
}