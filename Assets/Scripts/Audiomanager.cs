using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    /*
    
    To play sounds, Call the function like this:

    Audiomanager.playSound(sound number);
    This will cause it to play a sound once.
    More features like looping coming soon.
    
    */

    private AudioSource source;

    [SerializeField]
    private float volume;

    [SerializeField]
    private AudioClip[] clipArray;


    public void playSound(int soundNumber){
        source.PlayOneShot(clipArray[soundNumber], volume);
    }

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
}
