using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFinishM : MonoBehaviour
{
    public Vector2 finsihedTilePos;

    void Start()
    {
        finsihedTilePos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

}
