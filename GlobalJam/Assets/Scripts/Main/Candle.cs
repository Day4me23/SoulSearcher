using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour
{
    int lifespanMax = 30;
    [Range(0,100)] public float lifespan = 30f;
    float depreciation = 1f;
    public List<float> bonus;

    void Update()
    {
        float temp = 0;
        for (int i = 0; i < bonus.Count; i++)
            temp += bonus[i];

        lifespan -= Time.deltaTime * (depreciation + temp);

        if (lifespan <= 0)
            GameManager.instance.Die();

        GameObject.FindGameObjectWithTag("Healthbar").GetComponent<LifeBar>().healthbar.fillAmount =  lifespan / lifespanMax;
    }
    public void Depreciate(float amount)
    {
        lifespan -= amount;
    }
    public void Gain(float amount)
    {
        lifespan += amount;

        if (lifespan > lifespanMax)
            lifespan = lifespanMax;
    }
}