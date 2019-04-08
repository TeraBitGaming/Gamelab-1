using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private TargetJoint2D Tj2D;

    // Start is called before the first frame update
    void Start()
    {
        Tj2D = GameObject.FindWithTag("MainCamera").GetComponent<TargetJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            Debug.Log("heyo!");
            Tj2D.target = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
