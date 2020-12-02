using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] bool instantiateHome = true; // Insitinaite a home room for testing
    [SerializeField] private GameObject boss = null; // Boss prefab
    [SerializeField] private GameObject home = null; // The home room prefab
    [SerializeField] private GameObject center = null; // A center spwan point

    public GameObject[] topDoorRooms;
    public GameObject[] bottomDoorRooms;
    public GameObject[] leftDoorRooms;
    public GameObject[] rightDoorRooms;

    public int maxRooms; // The maximum number of rooms
    public GameObject closedRoomPrefab; // The closed room prefab

    public List<GameObject> rooms; // List of all rooms that have been spawned

    [SerializeField] float waitTime;
    bool bossSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        // Generate a random home
        if(instantiateHome)
            RandomHomeRoom();
        // Spawns a random home room
        Instantiate(home, transform.position, Quaternion.identity);

        // Spawning a center spawn point so that a room cannot be spawned on the home room
        Instantiate(center, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        // spawn a boss in the last generated room after certain time and adjust the time
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

    /// <summary>
    /// Selects a random room from the all the room prefabs
    /// </summary>
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
