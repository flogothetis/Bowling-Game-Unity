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
public class Final1 : MonoBehaviour
{
    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Print the Total score at the end of the game 
    //and when the gamer push the 'esc' button 
    void Update()
    {
        text.text = "PLAYER 1 :" + ScoreManager1.score1 + "\n" + "PLAYER 2 :" + ScoreManager1.score2;
    }
}
