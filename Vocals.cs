using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    public static Vocals instance;

    private AudioSource source;

    string lang;
    PlayerData data;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();
        string json = File.ReadAllText(Application.dataPath + "/playerData.json");
        data = JsonUtility.FromJson<PlayerData>(json);
    }

    public void Say(AudioObject clip)
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
        source.PlayOneShot(clip.clip);
        Debug.Log(data.lang);
        if(data.lang == 1)
        {
            SubtitlesUI.instance.SetSubtitle(clip.subtitlePL, clip.clip.length);

        }
        else
        {
            SubtitlesUI.instance.SetSubtitle(clip.subtitleEN, clip.clip.length);

        }


    }
}
