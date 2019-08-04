using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    AudioSource audio;
    public Slider volume;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ToggleMusic()
    {
        audio.mute = !audio.mute;
    }

    public void VolumeSlider()
    {
        audio.volume = volume.value;
    }
}
