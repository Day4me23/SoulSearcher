using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour
{/*
    if (roomNumber == 0)
        {
            roomList[roomNumber].roomNumber = roomNumber;

            roomList[roomNumber].posX = 0;
            roomList[roomNumber].posY = 0;

            roomList[roomNumber].roomTypes = RoomType.spawn;
        }
        else
{
    RoomBlueprints temp = null;
    while (temp == null)
    {
        int roomAttempt = Random.Range(0, roomList.Count);
        if (roomList[roomAttempt].U == false || roomList[roomAttempt].D == false || roomList[roomAttempt].L == false || roomList[roomAttempt].R == false)
        {
            int randomDirrection = Random.Range(0, 4);

            if (randomDirrection == 0) // U
            {
                if (roomList[roomAttempt].U == false)
                    BuildUp(roomAttempt);
                else if (roomList[roomAttempt].D == false)
                    BuildDown(roomAttempt);
                else if (roomList[roomAttempt].L == false)
                    BuildLeft(roomAttempt);
                else if (roomList[roomAttempt].R == false)
                    BuildRight(roomAttempt);
            }
            else if (randomDirrection == 1) // D
            {
                if (roomList[roomAttempt].D == false)
                    BuildDown(roomAttempt);
                else if (roomList[roomAttempt].L == false)
                    BuildLeft(roomAttempt);
                else if (roomList[roomAttempt].R == false)
                    BuildRight(roomAttempt);
                else if (roomList[roomAttempt].U == false)
                    BuildUp(roomAttempt);
            }
            else if (randomDirrection == 2) // L
            {
                if (roomList[roomAttempt].L == false)
                    BuildLeft(roomAttempt);
                else if (roomList[roomAttempt].R == false)
                    BuildRight(roomAttempt);
                else if (roomList[roomAttempt].U == false)
                    BuildUp(roomAttempt);
                else if (roomList[roomAttempt].D == false)
                    BuildDown(roomAttempt);
            }
            else if (randomDirrection == 3) // R
            {
                if (roomList[roomAttempt].R == false)
                    BuildRight(roomAttempt);
                else if (roomList[roomAttempt].U == false)
                    BuildUp(roomAttempt);
                else if (roomList[roomAttempt].D == false)
                    BuildDown(roomAttempt);
                else if (roomList[roomAttempt].L == false)
                    BuildLeft(roomAttempt);
            }
        }

        if (temp == null)
            continue;

        for (int i = 0; i < roomList.Count; i++)
            if ((temp.posX == roomList[i].posX) && (temp.posY == roomList[i].posY))
            {
                temp = null;
                break;
            }

        if (temp == null)
            continue;

        Debug.Log("Building room " + roomNumber + " off of room " + roomList[roomAttempt].roomNumber);
        temp.parent = roomList[roomAttempt];
    }

    temp.roomNumber = roomNumber;
    roomList[roomNumber] = temp;

    #region build methods
    void BuildUp(int roomAttempt)
    {
        temp = new RoomBlueprints();
        temp.posX = roomList[roomAttempt].posX;
        temp.posY = roomList[roomAttempt].posY + 1;
    }
    void BuildDown(int roomAttempt)
    {
        temp = new RoomBlueprints();
        temp.posX = roomList[roomAttempt].posX;
        temp.posY = roomList[roomAttempt].posY - 1;
    }
    void BuildLeft(int roomAttempt)
    {
        temp = new RoomBlueprints();
        temp.posX = roomList[roomAttempt].posX - 1;
        temp.posY = roomList[roomAttempt].posY;
    }
    void BuildRight(int roomAttempt)
    {
        temp = new RoomBlueprints();
        temp.posX = roomList[roomAttempt].posX + 1;
        temp.posY = roomList[roomAttempt].posY;
    }
    #endregion
}*/
}