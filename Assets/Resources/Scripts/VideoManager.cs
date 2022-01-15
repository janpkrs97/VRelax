using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    //private AudioSource audioSource;
    private GameObject playBtn;
    private GameObject pauseBtn;
    private GameObject stopBtn;
    private GameObject resetViewBtn;
    private GameObject skipAheadBtn;
    private GameObject skipBackBtn;
    private GameObject audioBtn;
    private GameObject audioMuteBtn;
    private GameObject guidedImg;
    public VideoClip videoClip0;
    public VideoClip videoClip1;
    public static bool guided = false;

    public void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        //audioSource = GetComponent<AudioSource>();

        if (MenuManager.videoID == 0)
        {
            videoPlayer.clip = videoClip0;
        }
        else if (MenuManager.videoID == 1)
        {
            videoPlayer.clip = videoClip1;
        }
       
        playBtn = GameObject.FindGameObjectWithTag("PlayBtn");
        pauseBtn = GameObject.FindGameObjectWithTag("PauseBtn");
        stopBtn = GameObject.FindGameObjectWithTag("StopBtn");
        resetViewBtn = GameObject.FindGameObjectWithTag("ResetViewBtn");
        skipAheadBtn = GameObject.FindGameObjectWithTag("SkipAheadBtn");
        skipBackBtn = GameObject.FindGameObjectWithTag("SkipBackBtn");
        audioBtn = GameObject.FindGameObjectWithTag("AudioBtn");
        audioMuteBtn = GameObject.FindGameObjectWithTag("AudioMuteBtn");
        guidedImg = GameObject.FindGameObjectWithTag("GuidedImg");

        pauseBtn.SetActive(false);
        audioMuteBtn.SetActive(false);

        if (guided)
        {
            guidedImg.SetActive(true);
        }
        else
        {
            guidedImg.SetActive(false);
        }

        Play();
    }

    public void Play()
    {
        videoPlayer.Play();
        //audioSource.Play();
        playBtn.SetActive(false);
        pauseBtn.SetActive(true);
    }

    public void Pause()
    {
        videoPlayer.Pause();
        //audioSource.Pause();
        pauseBtn.SetActive(false);
        playBtn.SetActive(true);
    }

    public void Stop()
    {
        videoPlayer.Stop();
        //audioSource.Stop();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void SkipAhead()
    {
        videoPlayer.time += 15.0f;
        //audioSource.time += 15.0f;
    }

    public void SkipBack()
    {
        videoPlayer.time -= 15.0f;
        //audioSource.time -= 15.0f;
    }

    public void MuteAudio()
    {
        //audioSource.mute = true;
        audioBtn.SetActive(false);
        audioMuteBtn.SetActive(true);
        videoPlayer.SetDirectAudioMute(0, true);
    }

    public void UnmuteAudio()
    {
        //audioSource.mute = false;
        audioMuteBtn.SetActive(false);
        audioBtn.SetActive(true);
        videoPlayer.SetDirectAudioMute(0, false);
    }
}
