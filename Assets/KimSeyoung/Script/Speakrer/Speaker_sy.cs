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
        AnnouncementSource.clip = Resources.Load<AudioClip>("Announcement/Announcement_sound");  // Announcement_sound �� �ȳ���� �̸� ���ϱ� (-)
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
        if (other.gameObject.name == "Cube")                // Cube �̸� �ٲٱ�(-) �±׷� �ٲٴ���
        {
            isOutOfBoxCollider = false;
            AnnouncementSource.volume = 0f;
        }
    }
    private void OnTriggerExit(Collider other)                // Cube �̸� �ٲٱ�(-) �±׷� �ٲٴ���
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
