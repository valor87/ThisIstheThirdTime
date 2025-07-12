using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class showonscreentext : MonoBehaviour
{
    public GameObject Esther;
    public GameObject triggerArea;
    public GameObject Triggerbox;
    public GameObject ObjectToShow;
    GameObject Image;
    GameObject conIcon;
    GameObject Textobject;
    GameObject Yestext;
    GameObject Notext;
    GameObject Yesbox;
    GameObject Nobox;
    TextMeshProUGUI text;
    SpriteRenderer sp;
    public TextAsset textasset;
    public string[] dialauge;
    public float textSpeed = 0.05f;
    bool continueText;
    public bool texton;
    bool make;
    bool texthasbeenshown;
    public bool overlayon;
    public bool playerchoice;
    private void Start()
    {
        sp = triggerArea.GetComponent<SpriteRenderer>();
        Transform imagetr = transform.GetChild(0);
        Image = imagetr.gameObject;
        Transform texttr = transform.GetChild(1);
        Textobject = texttr.gameObject;
        text = Textobject.GetComponent<TextMeshProUGUI>();
        Transform contr = transform.GetChild(2);
        conIcon = contr.gameObject;
        Transform noboxtr = transform.GetChild(3);
        Nobox = noboxtr.gameObject;
        Transform yesboxtr = transform.GetChild(4);
        Yesbox = yesboxtr.gameObject;
        Transform yestexttr = transform.GetChild(5);
        Yestext = yestexttr.gameObject;
        Transform notexttr = transform.GetChild(6);
        Notext = notexttr.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && texton == false && sp.bounds.Contains(Esther.transform.position) && !overlayon)
        {
            startText();
        }
    }
    public void startText()
    {
        Esther.GetComponent<PlayerMovement>().PA.SetFloat("Directionx", 0); Esther.GetComponent<PlayerMovement>().PA.SetFloat("Directiony", 0); ;
        dialauge = (textasset.text.Split('\n')); // splits the entire text doc by when ever the enter button is pressed
        StartCoroutine(slowtext()); // starts the coroutine
    }
    IEnumerator slowtext()
    {

        texton = true;
        turnOnUi(); // turns on the canvus
        stopEsther(); // stops the player from moving
        for (int i = 0; i < dialauge.Count(); i++)
        {

            string currenttext = dialauge[i]; // sets the line of the txt file

            for (int c = 0; c < currenttext.Length; c++)
            {
                text.text += currenttext[c]; // breaks the line into numbered letters so they can be displayed one by one
                yield return new WaitForSeconds(textSpeed); // waits based on the text speed
            }

            yield return new WaitForSeconds(1);

            continueText = true;

            while (continueText)
            {

                if (Input.GetKey("w"))
                {
                    continueText = false;
                    text.text = string.Empty; // at the end of all the lines it sets the text box to empty
                }
                yield return null;
            }
            text.text = string.Empty; // at the end of all the lines it sets the text box to empty
        }
        turnOffUi();// turns off the canvus
        if (playerchoice) {
            bool yestrue = false;
            make = true;
            Yestext.SetActive(true);
            Notext.SetActive(true);
            Image.SetActive(true);
            Esther.GetComponent<PlayerMovement>().canMove = false;
            while (make)
            {
                if (Input.GetKey("a"))
                {
                    Yesbox.SetActive(true);
                    Nobox.SetActive(false);
                    yestrue = true;
                }
                if (Input.GetKey("d"))
                {
                    Nobox.SetActive(true);
                    Yesbox.SetActive(false);
                    yestrue = false;
                    

                }
                if (Input.GetKey("space") && yestrue)
                {
                    Yesbox.SetActive(false);
                    make = false;
                    Debug.Log("Yes was slected");
                    ObjectToShow.SetActive(true);

                }
                else if (Input.GetKey("space") && !yestrue)
                {
                    Nobox.SetActive(false);
                    make = false;
                    Debug.Log("No was slected");
                }
                yield return null;
            }
        }
        Yestext.SetActive(false);
        Notext.SetActive(false);
        turnOffUi();// turns off the canvus
        texton = false;
        yield return null;

    }

    private void turnOnUi()
    {
        Esther.GetComponent<PlayerMovement>().canMove = false;
        Image.SetActive(true);
        Textobject.SetActive(true);
        conIcon.SetActive(true);
    }
    private void turnOffUi()
    {
        Esther.GetComponent<PlayerMovement>().canMove = true;
        Image.SetActive(false);
        Textobject.SetActive(false);
        conIcon.SetActive(false);
    }
    private void stopEsther()
    {

        Esther.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    IEnumerator makeachoice()
    {
        //TextCanvus.GetComponent<showonscreentext>().textasset = null;
        bool yestrue = false;
        make = true;
        Yestext.SetActive(true);
        Notext.SetActive(true);
        Image.SetActive(true);
        Esther.GetComponent<PlayerMovement>().canMove = false;
        while (make)
        {
            if (Input.GetKey("a"))
            {
                Yesbox.SetActive(true);
                Nobox.SetActive(false);
                yestrue = true;

            }
            if (Input.GetKey("d"))
            {
                Nobox.SetActive(true);
                Yesbox.SetActive(false);
                yestrue = false;
            }
            if (Input.GetKey("space") && yestrue)
            {
                Yesbox.SetActive(false);
                make = false;
            }
            else if (Input.GetKey("space") && !yestrue)
            {
                Nobox.SetActive(false);
                make = false;
            }
            yield return null;
        }
        Yestext.SetActive(false);
        Notext.SetActive(false);
        Image.SetActive(false);
        Esther.GetComponent<PlayerMovement>().canMove = true;

    }
}
