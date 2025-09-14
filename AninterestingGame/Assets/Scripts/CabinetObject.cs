using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CabinetObject : MonoBehaviour
{
    public Transform othercloset;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Triggering");

        if (Input.GetKeyDown("space"))
        {
            if (othercloset != null ) {
                collision.transform.position = othercloset.position;
            }
        }
    }
}
