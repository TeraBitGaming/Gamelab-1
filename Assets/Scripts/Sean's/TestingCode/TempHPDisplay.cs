using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempHPDisplay : MonoBehaviour
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
        fill = (float)pc.HP / 100f;
        this.GetComponent<Image>().fillAmount = fill;
    }
}
