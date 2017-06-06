using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LancerBall : MonoBehaviour {
    public float _Power;
    public int _Throw= 15 ;
    private int LowerLimit =19000 ;
    private int UpperLimit = 70000;
    private bool ball_thrown;
    Rigidbody rb_ball;
    private Vector3 _Position;
    GameObject gm;
    private Quaternion _Rotation;
    private Vector3 position_camera;
    private Quaternion rotation_camera;
     GameObject g;
    Image PowerLine;
    private Vector3 newPos;

    void OnEnable()
    {
        _Position = gameObject.transform.position;
        _Rotation = gameObject.transform.rotation;
        gm = GameObject.Find("Main Camera");
        position_camera = gm.transform.position;
        rotation_camera = gm.transform.rotation;



    }

    // Use this for initialization
    void Start () {
        rb_ball = GetComponent<Rigidbody>();
        rb_ball.useGravity = false;
        ball_thrown = false;

        

        GameObject.Find("Main Camera").SendMessage("ready_key", 1);
        PowerLine = GameObject.Find("PowerLine").GetComponent<Image>();

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(10);
    }
	

    //___________________________________________________________________Throw the ball____________________________________________
	// Give the power and the torque to the ball with Space Button 
	void Update () {
        if (Menu.play_with_computer == true && Score.plays_player2 == true && !ball_thrown)
        {
            //When the gamer plays against the computer 

            Delay();
            PowerLine.fillAmount = 0;
            _Power += _Throw * 1000 * UnityEngine.Random.Range(1, 4);
                PowerLine.fillAmount = _Power / 70000f;
            Transform camera =GameObject.Find("Main Camera").GetComponent<Transform>();
            newPos = new Vector3(camera.position.x, camera.position.y, UnityEngine.Random.Range((float)-16, (float)+30));
            camera.position = newPos;
            transform.position = newPos;
            StartCoroutine(Throw());
            


        }
        else
        {
            // Give Force to the ball with 'Space' Button 
            if (Input.GetKey(KeyCode.Space) && !ball_thrown)
            {
                _Power += _Throw * 1000 * Time.deltaTime;
                PowerLine.fillAmount = _Power / 70000f;
            }

            if (Input.GetKeyUp(KeyCode.Space) && !ball_thrown)
            {
                StartCoroutine(Throw());
            }
        }

    }
//Throw the ball 
    private IEnumerator Throw()
    {
        transform.parent = null;
        rb_ball.useGravity = true;
        if (_Power < LowerLimit) _Power = LowerLimit;
        else if (_Power > UpperLimit) _Power = UpperLimit;
        
        rb_ball.AddForce(transform.forward*_Power);
        rb_ball.AddForce(transform.right*UnityEngine.Random.Range(0, +3000)* UnityEngine.Random.Range(-1,+1));
        rb_ball.AddTorque( (transform.right* UnityEngine.Random.Range(-200, +200)));
        ball_thrown = true;
      
    
        yield  return 0;


    }

    //_______________________________Reset the Ball ______________________________________________________________________
    public void Reset(int _ball)
    {
        // reinitialiser ballon
        StartCoroutine(DelayBallReset(2));
    }

    IEnumerator DelayBallReset(float secs)
    {
        GameObject.Find("Main Camera").SendMessage("ready_key", 9);

        rb_ball.useGravity = false;
        
        gameObject.GetComponent<ConstantForce>().force = Vector3.zero;
        gameObject.GetComponent<ConstantForce>().relativeForce = Vector3.zero;
        gameObject.GetComponent<ConstantForce>().torque = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.transform.position = _Position;
        gameObject.transform.rotation = _Rotation;
        gm.transform.position = position_camera;
        gm.transform.rotation = rotation_camera;
        _Power = 0;

        yield return new WaitForSeconds(secs);
        transform.parent = gm.transform;
        gameObject.GetComponent<Renderer>().enabled = true;
        GameObject.Find("Main Camera").SendMessage("ready_key", 1);
        yield return new WaitForSeconds(secs);
        ball_thrown = false;

    }





    
}

