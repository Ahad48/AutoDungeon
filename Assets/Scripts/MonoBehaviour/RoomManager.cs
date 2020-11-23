using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] GameObject player;
    [SerializeField] GameObject center;

    public GameObject[] topDoorRooms;
    public GameObject[] bottomDoorRooms;
    public GameObject[] leftDoorRooms;
    public GameObject[] rightDoorRooms;

    public int maxRooms;
    public GameObject closedRoomPrefab;

    public List<GameObject> rooms;

    [SerializeField] float waitTime;
    bool bossSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        RandomHomeRoom();
        Instantiate(player, transform.position, Quaternion.identity);
        Instantiate(center, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if(waitTime <= float.Epsilon && !bossSpawned)
        {
            //print(rooms[rooms.Count - 1].transform.position);
            Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            bossSpawned = true;
        }
        else if(waitTime >= float.Epsilon)
        {
            waitTime -= Time.deltaTime;
        }
    }

    void RandomHomeRoom()
    {
        int randRoomType = Random.Range(0, 4);
        int randRoom;
        switch (randRoomType)
        {
            case 0:
                randRoom = Random.Range(0, topDoorRooms.Length);
                Instantiate(topDoorRooms[randRoom], transform.position, Quaternion.identity);
                break;

            case 1:
                randRoom = Random.Range(0, bottomDoorRooms.Length);
                Instantiate(bottomDoorRooms[randRoom], transform.position, Quaternion.identity);
                break;

            case 2:
                randRoom = Random.Range(0, leftDoorRooms.Length);
                Instantiate(leftDoorRooms[randRoom], transform.position, Quaternion.identity);
                break;

            case 3:
                randRoom = Random.Range(0, rightDoorRooms.Length);
                Instantiate(rightDoorRooms[randRoom], transform.position, Quaternion.identity);
                break;
            
        }
    }
}
