using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingScript : MonoBehaviour
{

    private PlayerCharacter pc;
    public List<GameObject> inRange = new List<GameObject>();
    private bool isDead = false;
    private ComboManager comboM;
    private ParticleSystem particle;
    private bool awoken;

    [SerializeField]
    private GameObject vase;

    [SerializeField]
    private GameObject shards;

    private void Explode(){

        foreach(GameObject item in inRange){
            
            if(item.tag == "Enemy"){
                if (item.GetComponent<TempEnemy>() != null){
                    item.GetComponent<TempEnemy>().GetHit(50);
                } else {
                    item.GetComponent<ExplodingScriptHPManager>().HP -= 2;
                }
            }

            if(item.tag == "Player"){
                comboM.ResetCombo();
                pc.HP -= 30;
            }
        }
    }

    IEnumerator Die(){
        
        isDead = true;
        
        yield return new WaitForSeconds(0.1f);

        particle.Play();
        Explode();
        shards.SetActive(true);
        vase.SetActive(false);
        
        yield return new WaitForSeconds(particle.main.duration);
        
        particle.Stop();

        yield return new WaitForSeconds(1.5f);

        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start(){
        pc = FindObjectOfType<PlayerCharacter>();
        comboM = FindObjectOfType<ComboManager>();
        particle = GetComponent<ParticleSystem>();
    }
    
    void Awake(){
        awoken = true;
    }

    // Update is called once per frame
    void Update(){        
        if(!isDead){
            if (vase.GetComponent<ExplodingScriptHPManager>().HP < 0){
                StartCoroutine(Die());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy"){
            inRange.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy"){
            inRange.Remove(col.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col){
        if (awoken == true){
            awoken = false;
            if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy"){
                inRange.Add(col.gameObject);
            }
        }
    }
}