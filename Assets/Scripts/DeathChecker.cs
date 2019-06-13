using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject pc;
    
    private Animator anim;

    [SerializeField]
    private Text textField;

    [SerializeField]
    private ComboManager cm;

    [SerializeField]
    private GameObject endScreen;

    void Start(){
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = pc.transform.position;
        if(pc.activeSelf == false){
            anim.SetBool("isDead", true);
            anim.gameObject.transform.localScale = new Vector3(1.7f, 1.7f, 1);
            endScreen.SetActive(true);
            textField.text = cm.GetCombo();
        }
    }
}
