﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineReaccio : Reaccio
{
    public List<PlayableDirector> playableDirectors;
    public List<TimelineAsset> timelines;

    protected override void ExecutaReaccio()
    {
        Play();
    }

    public void Play()
    {
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            playableDirector.Play();

            
        }
    }

    public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedAsset;

        selectedAsset = timelines[index];

        playableDirectors[0].Play(selectedAsset);
    }
}