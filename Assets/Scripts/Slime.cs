using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update

    public bool selected;

    public int column;
    public int row;
    public int targetX;
    public int targetY;

    private Vector2 temp;

    public Board board;

    private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right};
    void Start()
    {
        selected = false;
        board = FindObjectOfType<Board>();

        /*targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;

        row = targetY;
        column = targetX;*/
    }

    // Update is called once per frame
    void Update()
    {
        targetX = column;
        targetY = row;

        if(Mathf.Abs(targetX - transform.position.x) > .1)
        {
            temp = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, temp, .2f);
            
            if (board.everyslime[column,row] != this.gameObject)
            {
                board.everyslime[column,row] = this.gameObject;
            }
        }
        else
        {
            temp = new Vector2(targetX, transform.position.y);
            transform.position = temp;
        }
        
        if(Mathf.Abs(targetY - transform.position.y) > .1)
        {
            temp = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, temp, .2f);

            if (board.everyslime[column, row] != this.gameObject)
            {
                board.everyslime[column, row] = this.gameObject;
            }
        }
        else
        {
            temp = new Vector2(transform.position.x, targetY);
            transform.position = temp;
        }

        if(selected)
        {
            GetAllAdjacentTiles();
            StartCoroutine(delay());
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log(tag);
    }

    private GameObject GetAdjacent(Vector2 castDir)
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);

        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, castDir, 1);
        /*if (hit.collider != null)
        {
            
            if (gameObject.tag == hit.collider.gameObject.tag)
            {
                //Destroy(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Slime>().selected = true;
                return hit.collider.gameObject;
            }
        }*/

        for (int i = 0; i < hit.Length; i++)
        {
            GameObject hitGo = hit[i].collider.gameObject;
            if (hitGo.tag == gameObject.tag)
            {
                hitGo.gameObject.GetComponent<Slime>().selected = true;
                
            }

        }
        return null;
    }

    private List<GameObject> GetAllAdjacentTiles()
    {
        List<GameObject> adjacentTiles = new List<GameObject>();
        for (int i = 0; i < adjacentDirections.Length; i++)
        {
            adjacentTiles.Add(GetAdjacent(adjacentDirections[i]));
        }
        return adjacentTiles;
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        board.damageCheck = true;
        Destroy(gameObject);
    }
}
