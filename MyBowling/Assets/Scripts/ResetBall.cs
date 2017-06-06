using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour {

    public int _Ball = 0;
    bool doUpdate = false;


    void Start()
    {

    }


    void Update()
    {

    }

    
    void LateUpdate()
    {
        if (doUpdate)
        {
             Debug.Log("Update Score");
           // WaitForSeconds(1.5 sec);

            gameObject.SendMessage("UpdateScore", _Ball, SendMessageOptions.RequireReceiver);
        }
        doUpdate = false;
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LancerBall>() != null)
        {
            doUpdate = true;
            other.gameObject.SendMessage("Reset", _Ball, SendMessageOptions.DontRequireReceiver);
        }


    }
    


}
