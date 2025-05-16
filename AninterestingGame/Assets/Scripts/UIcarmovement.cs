using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIcarmovement : MonoBehaviour
{
    float yspeed;
    float xspeed;

    float tempy;
    float tempx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xspeed += tempx;
        yspeed += tempy;
    transform.position += new Vector3(xspeed, yspeed, 0);
        
    }

    public void MoveRight()
    {
        tempx += 0.001f;
    }
    public void MoveLeft()
    {
        tempx -= 0.001f;
    }
    public void MoveUp()
    {
        tempy += 0.001f;
    }
    public void MoveDown()
    {
        tempy -= 0.001f;
    }
    public void Break()
    {
        tempy = 0;
        tempx = 0;
        xspeed = 0;
        yspeed = 0;
    }
}
