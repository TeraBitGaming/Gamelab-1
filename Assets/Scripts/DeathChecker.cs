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

    private bool stop = false;

    public bool wipe;

    void Start(){
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wipe = true){
            wipe = false;
            PlayerPrefs.SetInt("Money", 0);
        }
        gameObject.transform.position = pc.transform.position;
        if(pc.activeSelf == false && stop != true){
            stop = true;
            anim.SetBool("isDead", true);
            anim.gameObject.transform.localScale = new Vector3(1.7f, 1.7f, 1);
            endScreen.SetActive(true);
            textField.text = cm.GetCombo();

            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + cm.GetComboInt());
            Debug.Log(PlayerPrefs.GetInt("Money"));
        }
    }
}
