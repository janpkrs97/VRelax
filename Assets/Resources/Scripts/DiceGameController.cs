using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiceGameController : MonoBehaviour
{
    private int points = 0;
    public Text pointsTxt;
    public Text rollValueTxt;
    public Text questionTxt;
    public List<string> questions;
    private int randomNum;
    public GameObject rollAgainBtn;

    public void PressedRollAgain()
    {
        randomNum = (int) Random.Range(1, 7);
        rollValueTxt.text = randomNum + "..";
        questionTxt.text = "" + questions[randomNum - 1] + "";
        CalculatePoints(randomNum);
    }

    public void CalculatePoints(int randNum)
    {
        int oldPoints = points;

        if (randNum % 2 != 0)
        {
            points += randNum;
            pointsTxt.text = "Points:\n" + oldPoints + " + " + randNum + " = " + points;

            if (points >= 10)
            {
                SceneManager.LoadScene("EndMenu", LoadSceneMode.Single);
            }
        }
        else
        {
            points -= randNum;
            pointsTxt.text = "Points:\n" + oldPoints + " - " + randNum + " = " + points;

            if (points <= 0)
            {
                points = 0;
            }
        }  
    }
}
