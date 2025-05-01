using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class simonsaysscript : MonoBehaviour
{
    public GameObject redbutton;
    public GameObject yellowbutton;
    public GameObject bluebutton;

    public GameObject redlight;
    public GameObject yellowlight;
    public GameObject bluelight;

    public Color trasparentred;
    public Color trasparentblue;
    public Color trasparentyellow;

    public List<GameObject> NewCode;
    public List<GameObject> PlayersCode;

    public GameObject text;
    public int howmanytimes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PickCode()); // starts the code thats picked by random
    }

    // Update is called once per frame
    void Update()
    {
        if (Lists(NewCode.Count)) // if the function list is true
        {
            text.SetActive(true); // turn on text
        }

        if (!Lists(NewCode.Count) && PlayersCode.Count == NewCode.Count) // if the code was wrong
        {
            ResetValues();
        }
    }

    public void RedButtonPressed() // if red button is pressed
    {
        PlayersCode.Add(redlight); // add the red light to the list
    }
    public void BlueButtonPressed() // if blue button is pressed
    {
        PlayersCode.Add(bluelight); // add the blue light to the list
    }
    public void YellowButtonPressed() // if yellow button is pressed
    {
        PlayersCode.Add(yellowlight); // add the yellow light to the list
    }

    public void ResetTheCode()
    {
        ResetValues();
    }
    private void ResetValues()
    {
        text.SetActive(false);
        NewCode.Clear(); // clear the given code
        PlayersCode.Clear(); // clear player code
        StartCoroutine(PickCode()); // restart the pick code corutine
    }
    IEnumerator PickCode()
    {
        redlight.GetComponent<Image>().color = trasparentred; // makes the red button slightly transparent
        yellowlight.GetComponent<Image>().color = trasparentyellow; // makes the yellow button slightly transparent
        bluelight.GetComponent<Image>().color = trasparentblue; // makes the blue button slightly transparent

        for (int x = 0; x < howmanytimes; x++)
        {
            int _temp = Random.Range(1, 4); // picks a random number from 1 to 3
            if (_temp == 1) 
            {
                redlight.GetComponent<Image>().color = Color.red; // show red as bright or lit
                NewCode.Add(redlight); // add it to the made up code
            }
            else if (_temp == 2)
            {
                bluelight.GetComponent<Image>().color = Color.blue; // show blue as bright or lit
                NewCode.Add(bluelight); // add it to the made up code
            }
            else if (_temp == 3)
            {
                yellowlight.GetComponent<Image>().color = Color.yellow; // show yellow as bright or lit
                NewCode.Add(yellowlight); // add it to the made up code
            }
            yield return new WaitForSeconds(1); // stop the corutine for one second
            redlight.GetComponent<Image>().color = trasparentred; // reset red light
            yellowlight.GetComponent<Image>().color = trasparentyellow; // reset yellow light
            bluelight.GetComponent<Image>().color = trasparentblue; // reset blue light
            yield return new WaitForSeconds(.5f); // wait half a second
        }
       
    }

    public bool Lists(int numofcode)
    {
        int correct = 0; // used for the compairing of the lists
        if (PlayersCode.Count == numofcode) { // if the players code has the same amount as the code list
            for (int i = 0; i < NewCode.Count; i++)
            {
                if (NewCode[i] == PlayersCode[i]) // if the game objects are matching
                {
                    correct++; // increase the correct answear
                    if (correct == numofcode) { // if all the answears were correct
                        return true; // Lists is now true
                    }
                }
                else
                {
                    return false; // Lists is now false
                }
            }
        }
        return false; // Lists is now false
    }
}
