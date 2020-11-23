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

    [SerializeField]

    void Start()
    {
        Destroy(this.gameObject, waitTime);
        spawn = gameObject.GetComponent<SpawnPoint>().spawn;
        roomTemplates = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        maxRooms = roomTemplates.maxRooms;
        //print(spawn.doorDirection);
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
                        Instantiate(roomTemplates.topDoorRooms[rand], vector3Round(transform.position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.bottom:
                        //need a room with top door
                        rand = Random.Range(0, roomTemplates.bottomDoorRooms.Length);
                        Instantiate(roomTemplates.bottomDoorRooms[rand], vector3Round(transform.position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.left:
                        //need a room with right door
                        rand = Random.Range(0, roomTemplates.leftDoorRooms.Length);
                        Instantiate(roomTemplates.leftDoorRooms[rand], vector3Round(transform.position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.right:
                        //need a room with left door
                        rand = Random.Range(0, roomTemplates.rightDoorRooms.Length);
                        Instantiate(roomTemplates.rightDoorRooms[rand], vector3Round(transform.position), Quaternion.identity);
                        break;

                    case Spawn.neededDoorDirection.center:
                        break;

                    default:
                        break;
                }
            }

            else
            {
                Instantiate(roomTemplates.closedRoomPrefab, transform.position, Quaternion.identity);
            }

            spawned = true;
            numRooms++;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))// && collision.GetComponent<RoomSpawner>().spawned)
        {
            //Destroy(gameObject);
            if (collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(roomTemplates.closedRoomPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
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
