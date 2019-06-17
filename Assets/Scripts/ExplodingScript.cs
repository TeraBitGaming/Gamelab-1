using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExplodingScript : MonoBehaviour
{

    private PlayerCharacter pc;
    public List<GameObject> inRange = new List<GameObject>();
    public List<GameObject> IR = new List<GameObject>();
    private bool isDead = false;
    private ComboManager comboM;
    private ParticleSystem particle;
    private bool awoken;

    private ShakyShaky shaker;

    [SerializeField]
    private GameObject vase;

    [SerializeField]
    private GameObject shards;

    private Audiomanager audioManager;

    private void Explode(){
        audioManager.playSound(3);
        IR = inRange;
        foreach(GameObject item in IR.ToList()){
            
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

        StartCoroutine(shaker.Shake(0.5f, 0.75f));
    }

    private IEnumerator Die(){
        
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
        shaker = FindObjectOfType<ShakyShaky>();
        pc = FindObjectOfType<PlayerCharacter>();
        comboM = FindObjectOfType<ComboManager>();
        particle = GetComponent<ParticleSystem>();
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<Audiomanager>();
    }
    
    void Awake(){
        awoken = true;
    }

    // Update is called once per frame
    void Update(){        
        if(!isDead){
            if (vase.GetComponent<ExplodingScriptHPManager>().HP < 0){
                isDead = true;
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