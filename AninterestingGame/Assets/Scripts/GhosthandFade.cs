using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhosthandFade : MonoBehaviour
{
    public GameObject ghosttriangle;
    float fade;
    SpriteRenderer sp;
    Animator anitor;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        anitor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fade = ghosttriangle.GetComponent<GhostVisonManager>().visionmetermanager/25;
        sp.color = new Color(255, 255, 255, fade);
        if (ghosttriangle.GetComponent<GhostVisonManager>().visionmetermanager >= 12)
        {
            anitor.speed = 2;
            anitor.SetBool("Secondhalf", true);
            anitor.SetBool("Trigger", false);
        }
        else
        {
            anitor.speed = 1;
            anitor.SetBool("Secondhalf", false);
            anitor.SetBool("Trigger", true);
        }
    }
}
