using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author : Logothetis Fragkoulis 
 * ECE
 * Electrical and Computer Engineer 
 * 
 * */

public class Score : MonoBehaviour
{
    public static bool plays_player2 = false;
    public int scorea = 0, scoreb = 0;
    public int player1 = 0, player2 = 0;
    private Quaternion k;
    public int player = 1, counter = 0;
    public ScoreManager1 s;
    public int previous_pin = 0;
    public BowlingFrame[] p1;
    public BowlingFrame[] p2;
    public int StateP1, StateP2;
    public int term = 0;
    private bool Strike_at_end = false;
    private bool Spare_at_end = false;
   public  Text text;

    // Use this for initialization
    void Start()

    {
        p1 = new BowlingFrame[11];
        p2 = new BowlingFrame[11];
        for (int i = 0; i < 11; i++)
        {
            p1[i] = new BowlingFrame();
            p2[i] = new BowlingFrame();
        }
        StateP1 = 0;
        StateP2 = 0;
        p1[10].Score2 = 0;
        p2[10].Score2 = 0;


        text = GameObject.Find("Frame_Text").GetComponent<Text>();

    }





    // Update is called once per frame
    void Update()
    {

    }

    //____________________________________________________Change the  the player ,strike ,spare cases etch_______________________________
    public void UpdateScore(object ball)
    {
        if (term <= 8)
        {
            int pins = IsNotStanding();
            if (counter == 0)
            {
                if (pins == 10)
                {

                    previous_pin = 0;
                    if (player == 1)
                    {
                        p1[StateP1].Score1 = pins;
                        p1[StateP1].isStrike = true;
                        p1[StateP1].init = true;

                        print("strike player");
                        Give_Score(p1, scorea);
                    }
                    else
                    {
                        p2[StateP2].Score1 = pins;
                        p2[StateP2].isStrike = true;
                        p2[StateP2].init = true;
                        Give_Score(p2, scoreb);
                    }


                    Switch_Player();
                    ResetPins();
                    counter = 0;
                    Debug.Log("A");
                }
                else
                {



                    previous_pin = pins;
                    counter++;
                    if (player == 1)
                    {
                        p1[StateP1].Score1 = pins;
                        p1[StateP1].init = true;
                        
                        Give_Score(p1, scorea);

                    }
                    else
                    {
                        p2[StateP2].Score1 = pins;
                        p2[StateP2].init = true;
                        Give_Score(p2, scoreb);
                    }



                    
                }

            }
            else
            {
                counter = 0;
                if (player == 1)
                {
                    p1[StateP1].Score2 = pins - previous_pin;
                    p1[StateP1].init = true;
                    if (pins == 10) p1[StateP1].isSpare = true;
                   

                    Give_Score(p1, scorea);

                }
                else
                {
                    p2[StateP2].Score2 = pins - previous_pin;
                    p2[StateP2].init = true;
                    if (pins == 10) p2[StateP2].isSpare = true;
                    Give_Score(p2, scoreb);
                }

                previous_pin = 0;
                Switch_Player();
                ResetPins();

                Debug.Log("C");
            }
        }
        else
        {
            EndTerm();
        }


    }


    //_________________________________________________This function will run at the 10 th frame____________________________
    public void EndTerm()
    {
        int pins = IsNotStanding();
        if (Strike_at_end == true) Strike_end(pins);
        if (Spare_at_end == true) Spare_end(pins);

        if (counter == 0)
        {
            ///-----------------------Strike at end 
            if (pins == 10)
            {
                print("Strike end ");
                previous_pin = 0;
                if (player == 1)
                {
                    p1[StateP1].Score1 = pins;
                    p1[StateP1].isStrike = true;
                    p1[StateP1].init = true;

                    StateP1++;
                    Give_Score(p1, scorea);
                }
                else
                {
                    p2[StateP2].Score1 = pins;
                    p2[StateP2].isStrike = true;
                    p2[StateP2].init = true;
                    StateP2++;
                    Give_Score(p2, scoreb);

                }

                Strike_at_end = true;

                ResetPins();

            }
            else
            {


                counter++;
                previous_pin = pins;
                if (player == 1)
                {
                    p1[StateP1].Score1 = pins;
                    p1[StateP1].init = true;
                    Give_Score(p1, scorea);


                }
                else
                {
                    p2[StateP2].Score1 = pins;
                    p2[StateP2].init = true;
                    Give_Score(p2, scoreb);

                }

            }
        }
        else
        {
            if (player == 1)
            {
                p1[StateP1].Score2 = pins - previous_pin;
                p1[StateP1].init = true;
                if (pins == 10)
                {
                    print("Spare end  ");
                    p1[StateP1].isSpare = true;
                    Spare_at_end = true;
                    counter = 0;

                    StateP1++;

                }
                Give_Score(p1, scorea);
            }
            else
            {
                counter = 0;
                p2[StateP2].Score2 = pins - previous_pin;
                p2[StateP2].init = true;
                if (pins == 10)
                {

                    p2[StateP2].isSpare = true;

                    Spare_at_end = true;
                    counter = 0;
                    StateP2++;

                }
                Give_Score(p2, scoreb);
            }

            previous_pin = 0;

            if (Spare_at_end == false) Switch_Player();
            ResetPins();


        }
    }


