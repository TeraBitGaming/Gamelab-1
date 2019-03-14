using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    public int direction;
    // 1 == need up connection
    // 2 == need right connection
    // 3 == need down connection
    // 4 == need left connection

    private RoomDirectionHolder rooms;
    private int R;
    public bool done = false;
    public float waitTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        rooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomDirectionHolder>();
        Invoke("MakeRooms", 0.2f);
    }

    // Update is called once per frame
    void MakeRooms()
    {
        if (done == false){
            if (direction == 1)
            { // need a room with an up opening
                R = Random.Range(0, rooms.upConnection.Length);
                Instantiate(rooms.upConnection[R], transform.position, rooms.upConnection[R].transform.rotation);
            } else if (direction == 2)
            { // need a room with a right opening
                R = Random.Range(0, rooms.rightConnection.Length);
                Instantiate(rooms.rightConnection[R], transform.position, rooms.rightConnection[R].transform.rotation);

            } else if (direction == 3)
            { // need a room with bottom opening
                R = Random.Range(0, rooms.bottomConnection.Length);
                Instantiate(rooms.bottomConnection[R], transform.position, rooms.bottomConnection[R].transform.rotation);

            } else if (direction == 4)
            { // need a room with left opening
                R = Random.Range(0, rooms.leftConnection.Length);
                Instantiate(rooms.leftConnection[R], transform.position, rooms.leftConnection[R].transform.rotation);

            }
            done = true;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Spawn Point")){
            if(other.GetComponent<RoomGenerator>().done == false && done == false){
				Instantiate(rooms.extraRoom, transform.position, transform.rotation);
				Destroy(gameObject);
			} 
			done = true;
        }
    }
}

// check if room can be generated; receive input from raycasts, create room based on info from raycast. return 0, 1 or 2 based on whether it's empty, a wall or a door. 
// 0 = ignore; doesn't matter what's put here.
// 1 = wall, don't build anything that has a door here.
// 2 = requires door (so door=true).