using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomGenerator : MonoBehaviour
{

    public GameObject northSnap;
    public GameObject eastSnap;
    public GameObject southSnap;
    public GameObject westSnap;
    public GameObject prefabthingy;


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(prefabthingy, new Vector3(northSnap.transform.position.x, 0, northSnap.transform.position.z), Quaternion.identity);
        // Instantiate(prefabthingy, new Vector3(eastSnap.transform.position.x, 0, eastSnap.transform.position.z), Quaternion.identity);
        // Instantiate(prefabthingy, new Vector3(southSnap.transform.position.x, 0, southSnap.transform.position.z), Quaternion.identity);
        // Instantiate(prefabthingy, new Vector3(westSnap.transform.position.x, 0, westSnap.transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Vector3 left = transform.TransformDirection(Vector3.left) * 10;
        Vector3 right = transform.TransformDirection(Vector3.right) * 10;
        Vector3 back = transform.TransformDirection(Vector3.back) * 10;

        Debug.DrawRay(northSnap.transform.position, forward, Color.green, 2);
        Debug.DrawRay(northSnap.transform.position, left, Color.green, 2);
        Debug.DrawRay(northSnap.transform.position, right, Color.green, 2);
        Debug.DrawRay(northSnap.transform.position, back, Color.green, 2);

        if(Physics.Raycast(northSnap.transform.position, forward, out hit, 10) == false){
            Debug.Log("Hello");
        }
        if(Physics.Raycast(northSnap.transform.position, left, out hit, 10) == false){
            Debug.Log("Hello left");
        }
        if(Physics.Raycast(northSnap.transform.position, right, out hit, 10) == false){
            Debug.Log("Hello right");
        }
        if(Physics.Raycast(northSnap.transform.position, back, out hit, 10) == false){
            Instantiate(prefabthingy, new Vector3(northSnap.transform.position.x, 0, northSnap.transform.position.z), Quaternion.identity);
        }
    }
}