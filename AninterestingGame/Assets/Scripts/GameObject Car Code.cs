using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class GameObjectCarCode : MonoBehaviour
{
    public GameObject SPLINELOOP;
    public GameObject triggercircle;
    public GameObject CarManagaer;

    public List<GameObject> Destinations;

    public bool transfer;
    public bool ismoveing = true;
    Vector2 pos;

    SplineAnimate splineani;
    SpriteRenderer sp;
    private void Start()
    {
        // making a varible for the spline animator
        splineani = GetComponent<SplineAnimate>();
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {

        pos = transform.position; // giving this object trasfrom a varible
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position
        if (sp.bounds.Contains(triggercircle.transform.position))
        {
            transfer = true;
        }
        if (Input.GetMouseButtonDown(1) && sp.bounds.Contains(mousepos)) // if hovering over the car and clicking mouse button
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
        if (splineani != null)
        {
            if (collision.gameObject.tag == "WayPoint")
            { // using tags because it catgorizes objects in a simple way

                splineani.Pause(); // pause animation
                ismoveing = false; // is no longer moving
            }
            else if (ismoveing == true) // the moving object in the collision
            {
                splineani.ElapsedTime -= 0.1f; // move the object backwards
                splineani.Pause(); // stop its animation
                ismoveing = false; // its no longer moving
            }
        }
    }

}
