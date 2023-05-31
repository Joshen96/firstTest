using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker_sy : MonoBehaviour
{
    [SerializeField] private AudioSource AnnouncementSource = null;

    private bool isOutOfBoxCollider = true;

    private void Start()
    {
        AnnouncementSource = gameObject.AddComponent<AudioSource>();
        AnnouncementSource.clip = Resources.Load<AudioClip>("Announcement/Announcement_sound");  // Announcement_sound 로 안내방송 이름 정하기 (-)
        AnnouncementSource.playOnAwake = false;
        AnnouncementSource.loop = true;
    }

    private void Update()
    {
        if (isOutOfBoxCollider)
        {
            if (!AnnouncementSource.isPlaying) return;

            if (AnnouncementSource.volume > 0f)
                StartCoroutine("TurnDownVolume");
            else if (AnnouncementSource.volume <= 0f)
                AnnouncementSource.Stop();
        }
        else
        {
            if (!AnnouncementSource.isPlaying) AnnouncementSource.Play();

            if (AnnouncementSource.volume < 1f)
                StartCoroutine("TurnOnVolume");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube")                // Cube 이름 바꾸기(-) 태그로 바꾸던가
        {
            isOutOfBoxCollider = false;
            AnnouncementSource.volume = 0f;
        }
    }
    private void OnTriggerExit(Collider other)                // Cube 이름 바꾸기(-) 태그로 바꾸던가
    {
        if (other.gameObject.name == "Cube") isOutOfBoxCollider = true;
    }

    private IEnumerator TurnDownVolume()
    {
        yield return new WaitForSeconds(0.01f);
        AnnouncementSource.volume -= (Time.deltaTime * 0.25f);
    }

    private IEnumerator TurnOnVolume()
    {
        yield return new WaitForSeconds(0.01f);
        AnnouncementSource.volume += (Time.deltaTime * 0.25f);
    }
}
