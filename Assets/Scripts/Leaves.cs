using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }
}
