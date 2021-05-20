using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject UDoorOpen;
    public GameObject DDoorOpen;
    public GameObject LDoorOpen;
    public GameObject RDoorOpen;
    public GameObject UDoorClosed;
    public GameObject DDoorClosed;
    public GameObject LDoorClosed;
    public GameObject RDoorClosed;

    public int posX, posY;

    private void Start()
    {
        GameManager.instance.room = this;
        posX = 0;
        posY = 0;
    }
    public void RebuildRoom(RoomBlueprints roomBlueprints)
    {
        UDoorClosed.SetActive(!roomBlueprints.U);
        DDoorClosed.SetActive(!roomBlueprints.D);
        LDoorClosed.SetActive(!roomBlueprints.L);
        RDoorClosed.SetActive(!roomBlueprints.R);
    }
}