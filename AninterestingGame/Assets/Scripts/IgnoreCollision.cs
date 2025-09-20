using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    [SerializeField] Vector3 changevalue;
    [SerializeField] List<GameObject> closets;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3 temp = collision.transform.position;
        if(collision.gameObject == closets[0] || collision.gameObject == closets[1])
        {
            collision.gameObject.transform.position += changevalue;
        }
    }
}
