using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CabinetObject : MonoBehaviour
{
    public Transform esthertransform;
    public Transform othercloset;
    public List<GameObject> ignoreobject;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey("space") && esthertransform.position == collision.gameObject.transform.position)
        {
         collision.transform.position = othercloset.position - new Vector3(1,0,0);
        }
    }
}
