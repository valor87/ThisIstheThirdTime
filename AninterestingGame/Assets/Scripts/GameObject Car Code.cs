using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class GameObjectCarCode : MonoBehaviour
{
    float temptime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // Debug.Log(mousepos);
        if (Input.GetMouseButton(1) && GetComponent<SpriteRenderer>().bounds.Contains(mousepos))
        {
            GetComponent<SplineAnimate>().enabled = false;
            transform.position = mousepos;

        }
        else
        {
            GetComponent<SplineAnimate>().enabled = true;
            GetComponent<SplineAnimate>().Play();
           // GetComponent<SplineAnimate>().MaxSpeed = 5f;
        }
    }
}
