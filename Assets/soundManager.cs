using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    //What is a sound manager?
    //Is static so has instance
    //Has a play pause stop
    //That's it?

    public static soundManager soundsSingleton = null;

    public AudioSource firstSong;
    public AudioSource[] temp;

    public GameObject soundEffectHolder;

    static float pitchBackGround = 1;
    static float volumeBackGround = 1;
    static bool isMutedSoundEffects = false;
    static bool isMutedBackground = false;

    AudioSource backgroundPlaying;


    public void Awake()
    {
        if (soundsSingleton == null)
        {
            soundsSingleton = this;
            return;
        }
        Destroy(this);
    }

    public void startBackgroundSong(string name)
    {

        switch (name)
        {
            case "Blazer Rail":
                backgroundPlaying = (firstSong);
                break;
        }
        backgroundPlaying.Play();
        if (isMutedBackground == true)
        {
            backgroundPlaying.mute = true;
        }
    }

    public void pauseBackgroundSong()
    {

        backgroundPlaying.Pause();

    }

    public void unPauseBackgroundSong()
    {
        backgroundPlaying.UnPause();

    }

    public void stopBackGroundMusic()
    {
        backgroundPlaying.Stop();

    }

    public void muteBackGround(bool onOff)
    {
        switch (onOff)
        {
            case true:
                isMutedBackground = true;
                backgroundPlaying.mute = true;
                break;
            case false:
                isMutedBackground = false;
                backgroundPlaying.mute = false;
                break;
        }
    }

    public void muteSoundEffects(bool onOff)
    {
        switch (onOff)
        {
            case true:
                isMutedSoundEffects = true;
                break;
            case false:
                isMutedSoundEffects = false;
                break;
        }
    }

    public void playSoundEffect(int childIndex, float volume = 1.0f, float pitch = 1.0f)
    {
        soundEffectHolder.gameObject.transform.GetChild(childIndex).gameObject.GetComponent<AudioSource>().Play();
        soundEffectHolder.gameObject.transform.GetChild(childIndex).gameObject.GetComponent<AudioSource>().volume = volume;
        soundEffectHolder.gameObject.transform.GetChild(childIndex).gameObject.GetComponent<AudioSource>().pitch = pitch;
    }

    public void changePitch(float newPitch)
    {
        muteBackGround(false);
        pitchBackGround = newPitch;
        backgroundPlaying.pitch = pitchBackGround;
    }

    public void changeVolume(float newVolume)
    {
        muteBackGround(false);
        volumeBackGround = newVolume;
        backgroundPlaying.volume = volumeBackGround;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}