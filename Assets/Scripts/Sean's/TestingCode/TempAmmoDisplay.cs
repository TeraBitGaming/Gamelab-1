using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempAmmoDisplay : MonoBehaviour
{
    private PlayerCharacter pc;
    private float fill;

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
        if(pc.magazine > 0)
        {
            fill = (float)pc.magazine / (float)pc.usingWeapon.magazine;
        }
        else
        {
            fill = pc.usingWeapon.secCostForReloading - pc.reloadTime / pc.usingWeapon.secCostForReloading;
        }
        this.GetComponent<Image>().fillAmount = fill;
    }
}
