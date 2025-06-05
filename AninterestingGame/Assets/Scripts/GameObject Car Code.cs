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
    public GameObject CarManagaer;

    public List<GameObject> Cars;
    public List<Vector2> Destinations;

    Vector2 pos;
    float cartime;
    
    // Update is called once per frame
    void Update()
    {
        
        cartime = GetComponent<SplineAnimate>().ElapsedTime;
        Cars = CarManagaer.GetComponent<CarManager>().CarsonTrack;
         pos = transform.position;
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        TimetoStopAreas();
        
        if (Input.GetMouseButton(1) && GetComponent<SpriteRenderer>().bounds.Contains(mousepos))
        {
            GetComponent<SplineAnimate>().Play();
            cartime = 0;
            GetComponent<SplineAnimate>().enabled = true;
            GetComponent<SplineAnimate>().Loop = SplineAnimate.LoopMode.Loop;
            GetComponent<SplineAnimate>().Container = SPLINELOOP.GetComponent<SplineContainer>();
            transfer = false;
        }
        else
        {
            GetComponent<SplineAnimate>().enabled = true;
           // GetComponent<SplineAnimate>().Play();
        }
        if (triggercircle.GetComponent<SpriteRenderer>().bounds.Contains(transform.position))
        {
            transfer = true;
        }
        carcollision();
    }

    public void TimetoStopAreas()
    {
        pos.x = Mathf.Round((pos.x * 10)) * 0.1f;
        pos.y = Mathf.Round((pos.y * 10)) * 0.1f;
        if (Input.GetKey("space"))
        {
            Debug.Log(pos);
        }
        for (int cime = 0; cime<Destinations.Count; cime++) {
            if (pos == Destinations[cime])
            {
                Debug.Log(cartime);
                GetComponent<SplineAnimate>().Pause();
            }
        }
    }
    private void carcollision()
    {
        for (int x = 0; x < Cars.Count; x++)
        {

            if (Cars[x] != this.gameObject)
            {
                
            }
        }
    }
}
