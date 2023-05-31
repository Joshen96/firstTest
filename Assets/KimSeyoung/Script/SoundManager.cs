using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGMaudioSource = null;
    public AudioSource ESoundAudioSource = null;

    private void Awake()
    {
        if (BGMaudioSource == null) BGMaudioSource = this.GetComponent<AudioSource>();
        BGMaudioSource.volume = 0.5f;
        BGMaudioSource.clip = Resources.Load<AudioClip>("BGM/outside_Class_sound");
        BGMaudioSource.Play();

        ESoundAudioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayBGM(string _audioClipName)
    {
        BGMaudioSource.clip = Resources.Load<AudioClip>("BGM/"+ _audioClipName);
        BGMaudioSource.volume = 1f;
        BGMaudioSource.Play();
    }

    public void StopBGM()
    {
        BGMaudioSource.Stop();
    }

    public void PlayEffectSound(string _effectSoundName)
    {
        ESoundAudioSource.clip = Resources.Load<AudioClip>("SoundEffect/" + _effectSoundName); // 클립 설정
        ESoundAudioSource.volume = 0.5f;              // 볼륨 최대로 기본 설정
        ESoundAudioSource.Play();

    }
    public void StopEffectSound()
    {
        ESoundAudioSource.Stop();
    }
}
