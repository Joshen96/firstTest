using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//[RequireComponent(typeof(VideoPlayer))]
public class Screen : MonoBehaviour
{
    private VideoPlayer vp = null;
    //private UnityEngine.Video.VideoPlayer uvvp = null;

    private void Awake()
    {
        vp = GetComponent<VideoPlayer>();
        if (vp == null)
        {
            vp =
                gameObject.AddComponent<VideoPlayer>();
        }
        vp.playOnAwake = true;
        vp.isLooping = true;
    }

    public void SetVideoClip(VideoClip _clip)
    {
        vp.clip = _clip;
    }

    public void Play()
    {
        if (vp.isPlaying) return;
        vp.Play();
    }

    public void Pause()
    {
        if (vp.isPaused) return;
        vp.Pause();
    }
}
