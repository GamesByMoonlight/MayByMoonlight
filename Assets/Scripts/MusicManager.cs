using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] chorusPart;

    AudioSource[] audioSources;

    bool verse = true;

    void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        if (verse)
        {
            verse = false;
            float timeRemaining = audioSources[1].clip.length - 0.25f;

            yield return new WaitForSeconds(timeRemaining);
            audioSources[0].Play();
        }
        else
        {
            verse = true;
            float timeRemaining = audioSources[0].clip.length - 0.25f;

            yield return new WaitForSeconds(timeRemaining);

            if (audioSources[1].clip != chorusPart[0])
            {
                audioSources[1].clip = chorusPart[0];
            }
            else
            {
                audioSources[1].clip = chorusPart[1];
            }
            audioSources[1].Play();

        }

        StartCoroutine(Transition());

    }

}
