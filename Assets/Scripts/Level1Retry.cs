using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Retry : MonoBehaviour
{
    public string sceneName = "Level-1";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
