using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 startPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0)
        {
            startPos = Input.touches[0].position;
            //let's check if the touch is a new touch
            //there are a few different phases that touch moves through
            //check them here: https://docs.unity3d.com/ScriptReference/TouchPhase.html

            //Input.touches[] is an array that stores all touches, the first touch is marked at 0 
            //Has the first touch just started?
            Vector3 pos = Camera.main.ScreenToWorldPoint(startPos);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.tag);

                hit.collider.gameObject.GetComponent<Slime>().selected = true;
            }
        }
    }
}
