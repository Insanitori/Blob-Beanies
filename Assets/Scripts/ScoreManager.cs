using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int holder;
    private int multiplier;

    public TextMeshProUGUI ScoreNumber;

    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();

        holder = 0;
        multiplier = 0;
    }

    // Update is called once per frame
    void Update()
    {
        multiplier = holder * 110;

        ScoreNumber.text = "Score: " + multiplier;
    }
}
