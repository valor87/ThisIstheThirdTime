using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CarManager : MonoBehaviour
{

    public int howmanycars;
    public GameObject Destination;
    public GameObject spline;
    public GameObject splineloop;
    public GameObject PrefabCar;
    public GameObject Arrow;
    public GameObject triggercircle;
    public List<GameObject> CarsonTrack;
    public List<GameObject> destination;
    public GameObject triggerCircleEnd;

    SpriteRenderer sp;
    bool spawning = false;
    bool mousepress;
    Vector2 mousepos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawncars(howmanycars));
        sp = Arrow.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousepress = Input.GetMouseButtonDown(0);
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position on screen

        for (int co = 0; co < CarsonTrack.Count; co++) // loops throught the game object list
        {
            if (CarsonTrack[co].GetComponent<GameObjectCarCode>().transfer)
            {
                Arrow.SetActive(true);

                if (mousepress && sp.bounds.Contains(mousepos) && CarsonTrack[co].GetComponent<GameObjectCarCode>().transfer == true) // if the car is at the end of the track
                {
                    changecarstrack(CarsonTrack[co]); // change the track
                }
            }
            if (CarReadyForDespawn(CarsonTrack[co])) // if the car is at the end of the second track
            {
                KilltheCar(CarsonTrack[co]); // destroy the car
                spawning = true; // spawns one car at a time
                StartCoroutine(spawncars(1)); // spawn the car
            }


        }

    }

    IEnumerator spawncars(int howmanycars)
    {
        Destination.SetActive(false);
        for (int x = 0; x < howmanycars; x++) // loops for how many cars you want
        {
            GameObject tempCar = Instantiate(PrefabCar); // makes a game object varible for later use

            for (int des = 0; des < destination.Count; des++) // adds the stoping circles to stop the car at predetermined spots
            {
                tempCar.GetComponent<GameObjectCarCode>().Destinations.Add(destination[des]); // give the car prefab its list
            }

            tempCar.GetComponent<GameObjectCarCode>().CarManagaer = this.gameObject; // give the car prefab its car manager
            tempCar.GetComponent<GameObjectCarCode>().triggercircle = triggercircle; // give the car prefab its trigger circle
            tempCar.GetComponent<SplineAnimate>().Container = spline.GetComponent<SplineContainer>(); // give the car prefab its spline container
            tempCar.GetComponent<SplineAnimate>().MaxSpeed = 3; // sets its max speed
            tempCar.GetComponent<GameObjectCarCode>().SPLINELOOP = spline; // set its to loop the spline

            tempCar.GetComponent<SplineAnimate>().Play(); // if its the first object then start with the animation playing

            CarsonTrack.Add(tempCar); // add the car to the list

            spawning = false;
            yield return new WaitForSeconds(.5f); // stop for one second before spawing another car
        }
        Destination.SetActive(true);
    }

    void changecarstrack(GameObject t)
    {
        t.GetComponent<SplineAnimate>().Container = splineloop.GetComponent<SplineContainer>();
        t.GetComponent<SplineAnimate>().Play();
        t.GetComponent<SplineAnimate>().ElapsedTime = 0;
        t.GetComponent<GameObjectCarCode>().transfer = false;
    }

    void KilltheCar(GameObject Bigballs)
    {
        Destroy(Bigballs);
        CarsonTrack.Remove(Bigballs);
    }

    private bool CarReadyForDespawn(GameObject co)
    {
        if (mousepress && triggerCircleEnd.GetComponent<SpriteRenderer>().bounds.Contains(co.transform.position) && co.GetComponent<SpriteRenderer>().bounds.Contains(mousepos)
            && co.GetComponent<GameObjectCarCode>().transfer == false && spawning == false)
        {
            return true;
        }
        return false;
    }

}
