using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LimitTime_sy : MonoBehaviour
{
    public float limitTime = 0f;                // 제한시간
    public TextMeshProUGUI textTimer = null;    // 제한시간 텍스트

    public void TimeCountdown()
    {
        limitTime -= Time.deltaTime;
    }

    public void TimeReset()
    {
        limitTime = 60;
    }
}
