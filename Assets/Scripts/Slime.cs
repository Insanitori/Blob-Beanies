using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update

    public bool selected;

    private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right, Vector2.up };
    void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        Destroy(gameObject);
    }
}
