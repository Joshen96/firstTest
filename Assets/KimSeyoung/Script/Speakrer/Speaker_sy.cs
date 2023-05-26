using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker_sy : MonoBehaviour
{
    [SerializeField] private AudioSource AnnouncementSource = null;

    void Start()
    {
        AnnouncementSource = gameObject.AddComponent<AudioSource>();
        AnnouncementSource.clip = Resources.Load<AudioClip>("Announcement/Announcement_sound");  // Announcement_sound 로 안내방송 이름 정하기 (-)
        AnnouncementSource.playOnAwake = false;
        AnnouncementSource.maxDistance = 50f;
        AnnouncementSource.loop = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube") AnnouncementSource.Play();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cube") AnnouncementSource.Stop();
    }
}
