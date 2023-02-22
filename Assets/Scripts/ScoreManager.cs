using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int holder;
    private int multiplier;
    private int another;

    private int highscore;

    public TextMeshProUGUI ScoreNumber;
    public TextMeshProUGUI Highnumber;
    public TextMeshProUGUI New;
    public TextMeshProUGUI old;

    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        holder = 0;
        multiplier = 0;
        timer = FindObjectOfType<Timer>();
        highscore = PlayerPrefs.GetInt("highScore");
        //highscore = 0;
        another = highscore;

        New.text = "";
        old.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        multiplier = holder * 112;

        ScoreNumber.text = "Score: " + multiplier;

        if(multiplier > highscore)
        {
            highscore = multiplier;
            PlayerPrefs.SetInt("highScore", highscore);
            PlayerPrefs.Save();

        }
        else
        {
            PlayerPrefs.SetInt("highScore", highscore);
            PlayerPrefs.Save();
        }

        Highnumber.text = "" + (highscore);

        if(timer.gameStop)
        {
            if(multiplier > another)
            {
                New.text = "New Highscore: " + highscore;
            }
            else
            {
                New.text = "Your Score: " + multiplier;
                old.text = "Highscore: " + highscore;
            }
        }

        //Debug.Log(highscore);




    }
}
