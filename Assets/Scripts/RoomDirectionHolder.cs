using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDirectionHolder : MonoBehaviour
{
    public GameObject[] upConnection;
    public GameObject[] rightConnection;
    public GameObject[] bottomConnection;
    public GameObject[] leftConnection;

    public GameObject extraRoom;

    public List<GameObject> rooms;

    public float waitTime = 4;

    private bool spawnedBoss;
	public GameObject boss;

    void Update(){
        if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
    }
}
