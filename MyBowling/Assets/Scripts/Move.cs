using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author : Logothetis Fragkoulis 
 * ECE
 * Electrical and Computer Engineer 
 * 
 * */

    //________________________________________Translate and Rotate the Player (Camera ) ______________________________________________
public class Move : MonoBehaviour
{

    double UpperLimitLeft = -23;
    double UpperLimitRight = +32;
    private Vector3 newPos;
    public GameObject player;
    public bool ready_for_keyboard = true;
    public Quaternion newPos2;

    public float UpperLimitLeftRotation = 261;

    public float UpperLimitRightRotation = 287;
    private Quaternion fg;

    private int counter =0;







    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.LoadLevel(3);
        }


      

            if (Input.GetKey("left") && Input.GetKey("up") && ready_for_keyboard)
            {


                //   transform.rotation.eulerAngles.y > UpperLimitLeftRotation

                if (transform.localRotation.eulerAngles.y > UpperLimitLeftRotation)
                {
                    Debug.Log(transform.localRotation.eulerAngles.y);
                    transform.Rotate(0, -1, 0);
                }


            }
            else if (Input.GetKey("right") && Input.GetKey("up") && ready_for_keyboard)
            {


                if (transform.localRotation.eulerAngles.y < UpperLimitRightRotation)
                {
                    transform.Rotate(0, +1, 0);
                }


            }



            else if (Input.GetKey("left") && ready_for_keyboard)
            {
                if (transform.position.z > UpperLimitLeft)
                {
                    var fpx = transform.position.z;
                    fpx = fpx - 1;
                    if (fpx > UpperLimitLeft)
                    {

                        newPos = new Vector3(transform.position.x, transform.position.y, fpx);
                    }
                    else
                    {
                        newPos = new Vector3(transform.position.x, transform.position.y, (float)UpperLimitLeft);
                    }

                    transform.position = newPos;
                }
                else
                {
                    Vector3 newPos = new Vector3(transform.position.x, transform.position.y, (float)UpperLimitLeft);
                    transform.position = newPos;
                }

            }
            else if (Input.GetKey("right") && ready_for_keyboard)
            {
                if (transform.position.z < UpperLimitRight)
                {
                    var fpx = transform.position.z;
                    fpx = fpx + 1;
                    if (fpx < UpperLimitRight)
                    {

                        newPos = new Vector3(transform.position.x, transform.position.y, fpx);
                    }
                    else
                    {
                        newPos = new Vector3(transform.position.x, transform.position.y, (float)UpperLimitRight);
                    }

                    transform.position = newPos;
                }
                else
                {
                    Vector3 newPos = new Vector3(transform.position.x, transform.position.y, (float)UpperLimitRight);
                    transform.position = newPos;
                }

            }





        }
    


    public void ready_key(int i)

    {
        if (i == 1)
            ready_for_keyboard = true;
        else
            ready_for_keyboard = false;

    }



}
