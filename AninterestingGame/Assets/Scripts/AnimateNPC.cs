using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateNPC : MonoBehaviour
{
    public int timer;
    public Vector3 movepos;
    public GameObject Esther;
    public GameObject NPCwithAnimation;
    public GameObject textcanvus;
    public float timetowaitforanimation;
    public int animationtochangeto;
    bool running; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!running && textcanvus.GetComponent<showonscreentext>().texton)
        {
            StartCoroutine(Animate());
        }
    }

    IEnumerator Animate()
    {
        
        NPCwithAnimation.GetComponent<BoxCollider2D>().enabled = false;
        running = true;
        while (textcanvus.GetComponent<showonscreentext>().texton)
        {
            NPCwithAnimation.GetComponent<AstraeaScript>().animationnum = animationtochangeto;
            yield return null;
           
        }
        running = false;
        
        int move = 0;
        while (move < timer)
        {
            move++;
            Esther.GetComponent<PlayerMovement>().canMove = false;
            NPCwithAnimation.GetComponent<AstraeaScript>().animationnum = 2;
            Vector2 temppos = NPCwithAnimation.transform.position;
            temppos.x -= 0.01f;
            NPCwithAnimation.transform.position = temppos;
            yield return null;
        }
        NPCwithAnimation.transform.position = new Vector2(100,100);
        Esther.GetComponent<PlayerMovement>().canMove = true;
    }
}
