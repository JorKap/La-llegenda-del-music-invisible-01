using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioClipPlay : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource source;
    Animator animator;
   

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    private void OnMouseDown()
    {

        animator.SetBool("stop", false);
        animator.SetBool("play", true);

        source = Recording.instance.source;
        source.clip = audioClip;
        source.Play();
        if(Recording.instance.timerActive)
            Recording.instance.audioClips.Add(audioClip);

    }

    private void OnMouseUp()
    {

        animator.SetBool("play", false);
        animator.SetBool("stop", true);
       

    }
}
