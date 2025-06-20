using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class AstraeaScript : MonoBehaviour
{
    public int animationnum;
    string temp;
    Animator an;
    public List<string> names;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();

    }

    /*
     Id lft
     wk lft
     wk up
     id up
     id rgh
     wk rgh
     id dwn
     wk dwn
     */

    // Update is called once per frame
    void Update()
    {
        switch (animationnum)
        {

            case 1:
                temp = names[0];
                break;
            case 2:
                temp = names[1];
                break;
            case 3:
                temp = names[2];
                break;
            case 4:
                temp = names[3];
                break;
            case 5:
                temp = names[4];
                break;
            case 6:
                temp = names[5];
                break;
            case 7:
                temp = names[6];
                break;
            case 8:
                temp = names[7];
                break;
        }
        
        an.SetBool(temp, true);
        for (int i = 0; i < names.Count(); i++)
        {
            if (names[i] != temp)
            {
                an.SetBool(names[i], false);
            }
        }

    }
}
