using System;
using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float laserSpeed = 15f;
    public GameObject laserPoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    public GameObject laser;
    public GameObject tripleLaser;
    
    [SerializeField]
    public bool isTripleShotActive = false;

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
}