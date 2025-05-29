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
        
        if (Input.GetKey("space"))
        {
            //GetComponent<SplineAnimate>().Pause();
           // GetComponent<SplineAnimate>().MaxSpeed = -5;

        }
        else
        {
            GetComponent<SplineAnimate>().Play();
           // GetComponent<SplineAnimate>().MaxSpeed = 5f;
        }
    }
}
