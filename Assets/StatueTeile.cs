using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class StatueTeile : MonoBehaviour
{
    private Hotspot hotspot;
    private int tileNum = 0;
    void Start()
    {
        hotspot = GetComponent<Hotspot>();
        hotspot.enabled = false;
        foreach (var item in KickStarter.runtimeInventory.localItems)
        {
            if (item != null && item.linkedPrefab != null && item.linkedPrefab.name == gameObject.name)
            {
                tileNum++;
            }
        }
        if (tileNum == 7)
        {
            hotspot.enabled = true;
        }
    }
}