using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFinishM : MonoBehaviour
{
    [HideInInspector]
    public Vector2 finsihedTilePos;
    [HideInInspector]
    public bool isFinished = false;
    void Start()
    {
        finsihedTilePos = new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
    }

}
