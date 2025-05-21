using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrackedWallScript : MonoBehaviour
{
    public UnityEvent TextANDTeleport;
    public GameObject Player;
   public 
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().bounds.Contains(Player.transform.position) && Input.GetKeyDown("space"))
        {
            TextANDTeleport.Invoke();
        }
       
    }
    public void Teleport()
    { 
        if(Player.GetComponent<PlayerMovement>().canMove)
        Player.transform.position = new Vector3(-4.62f,-0.68f,0);
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
}
