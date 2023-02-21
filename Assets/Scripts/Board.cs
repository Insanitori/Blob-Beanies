using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    wait,
    move
}
public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    public GameState currentState = GameState.move;

    public int width;
    public int height;
    private BackgroundTile[,] allTiles;

    public int offSet;

    public GameObject tilePrefab;

    public bool damageCheck;

    public GameObject[] slimes;
    public GameObject[,] everyslime;

    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        everyslime = new GameObject[width, height];
        SetUp();

        damageCheck = false;
    }

    void Update()
    {
        if (damageCheck)
        {
            StartCoroutine(DecreaseRow());
            StartCoroutine(fillboard());
        }
    }


    private void SetUp()
    {
        for(int i = 0; i < width; i++)
        {
            for( int j = 0; j < height; j++)
            {
                Vector2 pos = new Vector2(i,j + offSet);
                GameObject backgroundTile = Instantiate(tilePrefab, pos, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + "_" + j + " )";
                int slimeToUse = Random.Range(0, slimes.Length);
                GameObject slime = Instantiate(slimes[slimeToUse], pos, Quaternion.identity);
                slime.GetComponent<Slime>().row = j;
                slime.GetComponent<Slime>().column = i;
                slime.transform.parent = this.transform;
                slime.name = "( " + i + "_" + j + " )";

                everyslime[i, j] = slime;
            }
        }
    }

    private IEnumerator DecreaseRow()
    {
        int nullCount = 0;

        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                if(everyslime[i, j] == null)
                {
                    nullCount++;
                }
                else if (nullCount > 0)
                {
                    everyslime[i,j].GetComponent<Slime>().row -= nullCount;
                    everyslime[i, j] = null;
                }
                damageCheck = false;
            }
            nullCount = 0;
        }

        yield return new WaitForSeconds(.2f);
    }

    private void RefillBoard()
    {
        for(int i = 0; i < width; i++)
        { for (int j = 0; j < height; j++)
            {
                if (everyslime[i, j] == null)
                {
                    Vector2 temp = new Vector2(i, j + offSet);
                    int slimetoUse = Random.Range(0, slimes.Length); ;
                    GameObject piece = Instantiate(slimes[slimetoUse], temp,Quaternion.identity);
                    everyslime[i, j] = piece;
                    piece.GetComponent<Slime>().row = j;
                    piece.GetComponent<Slime>().column = i;
                    piece.transform.parent = this.transform;
                }
            } 
        }
    }

    private IEnumerator fillboard()
    {
        yield return new WaitForSeconds(.3f);
        RefillBoard();

        yield return new WaitForSeconds(.4f);
        currentState = GameState.move;
    }

}
