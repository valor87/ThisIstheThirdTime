using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGhostAnimation : MonoBehaviour
{
    public string ani;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool(ani,true);
    }

 
}
