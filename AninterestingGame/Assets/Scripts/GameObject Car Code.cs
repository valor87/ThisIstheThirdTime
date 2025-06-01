using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using System;
using UnityEngine.Analytics;
public class GameObjectCarCode : MonoBehaviour
{
    float temptime;
    public GameObject SPLINELOOP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(1) && GetComponent<SpriteRenderer>().bounds.Contains(mousepos))
        {
            GetComponent<SplineAnimate>().ElapsedTime += 1f;
            GetComponent<SplineAnimate>().enabled = true;
            GetComponent<SplineAnimate>().Loop = SplineAnimate.LoopMode.Loop;
            GetComponent<SplineAnimate>().Container = SPLINELOOP.GetComponent<SplineContainer>();
        }
        else
        {
            GetComponent<SplineAnimate>().enabled = true;
            GetComponent<SplineAnimate>().Play();
        }

        Debug.Log(Mathf.Round(pos.x * 10f)*0.1f);

        if (new Vector2(Mathf.Round(pos.x * 10f) * 0.1f, Mathf.Round(pos.y * 10f) * 0.1f) == new Vector2(5.5f, -4.5f))
        {
            GetComponent<SplineAnimate>().Pause();
        }
    }
}
