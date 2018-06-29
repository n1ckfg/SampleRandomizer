using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleRandomizer : MonoBehaviour {

    public AudioClip[] samples;
    public float pitchVariation = 0.1f;
    public float playInterval = 3f;
    public float playIntervalVariation = 0.1f;
    public AudioSource audioSource;
    public bool looped = false;
    public bool playOnStart = false;

    private void Awake() {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        if (playOnStart) playLoop();
	}
	
    public void playSample() {
        int chooseSample = (int) (Random.Range(0f, 1f) * samples.Length);
        audioSource.clip = samples[chooseSample];
        audioSource.pitch = 1f + Random.Range(-pitchVariation, pitchVariation);
        audioSource.Play();
    }

    public void stopSample() {
        audioSource.Stop();
    }

    public void playLoop() {
        looped = true;
        StartCoroutine(looper());
    }

    public void stopLoop() {
        looped = false;
    }

    private IEnumerator looper() {
        while (looped) {
            playSample();
            yield return new WaitForSeconds(playInterval + Random.Range(-playIntervalVariation, playIntervalVariation));
        }
    }


}
