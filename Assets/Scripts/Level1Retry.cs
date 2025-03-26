using System.Collections;
using System.Collections.Generic;
using AC;
using UnityEngine;

public class Level1Retry : MonoBehaviour
{
    private string sceneName;
    void Start()
    {
        sceneName = GlobalVariables.GetStringValue(0);
    }

    public void SceneChange()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
