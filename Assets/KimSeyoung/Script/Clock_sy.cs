using UnityEngine;
using System.Collections;

public class Clock_sy : MonoBehaviour 
{

    //-- set start time 00:00
    public int minutes = 0;
    public int hour = 0;

    //-- time speed
    // 1.0f = realtime
    public float clockSpeed = 1.0f;

    //-- internal
    int seconds;
    float msecs;
    GameObject pointerSeconds; // ��
    GameObject pointerMinutes; // ��
    GameObject pointerHours;   // �ð�



    void Start()
    {
        pointerSeconds = transform.GetChild(2).gameObject;
        pointerMinutes = transform.GetChild(1).gameObject;
        pointerHours = transform.GetChild(0).gameObject;

        msecs = 0.0f;
        seconds = 0;
    }



    void Update()
    {
        // �ð� ���
        msecs += Time.deltaTime * clockSpeed;
        if (msecs >= 1.0f)
        {
            msecs -= 1.0f;
            seconds++;

            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
                if (minutes > 60)
                {
                    minutes = 0;
                    hour++;
                    if (hour >= 24)
                        hour = 0;
                }
            }
        }


        // �ޱ� ���
        float rotationSeconds = (360.0f / 60.0f) * seconds;
        float rotationMinutes = (360.0f / 60.0f) * minutes;
        float rotationHours = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

        // �ޱ۷� ��ġ����
        pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);
    }

}