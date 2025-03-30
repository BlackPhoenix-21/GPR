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
    public bool HideAllways = false;
    void Update()
    {
        UI = GameObject.FindGameObjectsWithTag("UIHide");
        if (HideAllways)
        {
            foreach (GameObject ui in UI)
            {
                ui.SetActive(false);
            }
            return;
        }

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
