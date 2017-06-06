using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager1 : MonoBehaviour
{
    public static  int score1;        // The player's score.
    public static  int score2;        // The player's score.
    public static int choose_pointer;

    Text text;                      // Reference to the Text component.


    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score1 = 0;
        score2 = 0;
        choose_pointer = 0;
    }


    void Update()
    {
        if(choose_pointer==0)
        text.text = "> PLAYER 1 :" + score1 + "\n" + "PLAYER 2 :" + score2;
        else
        text.text = "PLAYER 1 :" + score1 + "\n" + "> PLAYER 2 :" + score2;
    }



   
}