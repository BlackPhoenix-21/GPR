using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTileGod : MonoBehaviour
{
    private GameObject statue;
    private int tileName;
    private Vector3 finishPos;
    private float floater = 0.25f;
    private bool moveable = false;
    void Start()
    {
        statue = GameObject.Find("Statue");
        string name = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        tileName = int.Parse(name.Split("1_")[1]) - 1;
        finishPos = (Vector3)statue.GetComponent<TileFinish>().finsihedTilePos[tileName];
    }

    void Update()
    {
        if (statue.GetComponent<TileFinish>().visibelTiles[tileName])
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

        if (gameObject.transform.position.x > finishPos.x - floater && gameObject.transform.position.x < finishPos.x + floater &&
            gameObject.transform.position.y > finishPos.y - floater && gameObject.transform.position.y < finishPos.y + floater)
        {
            moveable = false;
            gameObject.transform.position = new Vector3(finishPos.x, finishPos.y, -0.02f);
            statue.GetComponent<TileFinish>().finishedTiles[tileName] = true;
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
