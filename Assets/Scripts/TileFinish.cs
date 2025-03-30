using System;
using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class TileFinish : MonoBehaviour
{
    [HideInInspector]
    public Vector2[] finsihedTilePos = new Vector2[7] { new Vector2(0.11f, 3.51f), new Vector2(-2.08f, 2.23f),
    new Vector2(1.1f, 0.48f), new Vector2(-1.61f, 0.42f), new Vector2(1.68f, -0.76f), new Vector2(-0.92f, -0.72f),
    new Vector2(1.56f,-2.43f) };
    [HideInInspector]
    public bool[] finishedTiles = new bool[7] { false, false, false, false, false, false, false };
    [HideInInspector]
    public bool[] visibelTiles = new bool[7] { false, false, false, false, false, false, false };
    private Vector3[] vector3s;
    private GameObject[] tiles;
    private bool[] tilesBool = new bool[7] { false, false, false, false, false, false, false };
    public GameObject shrine;
    public Sprite sprite;
    public GameObject background;
    private TimeHandler timeHandler;
    private int count = 0;
    void Awake()
    {
        shrine.SetActive(false);
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        vector3s = new Vector3[tiles.Length];
        for (int i = 0; i < tiles.Length; i++)
        {
            vector3s[i] = tiles[i].transform.position;
        }
        RandomizeTiles();
    }

    private void RandomizeTiles()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            int random;
            do
            {
                random = UnityEngine.Random.Range(0, tiles.Length);
            } while (tilesBool[random] || vector3s[random] == tiles[i].transform.position);

            tiles[i].transform.position = vector3s[random];
            tilesBool[random] = true;
        }
    }

    void Start()
    {
        for (int i = 0; i < visibelTiles.Length; i++)
        {
            visibelTiles[i] = true;
        }
    }

    void Update()
    {
        if (count == 7)
        {
            return;
        }
        count = 0;
        for (int i = 0; i < finishedTiles.Length; i++)
        {
            if (finishedTiles[i])
            {
                count++;
            }
        }
        if (count == 7)
        {
            shrine.SetActive(true);
            background.GetComponent<SpriteRenderer>().sprite = sprite;
            StartCoroutine(HoldUp());
        }
    }
    IEnumerator HoldUp()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Find("Exit: Use").GetComponent<Interaction>().RunFromIndex(0);
        GameObject.Find("StatueFinished").GetComponent<Interaction>().RunFromIndex(0);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        timeHandler = player.GetComponentInChildren<TimeHandler>();
        timeHandler.timerActive = true;
    }
}