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
        GameObject[] spiegel = new GameObject[4];
        for (int i = 1; i < 5; i++)
        {
            spiegel[i - 1] = GameObject.Find("Spiegel" + i);
        }
        int count = 0;
        foreach (var item in spiegel)
        {
            if (item.GetComponent<TileFinishM>().isFinished == true)
            {
                count++;
                Debug.Log("Spiegel " + item.name + " is finished.");
                Debug.Log("Count: " + count);
            }
        }
        if (count == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameWin");
        }
    }
}