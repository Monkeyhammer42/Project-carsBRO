using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] _backgroundTracks;
    private int currentTrack;

    void Start()
    {
        PlayBackground();
    }
    void PlayBackground()
    {
        currentTrack = Random.Range(0, _backgroundTracks.Length);
        
            _backgroundTracks[currentTrack].Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
