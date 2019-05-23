using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingScript : MonoBehaviour
{


    private void Explode(){
        Collider[] hitColliders = Physics.OverlapSphere(Vector3.zero, 10);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Debug.Log("DAMAGE ME" + hitColliders[i]);
            i++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
    }
}
