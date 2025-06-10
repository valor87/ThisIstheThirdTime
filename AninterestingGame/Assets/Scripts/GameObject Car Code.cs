using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class GameObjectCarCode : MonoBehaviour
{
    public GameObject SPLINELOOP;
    public GameObject Arrow;
    public GameObject triggercircle;
    public GameObject CarManagaer;

    public List<GameObject> Cars;
    public List<GameObject> Destinations;

    bool ismoveing = true;
    Vector2 pos;

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

        if (Input.GetMouseButtonDown(1) && GetComponent<SpriteRenderer>().bounds.Contains(mousepos))
        {
            splineani.Play();
            ismoveing = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WayPoint") {
            splineani.Pause();
            ismoveing = false;
            Debug.Log("The tags are working");
        }
        else if(ismoveing == true)
        {
            splineani.ElapsedTime -= 0.1f;
            splineani.Pause();
            ismoveing = false;
        }
    }

}
