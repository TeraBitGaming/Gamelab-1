using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingScript : MonoBehaviour
{

    private PlayerCharacter pc;
    public List<GameObject> inRange = new List<GameObject>();
    private bool isDead = false;
    private ComboManager comboM;

    [SerializeField]
    private int HP = 1;


    public void GetHit(int atk)
    {
        Debug.Log("Gethit is called");
        if(!isDead)
        {
            if (this.HP <= 0)
            {
                Die();
            }
            this.HP -= atk;
        }
    }

    private void Die(){
        isDead = true;
        Explode();
    }

    private void Explode(){

        foreach(GameObject item in inRange){
            
            if(item.tag == "Enemy"){
                item.GetComponent<TempEnemy>().GetHit(50);
            }

            if(item.tag == "Player"){
                comboM.ResetCombo();
                pc.HP -= 30;
            }
        }
    }

    // Start is called before the first frame update
    void Start(){
        pc = FindObjectOfType<PlayerCharacter>();
        comboM = FindObjectOfType<ComboManager>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject);
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy"){
            inRange.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy"){
            inRange.Remove(col.gameObject);
        }
    }
}