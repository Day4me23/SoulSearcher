using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float timer = .5f;

    private void Update()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_attack" || collision.tag == "Wall")
        Destroy(gameObject);
    }
}
