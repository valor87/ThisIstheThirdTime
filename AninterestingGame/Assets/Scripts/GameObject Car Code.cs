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
        // making a varible for the spline animator
        splineani = GetComponent<SplineAnimate>();
    }
    // Update is called once per frame
    void Update()
    {
        
        Cars = CarManagaer.GetComponent<CarManager>().CarsonTrack; // giving the list a varible its in update because it needs to add new items to the list
        pos = transform.position; // giving this object trasfrom a varible
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position

        if (Input.GetMouseButtonDown(1) && GetComponent<SpriteRenderer>().bounds.Contains(mousepos)) // if hovering over the car and clicking mouse button
        {
            splineani.Play(); // play animation
            ismoveing = true; // the box is moving
        }
        
    }
    /*
    this code runs when this object hits another collider
    when it hits an object with a box collider the collider gets passed 
    as the Collision2D collision and attached to it is information about the
    game object it came from and other stuff about a ridged body if its attach to the
    game object
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WayPoint") { // using tags because it catgorizes objects in a simple way
            splineani.Pause(); // pause animation
            ismoveing = false; // is no longer moving
        }
        else if(ismoveing == true) // the moving object in the collision
        {
            splineani.ElapsedTime -= 0.1f; // move the object backwards
            splineani.Pause(); // stop its animation
            ismoveing = false; // its no longer moving
        }
    }

}
