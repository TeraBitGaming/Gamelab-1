using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomGenerator : MonoBehaviour
{

    public GameObject topSnap;
    public GameObject rightSnap;
    public GameObject bottomSnap;
    public GameObject leftSnap;
    public GameObject prefabthingy;
    public int[] possibleRooms;
    private GameObject[] rooms;
    private GameObject currentRoom;

    public bool[] meeple;


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(prefabthingy, new Vector3(topSnap.transform.position.x, 0, topSnap.transform.position.z), Quaternion.identity);
        // Instantiate(prefabthingy, new Vector3(rightSnap.transform.position.x, 0, rightSnap.transform.position.z), Quaternion.identity);
        // Instantiate(prefabthingy, new Vector3(bottomSnap.transform.position.x, 0, bottomSnap.transform.position.z), Quaternion.identity);
        // Instantiate(prefabthingy, new Vector3(leftSnap.transform.position.x, 0, leftSnap.transform.position.z), Quaternion.identity);
        rooms = GameObject.Find("Main Camera").GetComponent<RoomHolder>().rooms;
        for(int i = 0; i < rooms.Length; i++){
            Debug.Log("1!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Declaring some useful shtuff, can't be done within start.
        RaycastHit hit;
        Vector3 down = transform.TransformDirection(new Vector3(0, -1, 0.1f)) * 10;
        Vector3 left = transform.TransformDirection(new Vector3(-1, 0, 0.1f)) * 10;
        Vector3 right = transform.TransformDirection(new Vector3(1, 0, 0.1f)) * 10;
        Vector3 up = transform.TransformDirection(new Vector3(0, 1, 0.1f)) * 10;
        Vector3[] directions = new [] {down, left, right, up};
        GameObject[] snaps = new [] {topSnap, rightSnap, bottomSnap, leftSnap};
        string[] currentDirection = new [] {"downDoor", "leftDoor", "rightDoor", "upDoor"};


        for (int a = 0; a < snaps.Length; a++){
            for (int b = 0; b < directions.Length; b++){
                Debug.DrawRay(snaps[a].transform.position, directions[b], Color.green, 2);
                Physics.Raycast(snaps[a].transform.position, directions[b], out hit, 10);
                int[] possibleRooms = new [] {0, 0, 0, 0};
                
                if(Physics.Raycast(snaps[a].transform.position, directions[b], out hit, 10) == true){
                    if (hit.transform.gameObject.GetComponent<InformationHolder>().possibleRooms[b] == true){
                        possibleRooms[b] = 1;
                    } else if (hit.transform.gameObject.GetComponent<InformationHolder>().possibleRooms[b] == false){
                        possibleRooms[b] = 2;
                    }
                } else if (Physics.Raycast(snaps[a].transform.position, directions[b], out hit, 10) == false){
                    possibleRooms[b] = 0;
                }
                for (int c = 0; c < rooms.Length; c++){
                    for(int d = 0; d < 4; d++){
                        currentRoom = rooms[c];
                        currentRoom = gameObject.transform.GetChild(0);
                        currentRoom.transform.gameObject.GetComponent<InformationHolder>().possibleRooms[d];
                    }
                }
                //I need to create a way to read & compare possiblerooms to rooms. 2 for-loops should do the trick,
                //as then I can compare each rooms information individually, I'll also need to take care to mirror the results, 
                //so that the northern door lines up w/ the southern door.

            }


        // if(Physics.Raycast(topSnap.transform.position, down, out hit, 10) == false){
            // Debug.Log("Hello");
        // }
        // if(Physics.Raycast(topSnap.transform.position, left, out hit, 10) == false){
            // Debug.Log("Hello left");
        // }
        // if(Physics.Raycast(topSnap.transform.position, right, out hit, 10) == false){
            // Debug.Log("Hello right");
        // }
        // if(Physics.Raycast(topSnap.transform.position, up, out hit, 10) == false){
            // Instantiate(prefabthingy, new Vector3(topSnap.transform.position.x, 0, topSnap.transform.position.z), Quaternion.identity);
        // }
        }
    }
}