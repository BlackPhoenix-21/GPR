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
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (var item in KickStarter.runtimeInventory.localItems)
        {
            for (int i = 1; i < 8; i++)
            {
                if (item != null && item.linkedPrefab != null && item.linkedPrefab.name == "Statue_" + i)
                {
                    tileNum++;
                    KickStarter.runtimeInventory.Remove(item.id);
                    continue;
                }
            }
        }
        foreach (var item in KickStarter.runtimeInventory.localItems)
        {
            for (int i = 1; i < 8; i++)
            {
                if (item != null && item.linkedPrefab != null && item.linkedPrefab.name == "Statue_" + i)
                {
                    if (tileNum >= 7)
                    {
                        KickStarter.runtimeInventory.Remove(item.id);
                    }
                    continue;
                }
            }
        }
        if (tileNum >= 7)
        {
            hotspot.enabled = true;
            Destroy(destroyObject);
        }
    }
}