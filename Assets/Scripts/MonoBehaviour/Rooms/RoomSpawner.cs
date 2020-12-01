using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    Spawn spawn;
    RoomManager roomTemplates;
    bool spawned = false;

    [SerializeField]
    static int numRooms = 0;
    int maxRooms;
    float waitTime = 5f;

    GameObject roomPrefab;

    Vector3 position;

    void Start()
    {
        Destroy(this.gameObject, waitTime);
        spawn = gameObject.GetComponent<SpawnPoint>().spawn;
        roomTemplates = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        maxRooms = roomTemplates.maxRooms;
        //print(spawn.doorDirection);
        position = transform.position;
        Invoke("SpawnRoom", 0.1f);
    }

    void SpawnRoom()
    {
        if (!spawned)
        {
            if(numRooms < maxRooms)
            {
                int rand;
                switch (spawn.doorDirection)
                {
                    case Spawn.neededDoorDirection.top:
                        //need a room with bottom door
                        rand = Random.Range(0, roomTemplates.topDoorRooms.Length);
                        roomPrefab = Instantiate(roomTemplates.topDoorRooms[rand], vector3Round(position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.bottom:
                        //need a room with top door
                        rand = Random.Range(0, roomTemplates.bottomDoorRooms.Length);
                        roomPrefab = Instantiate(roomTemplates.bottomDoorRooms[rand], vector3Round(position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.left:
                        //need a room with right door
                        rand = Random.Range(0, roomTemplates.leftDoorRooms.Length);
                        roomPrefab = Instantiate(roomTemplates.leftDoorRooms[rand], vector3Round(position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.right:
                        //need a room with left door
                        rand = Random.Range(0, roomTemplates.rightDoorRooms.Length);
                        roomPrefab = Instantiate(roomTemplates.rightDoorRooms[rand], vector3Round(position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.center:
                        break;

                    default:
                        break;
                }
            }

            else
            {
                roomPrefab = Instantiate(roomTemplates.closedRoomPrefab, position, Quaternion.identity);
            }

            spawned = true;
            numRooms++;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            //Destroy(gameObject);
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                roomPrefab = Instantiate(roomTemplates.closedRoomPrefab, position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
            spawned = true;
        }
    }

    Vector3 vector3Round(Vector3 vector3)
    {
        vector3.x = Mathf.Round(vector3.x);
        vector3.y = Mathf.Round(vector3.y);
        vector3.z = Mathf.Round(vector3.z);
        return vector3;
    }
}
