using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.Splines;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CarManager : MonoBehaviour
{

    public int howmanycars;
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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawncars(howmanycars));
        sp = Arrow.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        for (int co = 0; co < CarsonTrack.Count; co++)
        {
            if (CarsonTrack[co].GetComponent<GameObjectCarCode>().transfer)
            {
                Arrow.SetActive(true);

                if (Input.GetMouseButtonDown(1) && sp.bounds.Contains(mousepos) && CarsonTrack[co].GetComponent<GameObjectCarCode>().transfer == true)
                {
                    changecarstrack(CarsonTrack[co]);
                }
            }
            if (Input.GetMouseButtonDown(1) && triggerCircleEnd.GetComponent<SpriteRenderer>().bounds.Contains(CarsonTrack[co].transform.position) && CarsonTrack[co].GetComponent<GameObjectCarCode>().transfer == false && spawning == false)
            {
                KilltheCar(CarsonTrack[co]);
                spawning = true;
                StartCoroutine(spawncars(1));
                Debug.Log("Working");
            }


        }
       
    }


    IEnumerator spawncars(int howmanycars)
    {
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

            switch (x)
            {
                case 0:
                    tempCar.GetComponent<SplineAnimate>().Play(); // if its the first object then start with the animation playing
                    break;
                default:
                    tempCar.GetComponent<SplineAnimate>().Pause(); // else dont play the animation
                    break;
            }

            CarsonTrack.Add(tempCar); // add the car to the list

            spawning = false;
            yield return new WaitForSeconds(1f); // stop for one second before spawing another car
        }
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
}
