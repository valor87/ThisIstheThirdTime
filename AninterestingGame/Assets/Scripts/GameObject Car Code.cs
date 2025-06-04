using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using System;
using UnityEngine.Analytics;
using UnityEditor;
public class GameObjectCarCode : MonoBehaviour
{
    public bool transfer;
    public GameObject SPLINELOOP;
    public GameObject Arrow;
    public GameObject triggercircle;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1) && Arrow.GetComponent<SpriteRenderer>().bounds.Contains(mousepos) && transfer)
        {
            GetComponent<SplineAnimate>().ElapsedTime = 0;
            GetComponent<SplineAnimate>().enabled = true;
            GetComponent<SplineAnimate>().Loop = SplineAnimate.LoopMode.Loop;
            GetComponent<SplineAnimate>().Container = SPLINELOOP.GetComponent<SplineContainer>();
            transfer = false;
        }
        else
        {
            GetComponent<SplineAnimate>().enabled = true;
            GetComponent<SplineAnimate>().Play();
        }

        if (triggercircle.GetComponent<SpriteRenderer>().bounds.Contains(transform.position))
        {
                transfer = true;
        }
    }
   
}
