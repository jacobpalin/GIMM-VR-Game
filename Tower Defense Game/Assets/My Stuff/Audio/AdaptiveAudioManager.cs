using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AdaptiveAudioManager : MonoBehaviour {

    public int currentAdaptiveLevel;
    public AudioMixerSnapshot[] snapshotLevels;
    public float transitionTime = 2; // This is public so set it in the inspector

    public bool gameStarted = false;

	public void AdjustAudioLevel(int level)
    {
        currentAdaptiveLevel = level;

        Debug.Log("audio level: " + currentAdaptiveLevel);

        snapshotLevels[currentAdaptiveLevel-1].TransitionTo(transitionTime);
    }

    public void ChangeMusic()
    {
        if (gameStarted == false)
        {
            AdjustAudioLevel(1);
        }
        else if (gameStarted == true)
        {
            AdjustAudioLevel(2);
        }
    }
}