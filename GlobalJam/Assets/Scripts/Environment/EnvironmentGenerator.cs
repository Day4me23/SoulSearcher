using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    private void Awake()
    {
        occupiedPositions.Add(Vector2Int.zero);
        roomList.Add(new RoomBlueprints()
        {
            roomNumber = 0,
            pos = Vector2Int.zero,
            roomType = RoomType.spawn
        });
        for (int i = 1; i < numberOfRooms; i++)
        {
            roomList.Add(DesignRoom(i));
        }
        SetCorridors();
        AssignRoomType();
    }

    public int numberOfRooms;
    public List<RoomBlueprints> roomList = new List<RoomBlueprints>();
    private HashSet<Vector2Int> occupiedPositions = new HashSet<Vector2Int>();
    private Vector2Int[] directions = new Vector2Int[] { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

    

    RoomBlueprints DesignRoom(int roomNumber)
    {
        RoomBlueprints room = new RoomBlueprints() { roomNumber = roomNumber };

        int roomAttempt;
        int randomDirection;
        Vector2Int nextLocation;
        do
        {
            roomAttempt = Random.Range(0, roomList.Count);
            randomDirection = Random.Range(0, directions.Length);
            nextLocation = roomList[roomAttempt].pos + directions[randomDirection];
        } while (occupiedPositions.Contains(nextLocation));

        occupiedPositions.Add(nextLocation);
        room.pos = nextLocation;
        room.parent = roomList[roomAttempt];
        Debug.Log("Building room " + roomNumber + " off of room " + roomList[roomAttempt].roomNumber);
        return room;
    }
    void SetCorridors()
    {
        // build core path of doors
        for (int i = 1; i < roomList.Count; i++) // i starts at 1 because 0 does not have a parent
        {
            if (roomList[i].pos == roomList[i].parent.pos + Vector2.up)
            {
                // Debug.Log("[Room " + roomList[i].roomNumber + " door D is true]" + "[Room " + roomList[i].parent.roomNumber + " door U is true]");
                roomList[i].D = true;
                roomList[i].parent.U = true;
            }
            else if (roomList[i].pos == roomList[i].parent.pos + Vector2.down)
            {
                // Debug.Log("[Room " + roomList[i].roomNumber + " door U is true]" + "[Room " + roomList[i].parent.roomNumber + " door D is true]");
                roomList[i].U = true;
                roomList[i].parent.D = true;
            }
            else if (roomList[i].pos == roomList[i].parent.pos + Vector2.right)
            {
                // Debug.Log("[Room " + roomList[i].roomNumber + " door L is true]" + "[Room " + roomList[i].parent.roomNumber + " door R is true]");
                roomList[i].L = true;
                roomList[i].parent.R = true;
            }
            else if (roomList[i].pos == roomList[i].parent.pos + Vector2.left)
            {
                // Debug.Log("[Room " + roomList[i].roomNumber + " door R is true]" + "[Room " + roomList[i].parent.roomNumber + " door L is true]");
                roomList[i].R = true;
                roomList[i].parent.L = true;
            }
        }
    }
    void AssignRoomType()
    {
        int randomRoom;

        // look for room with one door and make it end room
        randomRoom = Random.Range(1, roomList.Count); 
        roomList[randomRoom].roomType = RoomType.coffin;


        // looks for room that is not coffin
        
        do {randomRoom = Random.Range(1, roomList.Count);}
        while (roomList[randomRoom].roomType == RoomType.coffin);
        roomList[randomRoom].roomType = RoomType.key;

        for (int i = 1; i < roomList.Count; i++)
        {
            if (roomList[i].roomType == RoomType.coffin || roomList[i].roomType == RoomType.key)
                continue;

            int weight = Random.Range(0, 100);

            if (weight < 10) // empty
                roomList[i].roomType = RoomType.empty;
            else if (weight < 55) // zombie
                roomList[i].roomType = RoomType.zombie;
            else if (weight < 90) // skeleton
                roomList[i].roomType = RoomType.skeleton;
            else if (weight < 100) // Mixed
                roomList[i].roomType = RoomType.mixedEnemy;
        }
    }
}

public enum RoomType { spawn, empty, zombie, skeleton, mixedEnemy, key, coffin }
[System.Serializable]
public class RoomBlueprints
{
    public bool roomCleared;
    public bool candleConsumed;

    public Vector2Int pos;
    public int roomNumber;
    public RoomType roomType;

    public RoomBlueprints parent;
    public bool L, R, U, D;
}