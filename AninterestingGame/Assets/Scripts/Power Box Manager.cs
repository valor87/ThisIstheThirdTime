using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxManager : MonoBehaviour
{
    public GameObject PuzzleOne;
    public GameObject PuzzleTwo;
    public GameObject PuzzleThree;

    public bool boxeonecompleted;
    public bool boxetwocompleted;
    public bool boxethreecompleted;

    // Update is called once per frame
    void Update()
    {
        if (PuzzleOne != null && PuzzleOne.GetComponent<Neeble>().puzzledone)
        {
            boxeonecompleted = true;
        }
        if (PuzzleTwo != null && PuzzleTwo.GetComponent<Neeble>().puzzledone)
        {
            boxetwocompleted = true;
        }
        if (PuzzleThree != null && PuzzleThree.GetComponent<Neeble>().puzzledone)
        {
            boxethreecompleted = true;
        }

        if (boxeonecompleted && boxetwocompleted && boxethreecompleted)
        {

        }
    }
}
