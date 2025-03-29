using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class LevelCheck : MonoBehaviour
{
    void Start()
    {
        GetComponent<Interaction>().RunFromIndex(4);
        if (GlobalVariables.GetBooleanValue(4))
        {
            GetComponent<Interaction>().RunFromIndex(0);
        }
    }

}
