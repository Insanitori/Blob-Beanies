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
    // Start is called before the first frame update
    void Start()
    {
        timesupText.SetActive(false);
        timebar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timebar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            timesupText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
