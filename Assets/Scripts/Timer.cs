using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timebar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject timesupText;
    public GameObject GameStarting;
    public GameObject GameAhh;

    public int moreTime;
    public float lessTime;

    public bool gameStart;
    public bool gameStop;

    public Board board;

    // Start is called before the first frame update
    void Start()
    {
        timesupText.SetActive(false);
        timebar = GetComponent<Image>();
        timeLeft = maxTime;

        moreTime = 0;
        lessTime = 0;

        gameStart = false;
        gameStop = false;

        board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        if (board.currentState == GameState.move)
        {
            if (gameStart)
            {
                GameStarting.SetActive(false);
                GameAhh.SetActive(false);
                if (timeLeft > 0)
                {
                    if (timeLeft > maxTime)
                    {
                        timeLeft = maxTime;
                    }

                    timeLeft += moreTime;
                    moreTime = 0;
                    timeLeft -= Time.deltaTime + lessTime;
                    timebar.fillAmount = timeLeft / maxTime;
                }
                else
                {
                    timesupText.SetActive(true);
                    timeLeft = 0;
                    gameStop = true;
                }
            }
            else
            {
                GameStarting.SetActive(true);
                GameAhh.SetActive(true);
            }
        }
    }
}
