using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempDash : MonoBehaviour
{
    private PlayerCharacter pc;
    private GameObject player;
    public JoyStick mjst;

    private void Awake()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        player = pc.gameObject;
    }

    public void PlayerDash()
    {
        player.GetComponent<Rigidbody2D>().AddForce(mjst.record * Time.deltaTime * 100000);
        print("is dashed.");
    }
}
