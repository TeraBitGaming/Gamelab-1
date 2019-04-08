using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeaponPickUps : MonoBehaviour
{
    private PlayerCharacter pc;
    [SerializeField]
    private int wpCode = 0;

    private void Awake()
    {
        pc = FindObjectOfType<PlayerCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerCharacter>())
        {
            pc.ChangeWeapon(wpCode);
        }
    }
}
