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

    [SerializeField]
    private GameObject vase;

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

    IEnumerator Die(){
        particle.Play();
        isDead = true;
        Explode();
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

    // Update is called once per frame
    void Update(){        
        if(!isDead){
            if (FindObjectOfType<ExplodingScriptHPManager>().HP < 0){
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
}