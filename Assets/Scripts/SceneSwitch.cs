using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public float delay;
    public string sceneName;
    void Start()
    {
        StartCoroutine(WaitAndSwitch());
    }

    IEnumerator WaitAndSwitch()
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
