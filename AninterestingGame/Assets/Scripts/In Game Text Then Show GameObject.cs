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
    bool texthasbeenshown = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Esther.transform.position) && Input.GetKeyDown("space")
            && TextCanvus.GetComponent<showonscreentext>().texton == false)
        {
            TextCanvus.GetComponent<showonscreentext>().textasset = Text;
            TextCanvus.GetComponent<showonscreentext>().startText();
            ObjectToShow.SetActive(true); // show the object
            texthasbeenshown = true;


         
        }
        if (texthasbeenshown && TextCanvus.GetComponent<showonscreentext>().texton == false)
        {
            Debug.Log("text is done");
            texthasbeenshown = false;
            StartCoroutine(makeachoice());
        }
    }

    IEnumerator makeachoice()
    {
        TextCanvus.SetActive(true); // show the object
        //TextCanvus.GetComponent<showonscreentext>().textasset = null;
        bool make = true;
        Yestext.SetActive(true);
        Notext.SetActive(true);
        while (make){
            if (Input.GetKey("a"))
            {
                YesBox.SetActive(true);
                NoBox.SetActive(false);

            }
            if (Input.GetKey("d"))
            {
                NoBox.SetActive(true);
                YesBox.SetActive(false);

            }
            yield return null;
        }
        Yestext.SetActive(false);
        Notext.SetActive(false);
    }
}
