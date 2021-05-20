using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject shotProjectile;
    public GameObject waveProjectile;
    public Vector2 knockback;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FireShot();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            FireWave();
        }
    }

    void FireShot()
    {
        GameObject shot = Instantiate(shotProjectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void FireWave()
    {
        GameObject wave = Instantiate(waveProjectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = wave.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
    }
}
