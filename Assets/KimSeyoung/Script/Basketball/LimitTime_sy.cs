using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LimitTime_sy : MonoBehaviour
{
    [SerializeField] private float limitTime = 0f;
    [SerializeField] private TextMeshProUGUI textTimer = null;
    [SerializeField] private ScoreBoard_sy scoreBoard = null;

    public bool isPickBall = false;

    int min = 0;
    float sec = 0.0f;

    private void Awake()
    {
        limitTime = 60f;
        textTimer.text = "µµÀüÇØºÁ";
    }
    private void Update()
    {
        if (isPickBall)
        {
            TimeCountdown();
        }
    }

    public void TimeCountdown()
    {
        limitTime -= Time.deltaTime;

        if (limitTime > 10f)
        {
            textTimer.color = Color.white;
            min = (int)limitTime / 60;
            sec = limitTime % 60;
            textTimer.text = min + " : " + (int)sec;
        }

        if (limitTime <= 10f)
        {
            textTimer.color = Color.red;
            sec = limitTime % 10;
            textTimer.text = (int)sec + "ÃÊ";
        }

        if (limitTime <= 0f)
        {
            textTimer.color = Color.blue;
            textTimer.text = "³¡!";

            StartCoroutine("TimeReset");
        }
    }

    private IEnumerator TimeReset()
    {
        yield return new WaitForSeconds(3.0f);

        isPickBall = false;
        limitTime = 60f;
        textTimer.color = Color.white;
        textTimer.text = "µµÀüÇØºÁ";
        scoreBoard.ScoreReset();
    }
}
