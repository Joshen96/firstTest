using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager_sy : MonoBehaviour
{
    public AudioSource BGMaudioSource = null;
    public AudioSource ESoundAudioSource = null;
    public bool isPlayMode = false;

    private void Awake()
    {
        if (BGMaudioSource == null) BGMaudioSource = this.GetComponent<AudioSource>();
        BGMaudioSource.volume = 0.4f;
        BGMaudioSource.loop = true;
        BGMaudioSource.clip = Resources.Load<AudioClip>("BGM/outside_Class_sound");
        BGMaudioSource.Play();

        ESoundAudioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBGM(string _audioClipName)
    {
        StopBGM();
        BGMaudioSource.clip = Resources.Load<AudioClip>("BGM/" + _audioClipName);
        BGMaudioSource.volume = 0.4f;
        BGMaudioSource.Play();
    }

    public void StopBGM()
    {
        BGMaudioSource.Pause();
    }

    public void PlayEffectSound(string _effectSoundName)
    {
        ESoundAudioSource.clip = Resources.Load<AudioClip>("SoundEffect/" + _effectSoundName); // 클립 설정
        ESoundAudioSource.volume = 1f;
        ESoundAudioSource.Play();
    }
    public void PlayEffectSound(string _effectSoundName, float _volume)
    {
        StopEffectSound();
        ESoundAudioSource.clip = Resources.Load<AudioClip>("SoundEffect/" + _effectSoundName); // 클립 설정
        ESoundAudioSource.volume = _volume;
        ESoundAudioSource.Play();
    }

    public void StopEffectSound()
    {
        ESoundAudioSource.Stop();
    }
}
