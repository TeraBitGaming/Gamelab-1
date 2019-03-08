using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationHolder : MonoBehaviour
{
    public bool downDoor;
    public bool leftDoor;
    public bool rightDoor;
    public bool upDoor;
    public bool[] possibleRooms;
    
    void Start(){
        possibleRooms = new [] {downDoor, leftDoor, rightDoor, upDoor};
        // Debug.Log(possibleRooms[2]);
    }
}