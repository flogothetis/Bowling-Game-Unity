using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author : Logothetis Fragkoulis 
 * ECE
 * Electrical and Computer Engineer 
 * 
 * */

public class Audio_Play : MonoBehaviour
{

    // Use this for initialization
    private AudioSource source;
    private float lowPitchRange = .35F;
    private float highPitchRange = .55F;
    private float velToVol = .2F;
  
    private float velocityClipSplit = 10F;
    public AudioClip crashSoft;
    public AudioClip crashHard;
  
    void Awake()
    {

        source = GetComponent<AudioSource>();
    }
    
    // When the ball be thrown to the floor 
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name=="Ball")
        { 
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = coll.relativeVelocity.magnitude * velToVol;
             //Sound Effects 
                source.PlayOneShot(crashSoft, hitVol);
                source.PlayOneShot(crashHard, hitVol);
            
            
    }
}
}
