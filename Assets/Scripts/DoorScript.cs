using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private GameObject temporaryGameObject;
    private float distance = 1.5f;
    public bool set2f = false;

    // Start is called before the first frame update
    void Start()
    {
        if (set2f == true){
            distance = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        temporaryGameObject = GameObject.FindWithTag("Player");
        // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 2, Color.red);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            // if(vertical == true){
            //     temporaryGameObject.transform.position = gameObject.transform.position + transform.TransformDirection(Vector2.left) * distance;
            // } else if (vertical == false){
            //     temporaryGameObject.transform.position = gameObject.transform.position + transform.TransformDirection(Vector2.down) * distance;
            // }
            temporaryGameObject.transform.position = gameObject.transform.position + transform.TransformDirection(Vector2.down) * distance;
        }
    }
}