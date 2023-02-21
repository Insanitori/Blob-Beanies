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

    public int moreTime;
    private float lessTime;
    private float offsetting;
    // Start is called before the first frame update
    void Start()
    {
        timesupText.SetActive(false);
        timebar = GetComponent<Image>();
        timeLeft = maxTime;

        moreTime = 0;
        lessTime = 0;
        offsetting = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft += moreTime;
            moreTime = 0;
            timeLeft -= Time.deltaTime + lessTime;
            timebar.fillAmount = timeLeft / maxTime;
        }
        else if (timeLeft > maxTime){
            timeLeft = maxTime;
        }
        else
        {
            timesupText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private IEnumerator difficulty()
    {
        yield return new WaitForSeconds(10);
        lessTime = .002f * offsetting;
        offsetting++;
    }
}
