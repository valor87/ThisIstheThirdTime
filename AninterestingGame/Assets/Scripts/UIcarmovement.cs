using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIcarmovement : MonoBehaviour
{
    float yspeed;
    float xspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    transform.position += new Vector3(xspeed, yspeed, 0);
        
    }

    public void MoveRight()
    {
       
    }
    public void MoveLeft()
    {

    }
    public void MoveUp()
    {

    }
    public void MoveDown()
    {

    }
}
