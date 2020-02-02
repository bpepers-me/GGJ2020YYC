using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReferenceControl : MonoBehaviour
{
    public AudioSource referenceSource;
    public AudioSource[] trackSources;

    public void PlayReferenceAudio()
    {
        foreach(var source in trackSources)
        {
            source.Stop();
        }

        float startTime = 5.0f;

        referenceSource.time = startTime;
        referenceSource.Play();

        StartCoroutine(RestoreAudio(5f));
    }

    private IEnumerator RestoreAudio(float time)
    {
        yield return new WaitForSeconds(time);

        referenceSource.Stop();

        foreach (var source in trackSources)
        {
            source.Play();
        }
    }
}
