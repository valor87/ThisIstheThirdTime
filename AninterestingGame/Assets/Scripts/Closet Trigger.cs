using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosetTrigger : MonoBehaviour
{
    public GameObject Esther;
    public GameObject ChangeLocations;
    public bool ClosetOpen;
    public Color DampDark;
    public int color;
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && ClosetOpen)
        {
            ChangeLocations.SetActive(true);
            
        }
        if (color == 1 && ChangeLocations.GetComponent<Changingrooms>().changed == true)
        {
            entercloset();
            Debug.Log("ran");
        }
        if (color == 2 && ChangeLocations.GetComponent<Changingrooms>().changed == true)
        {
            leavecloset();
        }


    }
    void leavecloset()
    {
        Esther.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void entercloset()
    {
        Esther.GetComponent<SpriteRenderer>().color = DampDark;
    }
}
