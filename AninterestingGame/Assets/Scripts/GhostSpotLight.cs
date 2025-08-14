using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GhostSpotLight : MonoBehaviour
{
    public GameObject Manager;
    public float visionmeter;
    public bool adding;

    private void Start()
    {
         
    }
    private void Update()
    {
       
        if (Manager.GetComponent<GhostVisonManager>().visionmetermanager > 0 && !Manager.GetComponent<GhostVisonManager>().adding)
        {
            Manager.GetComponent<GhostVisonManager>().visionmetermanager -= 5 * Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Manager.GetComponent<GhostVisonManager>().adding = true;
        Debug.Log("staying collision");

        Manager.GetComponent<GhostVisonManager>().visionmetermanager += 5 * Time.deltaTime;
        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Manager.GetComponent<GhostVisonManager>().adding = false;
    }
   
}
