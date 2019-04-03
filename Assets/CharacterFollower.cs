using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
    private TargetJoint2D Tj2D;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Tj2D = gameObject.GetComponent<TargetJoint2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Tj2D.target = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
