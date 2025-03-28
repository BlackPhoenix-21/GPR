using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    private int targetLayer = 5;
    private GameObject[] UI;
    public GameObject statue;
    bool online = false;
    void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        UI = allObjects.Where(obj => obj.layer == targetLayer).ToArray();
    }

    void Update()
    {
        if (UI == null)
        {
            return;
        }

        if (statue.transform.position == new Vector3(0, 0, 0))
        {
            online = true;
        }
        else
        {
            online = false;
        }
        if (online)
        {
            foreach (GameObject ui in UI)
            {
                ui.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject ui in UI)
            {
                ui.SetActive(true);
            }
        }
    }
}