    //_________________________________________When i have Spare at the 10 th frame____________________________________________________________

    private void Spare_end(int pins)
    {

        if (counter == 0)
        {

            counter = 0;

            if (player == 1)
            {
                p1[StateP1].Score1 = pins;

                p1[StateP1].init = true;
                Give_Score(p1, scorea);


            }
            else
            {
                p2[StateP2].Score1 = pins;

                p2[StateP2].init = true;
                Give_Score(p2, scoreb);

            }

        }

        Spare_at_end = false;
        print("End spare......");
        ResetPins();
        Switch_Player();



    }







    //_________________________________________When i have string at the 10 th frame____________________________________________________________

    public void Strike_end(int pins)
    {
        if (counter == 0)
        {

            previous_pin = pins;

            if (player == 1)
            {
                p1[StateP1].Score1 = pins;
                p1[StateP1].isStrike = true;
                p1[StateP1].init = true;


            }
            else
            {
                p2[StateP2].Score1 = pins;
                p2[StateP2].isStrike = true;
                p2[StateP2].init = true;

            }
            if (pins == 10)
            {
                ResetPins();
                previous_pin = 0;
            }
            counter++;
        }
        else
        {
            counter = 0;
            if (player == 1)
            {
                p1[StateP1].Score2 = pins - previous_pin;
                p1[StateP1].isStrike = true;
                p1[StateP1].init = true;
                Give_Score(p1, scorea);

            }
            else
            {
                p2[StateP2].Score1 = pins - previous_pin;
                p2[StateP2].isStrike = true;
                p2[StateP2].init = true;
                Give_Score(p2, scoreb);

            }


              
            Switch_Player();
            Strike_at_end = false;
            ResetPins();


        }
    }







    //_______________________________________________Compute how many pins is not standing ________________________________________________________
    public int IsNotStanding()
    {
        StartCoroutine(Delay());
        int down = 0;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Pin"))
        {
            k = g.GetComponent<Rigidbody>().transform.rotation;
            if (k != Quaternion.Euler(Vector3.zero))
            {
                g.GetComponent<Renderer>().enabled = false;
                Debug.Log("Not Standing");
                down++;
            }

        }
        return down;
    }
    //___________________________________________________Switch Player____________________________________________________________________

    public void Switch_Player()
    {
        
        if (player == 1)
        {
            ScoreManager1.choose_pointer = 1;
            player = 2;
            StateP1++;
            plays_player2 = true;

        }
        else
        {
            ScoreManager1.choose_pointer = 0;
            player = 1;
            StateP2++;
            term++;
            plays_player2 = false;
        }

        if (term == 10)
        {
            print("Telos");
            Application.LoadLevel(3);
        }
        Print_Frame();

    }


    //________________________________________________________________Give the score ___________________________________________________

