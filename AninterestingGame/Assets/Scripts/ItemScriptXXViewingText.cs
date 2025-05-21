using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemScriptXXViewingText : MonoBehaviour
{
    public GameObject MainPlayer;

    public GameObject dialaugeCanvus;
    public GameObject ConIcon;
    public TextMeshProUGUI text;
    public TextAsset textasset;
    public string[] dialauge;
    public float textSpeed = 0.03f;
    bool showtext = true;
    bool continueText;
    public bool TP;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
   public void ShowText()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(MainPlayer.transform.position) && showtext) 
        {
            showtext = false; // stops the text from being activated more then once
            dialaugeCanvus.SetActive(true); // turns on the canvus
            dialauge = (textasset.text.Split('\n')); // splits the entire text doc by when ever the enter button is pressed
            
            StartCoroutine(slowtext()); // starts the coroutine
        }
    
    }

    IEnumerator slowtext()
    {
        MainPlayer.GetComponent<PlayerMovement>().canMove = false; // stops the player from moving
        ConIcon.SetActive(false);

        for (int i = 0; i < dialauge.Count(); i++)
        {
            //textSpeed = 0.05f; // Resets the text speed if the player changed it
            string currenttext = dialauge[i]; // sets the line of the txt file

            for (int c = 0; c < currenttext.Length; c++)
            {
                text.text += currenttext[c]; // breaks the line into numbered letters so they can be displayed one by one
                yield return new WaitForSeconds(textSpeed); // waits based on the text speed
            }

            continueText = true; // starts the while loop
            while (continueText)
            {
                ConIcon.SetActive(true); // turns on ui that tells the player the text is done
                if (Input.GetKey("space"))
                {
                    continueText = false; // stops while loop
                }
                yield return null;
            }
            ConIcon.SetActive(false); // turns off the ui

            text.text = string.Empty; // at the end of all the lines it sets the text box to empty
        }
        dialaugeCanvus.SetActive(false);// turns off the canvus
        yield return null;

        showtext = true; // the text can be displayed again 
        MainPlayer.GetComponent<PlayerMovement>().canMove = true; // Stop the player from moving
        if (TP)
        {
            GetComponent<CrackedWallScript>().Teleport();
        }
    }

}
