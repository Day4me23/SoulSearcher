using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject winScreeen;
    float playerHealth = 30;

    [HideInInspector] public GameObject playerCurrent;
    public GameObject playerPrefab;
    public bool hasKey;

    public Spawner centerSpawner;

    public EnvironmentGenerator envGen;
    public Room room;
    public int roomListNumber;

    private void Start()
    {
        RoomChange(0, true);
    }
        

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GoToMenu();
    }
    void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    

    public void RoomChange(int dir, bool firstSpawn)
    {
        
        if (!firstSpawn)
            centerSpawner.DespawnRoom();

        bool U = false, D = false, L = false, R = false;

        DeSpawn();
        if (dir == 0)
        {
            SpawnPlayer(0, 0);
            room.posX = 0;
            room.posY = 0;
        }
        if (dir == 1) // U
        {
            SpawnPlayer(0, -4);
            room.posY += 1;

            U = false;
            D = true;
            L = false;
            R = false;
        }
        if (dir == 2) // D
        {
            SpawnPlayer(0, 4);
            room.posY -= 1;

            U = false;
            D = true;
            L = false;
            R = false;
        }
        if (dir == 3) // L
        {
            SpawnPlayer(4, 0);
            room.posX -= 1;

            U = false;
            D = true;
            L = false;
            R = false;
        }
        if (dir == 4) // R 
        {
            SpawnPlayer(-4, 0);
            room.posX += 1;

            U = false;
            D = true;
            L = false;
            R = false;
        }

        // room change transition starts!!!
        envGen = GameObject.Find("EnvGen").GetComponent<EnvironmentGenerator>();
        int roomNumber = 0;
        for (int i = 0; i < envGen.numberOfRooms; i++)
        {
            if (envGen.roomList[i].pos.x == room.posX && envGen.roomList[i].pos.y == room.posY)
            {
                roomNumber = i;
                roomListNumber = i;
                room.RebuildRoom(envGen.roomList[i]);
                break;
            }
        }

        #region Room spawning
        // enemies
        if (!envGen.roomList[roomNumber].roomCleared)
        {
            if (envGen.roomList[roomNumber].roomType == RoomType.spawn)
                return;


            if (envGen.roomList[roomNumber].roomType == RoomType.zombie)
            {
                int temp = Random.Range(1, 5);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(true, false);
                
            }
            if (envGen.roomList[roomNumber].roomType == RoomType.skeleton)
            {
                int temp = Random.Range(1, 5);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(false, true);
            }
            if (envGen.roomList[roomNumber].roomType == RoomType.key)
            {
                int temp = Random.Range(1, 3);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(false, true);
                temp = Random.Range(1, 3);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(true, false);
            }
            if (envGen.roomList[roomNumber].roomType == RoomType.coffin)
            {
                int temp = Random.Range(1, 3);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(false, true);
                temp = Random.Range(1, 3);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(true, false);
            }
            if (envGen.roomList[roomNumber].roomType == RoomType.mixedEnemy)
            {
                int temp = Random.Range(1, 3);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(false, true);
                temp = Random.Range(1, 3);
                for (int i = 0; i < temp; i++)
                    centerSpawner.SpawnEnemy(true, false);
            }


        }
        // center item
        {
            if (envGen.roomList[roomNumber].roomType == RoomType.spawn)
                return;

            if (envGen.roomList[roomNumber].roomType == RoomType.coffin)
            {
                centerSpawner.SpawnCenter(false, true, true);
            }
            else if (envGen.roomList[roomNumber].roomType == RoomType.key)
            {
                if (!GameManager.instance.hasKey)
                {
                    Debug.Log("No Key");
                    centerSpawner.SpawnCenter(true, true, false);
                }
                    
            }
            else
            {
                if (envGen.roomList[roomNumber].candleConsumed == false)
                    centerSpawner.SpawnCenter(false, false, false);
            }
               
        }


        #endregion

        // room change transition ends!!!
    }
    void DeSpawn()
    {
        

        if (playerCurrent != null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Candle>().lifespan;
            Destroy(playerCurrent.gameObject);
        }


           
    }
    void SpawnPlayer(float posX, float posY)
    {
        if (playerCurrent)
            DeSpawn();
        playerCurrent = Instantiate(playerPrefab, new Vector2(posX, posY), Quaternion.identity);
        playerCurrent.GetComponent<Candle>().lifespan = playerHealth;
    }
    public void Die()
    {
        Debug.Log("No more light...");
        DeSpawn();
        GoToMenu();
    }

    public void EndGame()
    {
        winScreeen.SetActive(true); // 
    }
}