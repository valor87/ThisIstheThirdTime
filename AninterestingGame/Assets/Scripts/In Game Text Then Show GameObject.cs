using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InGameTextThenShowGameObject : MonoBehaviour
{
    public GameObject Esther;
    public GameObject TextCanvus;
    public TextAsset Text;
    public GameObject ObjectToShow;
    public GameObject YesBox;
    public GameObject NoBox;
    public GameObject Yestext;
    public GameObject Notext;
    public GameObject BackBox;
    bool texthasbeenshown = false;
    bool make = false;
    public bool overlayon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (texthasbeenshown && TextCanvus.GetComponent<showonscreentext>().texton == false )
        {
            Debug.Log("text is done");
            texthasbeenshown = false;
            StartCoroutine(makeachoice());
        }
       
        if (!make)
        {
            if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space")
                && TextCanvus.GetComponent<showonscreentext>().texton == false && !overlayon)
            {
                TextCanvus.GetComponent<showonscreentext>().textasset = Text;
                TextCanvus.GetComponent<showonscreentext>().startText();
                texthasbeenshown = true;
            }
        }
      
    }

    IEnumerator makeachoice()
    {
        TextCanvus.SetActive(true); // show the object
        //TextCanvus.GetComponent<showonscreentext>().textasset = null;
        bool yestrue = false;
        make = true;
        Yestext.SetActive(true);
        Notext.SetActive(true);
        BackBox.SetActive(true);
        Esther.GetComponent<PlayerMovement>().canMove = false;
        while (make){
            if (Input.GetKey("a"))
            {
                YesBox.SetActive(true);
                NoBox.SetActive(false);
                yestrue = true;

            }
            if (Input.GetKey("d"))
            {
                NoBox.SetActive(true);
                YesBox.SetActive(false);
                yestrue = false;
            }
            if (Input.GetKey("space") && yestrue)
            {
                ObjectToShow.SetActive(true); // show the object
                YesBox.SetActive(false);
                make = false;
            }
            else if (Input.GetKey("space") && !yestrue)
            {
                NoBox.SetActive(false);
                make = false;
            }
                yield return null;
        }
        Yestext.SetActive(false);
        Notext.SetActive(false);
        BackBox.SetActive(false);
        Esther.GetComponent<PlayerMovement>().canMove = true;

    }
}
