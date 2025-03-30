using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class TileFinishM : MonoBehaviour
{
    [HideInInspector]
    public Vector2 finsihedTilePos;
    [HideInInspector]
    public bool isFinished = false;
    private GameObject acObject;
    private ActionParameter myParameter;
    private bool added = false;
    void Start()
    {
        finsihedTilePos = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
    }

    void Update()
    {
        acObject = GameObject.Find("SpiegelManager");
        ActionList myActionList = acObject.GetComponent<ActionList>();
        myParameter = myActionList.GetParameter("Spiegelnum");
        if (myParameter.intValue != 0)
        {
            //Debug.Log("SpiegelNum: " + myParameter.intValue);
        }
        else
        {
            //Debug.Log("SpiegelNum: 0");
        }

        if (isFinished && !added)
        {
            StartCoroutine(FinishedM());
            added = true;
        }
    }
    IEnumerator FinishedM()
    {
        yield return new WaitForSeconds(0.75f);
        GameObject.Find("Exit: Use").GetComponent<ActionList>().RunFromIndex(0);
        GameObject.Find("SpiegelMe").GetComponent<ActionList>().GetParameter("SpiegelAnzahl").intValue += 1;
        GameObject.Find("SpiegelMe").GetComponent<ActionList>().RunFromIndex(0);
    }
}
