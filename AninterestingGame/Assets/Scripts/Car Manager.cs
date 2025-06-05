using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Splines;
using UnityEngine;
using UnityEngine.Splines;

public class CarManager : MonoBehaviour
{
    int t = 0;
    public int howmanycars;
    public GameObject spline;
    public GameObject splineloop;
    public GameObject PrefabCar;
    public GameObject Arrow;
    public GameObject triggercircle;
    public List<GameObject> CarsonTrack;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawncars());
    }

    // Update is called once per frame
    void Update()
    {
        Arrow.SetActive(true);

        for (int x = 0; x < CarsonTrack.Count; x++)
        {
            if (CarsonTrack[x].GetComponent<GameObjectCarCode>().transfer)
            {
                Arrow.SetActive(true);
            }

        }

    }
    IEnumerator spawncars()
    {
        for (int x = 0; x < howmanycars; x++)
        {
            GameObject tempCar = Instantiate(PrefabCar);
            tempCar.GetComponent<GameObjectCarCode>().Arrow = Arrow;
            tempCar.GetComponent<GameObjectCarCode>().CarManagaer = this.gameObject;
            tempCar.GetComponent<GameObjectCarCode>().triggercircle = triggercircle;
            tempCar.GetComponent<SplineAnimate>().Container = spline.GetComponent<SplineContainer>();
            tempCar.GetComponent<SplineAnimate>().MaxSpeed = 3;
            tempCar.GetComponent<GameObjectCarCode>().SPLINELOOP = splineloop;
            CarsonTrack.Add(tempCar);
            yield return new WaitForSeconds(1f);
        }
    }
   
}
