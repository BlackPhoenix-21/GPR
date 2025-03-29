using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class LevelCheck : MonoBehaviour
{
    void Start()
    {
        GetComponent<Interaction>().RunFromIndex(4);
        if (GlobalVariables.GetBooleanValue(4))
        {
            GetComponent<Interaction>().RunFromIndex(0);
        }
    }

    void Update()
    {
        GameObject[] spiegel = GameObject.FindGameObjectsWithTag("Spiegel");
        int count = 0;
        foreach (var item in spiegel)
        {
            if (item.GetComponent<TileFinishM>().isFinished == true)
            {
                count++;
            }
        }
        if (count == 7)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameWin");
        }
    }
}