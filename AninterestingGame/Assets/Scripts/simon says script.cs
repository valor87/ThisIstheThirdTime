using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
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
    public List<Sprite> lights;
    public List<GameObject> progressbulbs;

    public Color activebulb;
    public Color inactivebulb;
    

    public List<GameObject> NewCode;
    public List<GameObject> PlayersCode;

    public GameObject canvus;
    public GameObject text;
    public int howmanytimes;

    int CorrectCodes;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < progressbulbs.Count; i++)
        {
            progressbulbs[i].GetComponent<Image>().color = inactivebulb; // sets the progression bulbs to the amount of right answears
        }
        StartCoroutine(PickCode()); // starts the code thats picked by random
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < CorrectCodes; i++)
        {
            progressbulbs[i].GetComponent<Image>().color = activebulb;
        }
        if (CorrectCodes == 4)
        {
            // win condition code goes here
        }
        if (Lists(NewCode.Count)) // if the function list is true
        {
            text.SetActive(true); // turn on text
        }

        if (!Lists(NewCode.Count) && PlayersCode.Count == NewCode.Count) // if the code was wrong
        {
            ResetValues(); // resets all lists 
        }
        if (Lists(NewCode.Count) && PlayersCode.Count == NewCode.Count) // if the code was wrong
        {
            howmanytimes++;
            CorrectCodes++;
            ResetValues(); // resets all lists 
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
        ResetValues(); // resets all lists
    }
    private void ResetValues()
    {
        text.SetActive(false);
        NewCode.Clear(); // clear the given code
        PlayersCode.Clear(); // clear player code
        StartCoroutine(PickCode()); // restart the pick code corutine
    }
    public void ExitGame()
    {
        canvus.SetActive(false); // turns off the canvus
    }
    IEnumerator PickCode()
    {
        redlight.GetComponent<Image>().sprite = lights[1]; // makes the red button slightly transparent
        yellowlight.GetComponent<Image>().sprite = lights[2]; // makes the yellow button slightly transparent
        bluelight.GetComponent<Image>().sprite = lights[0]; // makes the blue button slightly transparent

        for (int x = 0; x < howmanytimes; x++)
        {
            redbutton.GetComponent<Button>().enabled = false; // stop input to the buttons
            bluebutton.GetComponent<Button>().enabled = false; // stop input to the buttons
            yellowbutton.GetComponent<Button>().enabled = false; // stop input to the buttons

            int _temp = Random.Range(1, 4); // picks a random number from 1 to 3
            if (_temp == 1) 
            {
                redlight.GetComponent<Image>().sprite = lights[4]; // show red as bright or lit
                NewCode.Add(redlight); // add it to the made up code
            }
            else if (_temp == 2)
            {
                bluelight.GetComponent<Image>().sprite = lights[3]; // show blue as bright or lit
                NewCode.Add(bluelight); // add it to the made up code
            }
            else if (_temp == 3)
            {
                yellowlight.GetComponent<Image>().sprite = lights[5]; // show yellow as bright or lit
                NewCode.Add(yellowlight); // add it to the made up code
            }
            yield return new WaitForSeconds(1); // stop the corutine for one second
            redlight.GetComponent<Image>().sprite = lights[1]; // makes the red button slightly transparent
            yellowlight.GetComponent<Image>().sprite = lights[2]; // makes the yellow button slightly transparent
            bluelight.GetComponent<Image>().sprite = lights[0]; // makes the blue button slightly transparent
            if (x != howmanytimes) {
                yield return new WaitForSeconds(.5f); // wait half a second
            }
        }
        redbutton.GetComponent<Button>().enabled = true; // gives input back to the buttons
        bluebutton.GetComponent<Button>().enabled = true; // gives input back to the buttons
        yellowbutton.GetComponent<Button>().enabled = true; // gives input back to the buttons
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
