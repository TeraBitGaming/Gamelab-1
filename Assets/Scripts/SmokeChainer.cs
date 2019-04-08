using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeChainer : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem pS1;

    [SerializeField]
    private ParticleSystem pS2;

    public void PlayPS(){
        pS1.Play();
        pS2.Play();
    }
}