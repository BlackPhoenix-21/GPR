using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class MoveTileM : MonoBehaviour
{
    private GameObject spiegel;
    private Vector3 finishPos;
    private float floater = 1f;
    private bool moveable = false;
    private int spiegelnum;
    private string spiegelname;
    private GameObject acObject;
    private ActionParameter myParameter;
    private int run = 0;
    void Start()
    {
        acObject = GameObject.Find("SpiegelManager");
        ActionList myActionList = acObject.GetComponent<ActionList>();
        myParameter = myActionList.GetParameter("Spiegelnum");
    }

    void Update()
    {
        if (myParameter.intValue == 0 && run == 0)
        {
            ActionList myActionList = acObject.GetComponent<ActionList>();
            myParameter = myActionList.GetParameter("Spiegelnum");
            if (myParameter.intValue == 0)
            {
                return;
            }
            run++;
        }
        if (run == 1)
        {
            spiegelnum = myParameter.intValue;
            spiegelname = "Spiegel" + spiegelnum;
            spiegel = GameObject.Find(spiegelname);
            finishPos = spiegel.GetComponent<TileFinishM>().finsihedTilePos;
            run++;
        }

        if (gameObject.transform.position.x > finishPos.x - floater && gameObject.transform.position.x < finishPos.x + floater &&
            gameObject.transform.position.y > finishPos.y - floater && gameObject.transform.position.y < finishPos.y + floater)
        {
            gameObject.transform.position = new Vector3(finishPos.x, finishPos.y, -0.02f);
            // Falsche Teil
        }

        if (moveable)
        {
            Move();
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.transform.position == new Vector3(finishPos.x, finishPos.y, -0.02f))
            {
                return;
            }
            if (moveable)
            {
                moveable = false;
            }
            else
            {
                moveable = true;
            }
        }
    }

    void Move()
    {
        gameObject.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -0.02f);
    }
}
