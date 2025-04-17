using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.position += Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        }
        }
}
