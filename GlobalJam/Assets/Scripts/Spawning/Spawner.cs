using UnityEngine;
using System.Collections.Generic;
public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject skeletonPrefab;
    public GameObject boss;

    public GameObject key;
    public GameObject coffin;
    public GameObject candle;


    List<GameObject> list;
    private void Start()
    {
        list = new List<GameObject>();
        GameManager.instance.centerSpawner = this;
    }
    public void SpawnEnemy(bool Z, bool S)
    {
        Vector3 random = new Vector3();
        random.x = Random.Range(-3, 3);
        random.y = Random.Range(-3, 3);
        random.z = 0;

        if (Z)
            list.Add(Instantiate(skeletonPrefab, random, Quaternion.identity));
        if (S)
            list.Add(Instantiate(zombiePrefab, random, Quaternion.identity));
    }
    public void SpawnCenter(bool isKey, bool candleConsumed, bool coffinRoom)
    {
        if (coffinRoom)
            list.Add(Instantiate(coffin, new Vector3(0, 0, 0), Quaternion.identity));
        else if (isKey)
            list.Add(Instantiate(key, new Vector3(0, 0, 0), Quaternion.identity));
        else if (!candleConsumed)
            list.Add(Instantiate(candle, new Vector3(0,0,0), Quaternion.identity));
    }
    public void DespawnRoom()
    {
        for (int i = 0; i < list.Count; i++)
            Destroy(list[i].gameObject);
    }
}