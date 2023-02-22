using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceens : MonoBehaviour
{
    public Board board;

    public GameObject Yes;
    public GameObject No;
    public GameObject AreUsURE;
    public GameObject bleh;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        AreUsURE.SetActive(true);
        Yes.SetActive(false);
        No.SetActive(false);
        bleh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Starting()
    {
        SceneManager.LoadScene("MobileClass");
    }

    public void PausingStuff()
    {
        AreUsURE.SetActive(false);
        Yes.SetActive(true);
        No.SetActive(true);
        bleh.SetActive(true);

        board.currentState = GameState.wait;
    }

    public void VerySure()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NotSure()
    {
        AreUsURE.SetActive(true);
        Yes.SetActive(false);
        No.SetActive(false);
        bleh.SetActive(false);

        board.currentState = GameState.move;
    }
}
