using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using System;
using UnityEngine.Analytics;
using UnityEditor;
using UnityEditor.Splines;
public class GameObjectCarCode : MonoBehaviour
{
    public bool transfer;
    public GameObject SPLINELOOP;
    public GameObject Arrow;
    public GameObject triggercircle;
    public GameObject CarManagaer;

    public List<GameObject> Cars;
    public List<GameObject> Destinations;

    Vector2 pos;
    float cartime;

    SplineAnimate splineani;

    private void Start()
    {
        splineani = GetComponent<SplineAnimate>();
    }
    // Update is called once per frame
    void Update()
    {
        
        Cars = CarManagaer.GetComponent<CarManager>().CarsonTrack;
         pos = transform.position;
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        TimetoStopAreas();
      
        if (Input.GetMouseButton(1) && GetComponent<SpriteRenderer>().bounds.Contains(mousepos))
        {
            splineani.Play();
            Debug.Log("click");
            splineani.enabled = true;
            //splineani.Loop = SplineAnimate.LoopMode.Loop;
           // splineani.Container = SPLINELOOP.GetComponent<SplineContainer>();
           // transfer = false;
        }
        else
        {
            GetComponent<SplineAnimate>().enabled = true;
            //GetComponent<SplineAnimate>().Play();
        }
        if (triggercircle.GetComponent<SpriteRenderer>().bounds.Contains(transform.position))
        {
            transfer = true;
        }
        carcollision();
    }

    public void TimetoStopAreas()
    {
        for (int cime = 0; cime<Destinations.Count; cime++) {
            if (Destinations[cime].GetComponent<SpriteRenderer>().bounds.Contains(pos))
            {
                splineani.Pause();
            }
        }
    }
    private void carcollision()
    {
        for (int x = 0; x < Cars.Count; x++)
        {

        }
    }
}
