using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class OnlineVideoHandler : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip[] videos;
    //public string videoUrl = "yourvideourl";
    public Slider tracker;
    public bool onDrag;
    public int videoIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*videoPlayer.url = videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();*/
    }

    private void Update()
    {
        if (videoPlayer.isPlaying && !onDrag)
        {
            tracker.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }        
    }

    public void OnDrag()
    {
        onDrag = true;
    }

    public void OnUp()
    {
        onDrag = false;
        float frame = (float)tracker.value * (float)videoPlayer.frameCount;
        videoPlayer.frame = (long)frame;
    }

    public void SwitchVideo()
    {
        if (videoIndex == videos.Length - 1)
        {
            videoIndex = 0;
        }
        else
        {
            videoIndex++;
        }
        videoPlayer.Pause();
        videoPlayer.clip = videos[videoIndex];
        StartCoroutine(AutoPlayVid());
    }

    IEnumerator AutoPlayVid()
    {
        videoPlayer.Prepare();
        yield return new WaitUntil(() => videoPlayer.isPrepared == true);        
        videoPlayer.Play();
    }


}
