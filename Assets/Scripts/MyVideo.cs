using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class MyVideo : MonoBehaviour
{
    public VideoPlayer vPlayer;
    public GameObject rawImage;
    private double totaltime;         //视频总时长
    private float skiptime = 10;   //快进or快退的时间

    void Start()
    {
        vPlayer.loopPointReached += EndReached;
        totaltime = vPlayer.length;
    }

    //当视频播放完毕时关闭视频
    void EndReached(VideoPlayer vPlayer)
    {
        rawImage.SetActive(false);
    }

    //关闭视频
    public void close()
    {
        vPlayer.Stop();
        rawImage.SetActive(false);
    }

    //播放or暂停
    public void startandpause()
    {
        if(vPlayer.isPaused==true)
        {
            vPlayer.Play();
        }
        else if (vPlayer.isPlaying == true)
        {
            vPlayer.Pause();
        }
    }

    //倍速播放
    public void playspeed(int value)
    {
        float speed=1;
        switch (value)
        {
            case 0:
                speed =1;
                break;
            case 1:
                speed =0.5f;
                break;
            case 2:
                speed =1.5f;
                break;
            case 3:
                speed =2.0f;
                break;
        }
        vPlayer.playbackSpeed = speed;
    }

    //快进
    public void next()
    {
        vPlayer.time += skiptime;
    }

    //快退
    public void last()
    {
        vPlayer.time -= skiptime;
    }
}