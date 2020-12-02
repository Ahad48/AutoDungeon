using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    Spawn spawn; // The spawnpoint of the gameobject
    RoomManager roomTemplates; // The room manager which stores all room prefabs
    bool spawned = false; // If the room has spawened or not

    static int numRooms = 0; // Total number of rooms that are in the game view
    int maxRooms; // The maximun number of rooms that can be in the game view
    float waitTime = 5f; // Destroy the game object

    GameObject roomPrefab = null;

    Vector3 position;

    void Start()
    {
        // Destroy the spawn point after a certain time
        Destroy(this.gameObject, waitTime);

        // Get the Spwnpoint spawn refernce
        spawn = gameObject.GetComponent<SpawnPoint>().spawn;

        // Get the room manager for the various room templates
        roomTemplates = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();

        // The maximum number of rooms from the room templates
        maxRooms = roomTemplates.maxRooms;
        //print(spawn.doorDirection);

        // The position where the room needs to be initialised
        position = transform.position;
        Invoke("SpawnRoom", 0.1f);
    }

    /// <summary>
    /// Spawns a room at the position of the gameobject
    /// Selects a random room from the templates provided, randomly selects a room from the templates provided.
    /// </summary>
    void SpawnRoom()
    {
        if (!spawned)
        {
            // if more rooms can be initialised 
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

            // if the num of rooms exceed the maximum amount spawn closed rooms
            else
            {
                roomPrefab = Instantiate(roomTemplates.closedRoomPrefab, position, Quaternion.identity);
            }

            spawned = true;
            numRooms++;
        }
    }


    /// <summary>
    /// Check if another room has already been spawned at the spot
    /// </summary>
    /// <param name="collision"></param>
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

    /// <summary>
    /// A helper function rounds the vector to nearest value
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns>Vector 3 with neared integer value</returns>
    Vector3 vector3Round(Vector3 vector3)
    {
        vector3.x = Mathf.Round(vector3.x);
        vector3.y = Mathf.Round(vector3.y);
        vector3.z = Mathf.Round(vector3.z);
        return vector3;
    }
}
