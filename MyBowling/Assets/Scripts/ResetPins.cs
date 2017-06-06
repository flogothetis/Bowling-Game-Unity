using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPins : MonoBehaviour {

    public Vector3 _Position;
    public Quaternion _Rotation;
    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;
    public AudioClip crashSoft;


    // initialiser pin
    void OnEnable()
    {
        _Position = gameObject.transform.position;
        _Rotation = gameObject.transform.rotation;
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        float hitVol = coll.relativeVelocity.magnitude * velToVol;
        
            source.PlayOneShot(crashSoft, hitVol);
       
    }

    // reinitialiser les pin {0,1} 

    public void ResetPin(object _ball)
    {

        gameObject.transform.position = _Position;
        gameObject.transform.rotation = _Rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }
}
