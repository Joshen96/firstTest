using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LimitTime_sy : MonoBehaviour
{
    public float limitTime = 0f;                // ���ѽð�
    public TextMeshProUGUI textTimer = null;    // ���ѽð� �ؽ�Ʈ

    public void TimeCountdown()
    {
        limitTime -= Time.deltaTime;
    }

    public void TimeReset()
    {
        limitTime = 60;
    }
}
