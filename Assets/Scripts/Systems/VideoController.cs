using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    #region Singleton
    public static VideoController instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    public VideoPlayer vidplayer;

    // Start is called before the first frame update
    void Start()
    {
        vidplayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play(string url)
    {
        vidplayer.url = url;
        vidplayer.Play();
        vidplayer.isLooping = false;
    }
}
