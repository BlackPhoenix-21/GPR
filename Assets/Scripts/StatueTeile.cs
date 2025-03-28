using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class StatueTeile : MonoBehaviour
{
    private Hotspot hotspot;
    private int tileNum = 0;
    public GameObject destroyObject;
    void Start()
    {
        hotspot = GetComponent<Hotspot>();
        hotspot.enabled = false;
        StartCoroutine(OnLevelWasLoaded());
    }
    IEnumerator OnLevelWasLoaded()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (var item in KickStarter.runtimeInventory.localItems)
        {
            for (int i = 1; i < 8; i++)
            {
                if (item != null && item.linkedPrefab != null && item.linkedPrefab.name == "Statue_" + i)
                {
                    tileNum++;
                }
            }
        }
        if (tileNum == 7)
        {
            hotspot.enabled = true;
            Destroy(destroyObject);
        }
    }
}