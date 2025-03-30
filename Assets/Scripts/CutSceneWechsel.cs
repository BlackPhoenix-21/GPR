using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutSceneWechsel : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip videoClip;
    void Start()
    {

    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(33.25f);
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
    }
}
