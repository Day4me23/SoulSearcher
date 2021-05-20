using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public float health = 5f;
    public float damagePerHit = 5f;
    public string whatAmI = "Text";
    public Candle candle;
    public float invincibilityTimer;
    public float timeInvincible = 5f;
    public float shaderTick = 1f;
    float shaderMultiplier = 1f;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_RedFactor", shaderTick);
        if (shaderTick > 1f)
        {
            shaderTick -= Time.deltaTime * shaderMultiplier;
        }
        else
        {
            shaderTick = 1f;
        }

        if(invincibilityTimer>0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (invincibilityTimer<=0)
        {
            invincibilityTimer = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player_projectile" && whatAmI == "Enemy")
        {
            shaderTick = 10f;
            health--;
            if (health <= 0)
            {
               
                Destroy(gameObject);
            }
        }

        if(collision.tag == "Enemy_attack" && whatAmI == "Player")
        {
            GameManager.instance.playerCurrent.GetComponent<Candle>().lifespan -= damagePerHit;
            invincibilityTimer = timeInvincible;
        }
    }
}