    public void Give_Score(BowlingFrame[] a, int b)
    {

        
        int recheck = 0;

        if (b < 10)
        {
            /*_______________________Strike________________________________________*/
            if (a[b].isStrike == true)
            {
               
                int k = b;
                k++;

                do
                {
                    print(a[k].init + " " + a[k].isStrike + " " + k + " " + counter);
                    if (a[k].init == true && a[k].isStrike == false && k == b + 1 && counter == 0)
                    {
                        if (b != 0)
                        {
                            
                            a[b].frame_score = 10 + a[k].Score1 + a[k].Score2 + a[b - 1].frame_score;
                            a[b].finish = true;
                        }
                        else
                        {
                           
                            a[b].frame_score = 10 + a[k].Score1 + a[k].Score2;
                            a[b].finish = true;
                        }


                        b++;

                        if (player == 1) scorea = b;
                        else scoreb = b;

                        recheck = 1;
                        break;

                    }
                    else if (a[k].init == true && a[k].isStrike == true && k == b + 1)
                    {
                        k++;
                       
                    }
                    else if (a[k].init == true && k == b + 2 && counter == 0)
                    {
                        if (b != 0)
                        {
                           
                            a[b].frame_score = 20 + a[k].Score1 + a[k].Score2 + a[b - 1].frame_score;
                            a[b].finish = true;
                        }
                        else
                        {
                            
                            a[b].frame_score = 20 + a[k].Score1 + a[k].Score2;
                            a[b].finish = true;
                        }
                        b++;
                        if (player == 1) scorea = b;
                        else scoreb = b;
                        recheck = 1;
                        break;
                    }
                    else
                    {

                        break;
                    }



                } while (true);
            }
            /*_______________________Spare________________________________________*/
            else if (a[b].isSpare == true)
            {

                
                int k = b;
                k++;

                do
                {
                    if (a[k].init == true && k == b + 1)
                    {
                       
                        if (b != 0)
                        {
                            a[b].frame_score = 10 + a[k].Score1 + a[b - 1].frame_score;
                            a[b].finish = true;
                        }
                        else
                        {
                            a[b].frame_score = 10 + a[k].Score1;
                            a[b].finish = true;
                        }


                        print(a[b].frame_score);
                        b++;
                        if (player == 1) scorea = b;
                        else scoreb = b;
                        recheck = 1;
                        break;





                    }
                    else
                        break;


                } while (true);
            }
            //______________________________________All the other cases ______________________________________
            else
            {
                
                if (counter == 0 && a[b].init == true)
                {

                    if (term > 0)
                    {
                        
                        a[b].frame_score = a[b].Score1 + a[b].Score2 + a[b - 1].frame_score;
                        a[b].finish = true;
                        b++;
                        if (player == 1) scorea = b;
                        else scoreb = b;
                    }
                    else
                    {
                        
                        a[b].frame_score = a[b].Score1 + a[b].Score2;
                        a[b].finish = true;
                        b++;
                        if (player == 1) scorea = b;
                        else scoreb = b;
                    }

                    
                }

            }
        }



        if (recheck == 1)
        {

            Give_Score(a, b);

        }

        PrintScore();
        print("thesi  " + b);

    }


    //______________________________________________Print Score _______________________________________________________
    public void PrintScore()
    {
        if (player == 1)
        {
            if (p1[scorea].finish == false && scorea == 0)
                ScoreManager1.score1 = 0;

            else if (p1[scorea].finish == true)
                ScoreManager1.score1 = p1[scorea].frame_score;

            else
                ScoreManager1.score1 = p1[scorea - 1].frame_score;
        }
        else
        {
            if (p2[scoreb].finish == false && scoreb == 0)
                ScoreManager1.score2 = 0;

            else if (p2[scoreb].finish == true)
                ScoreManager1.score2 = p2[scoreb].frame_score;

            else
                ScoreManager1.score2 = p2[scoreb - 1].frame_score;



        }

    }





    IEnumerator Delay()
    {

        yield return new WaitForSeconds(7);

    }

    //_______________________________________________Reset Pins MEssage____________________________________________
    void ResetPins()
    {
        Debug.Log("reset pin");
        foreach (var v in GameObject.FindGameObjectsWithTag("Pin"))
        {
            v.SendMessage("ResetPin", 0, SendMessageOptions.DontRequireReceiver);
            v.GetComponent<Renderer>().enabled = true;
        }

    }
    //______________________________________________Print the number of the frame________________________________________
    public void Print_Frame()
    {

        text.text = "FRAME : " +(term + 1);

    }


}



//_______________________________Bowling Frame member variables _______________________________ _______________________

public class BowlingFrame
{
    //Member Variables 
    public int Score1 = 0;
    public int Score2 = 0;
    public int Score3 = 0;
    public bool isStrike = false;
    public bool isSpare = false;
    public bool init = false;
    public int frame_score = -1;
    public bool finish = false;

}


