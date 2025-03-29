using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class MoveTileM : MonoBehaviour
{
    private GameObject spiegel;
    private Vector3 finishPos;
    private float floater = 0.3f;
    private bool moveable = false;
    private int spiegelnum;
    private string spiegelname;
    private GameObject acObject;
    private ActionParameter myParameter;
    private int run = 0;
    private int nameint;
    Vector2 startPos;
    bool finsihed = false;
    void Start()
    {
        acObject = GameObject.Find("SpiegelManager");
        ActionList myActionList = acObject.GetComponent<ActionList>();
        myParameter = myActionList.GetParameter("Spiegelnum");
        nameint = int.Parse(gameObject.GetComponent<SpriteRenderer>().sprite.name.Substring(1));
        startPos = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
    }

    void Update()
    {
        if (run == 2)
        {
            finsihed = spiegel.GetComponent<TileFinishM>().isFinished;
        }
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
        if (myParameter.intValue == 1 && run != 2)
        {
            spiegelnum = myParameter.intValue;
            spiegelname = "Spiegel" + spiegelnum;
            spiegel = GameObject.Find(spiegelname);
            finishPos = spiegel.GetComponent<TileFinishM>().finsihedTilePos;
            run++;
            run++;
        }

        if (gameObject.transform.position.x > finishPos.x - floater && gameObject.transform.position.x < finishPos.x + floater &&
            gameObject.transform.position.y > finishPos.y - floater && gameObject.transform.position.y < finishPos.y + floater)
        {
            gameObject.transform.position = new Vector3(finishPos.x, finishPos.y, -0.02f);
            moveable = false;
        }

        StartCoroutine(WaitAndCheck());

        if (moveable)
        {
            Move();
        }
    }

    IEnumerator WaitAndCheck()
    {
        yield return new WaitForSeconds(2.5f);

        if (gameObject.transform.position == new Vector3(finishPos.x, finishPos.y, -0.02f) && nameint != 2)
        {
            gameObject.transform.position = new Vector3(startPos.x, startPos.y, -0.02f);
            moveable = false;
        }
        else if (gameObject.transform.position == new Vector3(finishPos.x, finishPos.y, -0.02f) && nameint == 2)
        {
            moveable = false;
            finsihed = true;
            spiegel = GameObject.Find(spiegelname);
            spiegel.GetComponent<TileFinishM>().isFinished = true;
        }
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && finsihed == false)
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