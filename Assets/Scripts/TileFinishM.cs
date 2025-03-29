using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class TileFinishM : MonoBehaviour
{
    [HideInInspector]
    public Vector2 finsihedTilePos;
    [HideInInspector]
    public bool isFinished = false;
    private GameObject acObject;
    private ActionParameter myParameter;
    private GameObject nav;
    void Start()
    {
        finsihedTilePos = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
        nav = GameObject.Find("NavMesh2D");
    }

    void Update()
    {
        acObject = GameObject.Find("SpiegelManager");
        ActionList myActionList = acObject.GetComponent<ActionList>();
        myParameter = myActionList.GetParameter("Spiegelnum");
        if (myParameter.intValue != 0)
        {
            nav.SetActive(false);
        }
        else
        {
            nav.SetActive(true);
        }
    }
}
