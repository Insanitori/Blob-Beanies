using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    

    public int width;
    public int height;
    private BackgroundTile[,] allTiles;

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
            
        }
    }


    private void SetUp()
    {
        for(int i = 0; i < width; i++)
        {
            for( int j = 0; j < height; j++)
            {
                Vector2 pos = new Vector2(i,j);
                GameObject backgroundTile = Instantiate(tilePrefab, pos, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "( " + i + "_" + j + " )";
                int slimeToUse = Random.Range(0, slimes.Length);
                GameObject slime = Instantiate(slimes[slimeToUse], pos, Quaternion.identity);
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
                }
                damageCheck = false;
            }
            nullCount = 0;
        }

        yield return new WaitForSeconds(1);
    }
}
