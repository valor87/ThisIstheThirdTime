using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
   
    void Update()
    {
        transform.position += new Vector3(1,0,0) * Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
        transform.position += new Vector3(0, 1, 0) * Input.GetAxis("Vertical") * 5 * Time.deltaTime;
    }
}
