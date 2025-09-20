using UnityEngine;

public class CabinetObject : MonoBehaviour
{
    public Transform esthertransform;
    public Transform othercloset;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey("space") && esthertransform.position == collision.gameObject.transform.position)
        {
            collision.transform.position = othercloset.position - new Vector3(0, 1.5f, 0);
        }
       
    }
}
