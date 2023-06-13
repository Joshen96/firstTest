using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportCard_sy : MonoBehaviour
{
    public static ReportCard_sy ReportCard = null;

    public bool isSolvingProblem = false;
    public bool isFindingCat = false;
    public bool isShootingFirecraker = false;
    public bool isPlayingBasketball = false;
    public bool isCatchingThief = false;
    public bool isFindingEasteregg = false;

    public GameObject[] checkPoints = new GameObject[8];

    public void Awake()
    {
        var obj = FindObjectsOfType<ReportCard_sy>();

        if (obj.Length == 1) DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);

        ReportCard = this;

        for (int i = 0; i < checkPoints.Length; i++) checkPoints[i].SetActive(false);
    }

    public void ShowReportCard() // 플레이어가 특정 키 눌리면 (-)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        checkPoints[0].SetActive(true);

        if (isSolvingProblem)
        {
            checkPoints[1].SetActive(true);
        }
        if (isFindingCat)
        {
            checkPoints[2].SetActive(true);
        }
        if (isShootingFirecraker)
        {
            checkPoints[3].SetActive(true);
        }
        if (isPlayingBasketball)
        {
            checkPoints[4].SetActive(true);
        }
        if (isCatchingThief)
        {
            checkPoints[5].SetActive(true);
        }
        if (isFindingEasteregg)
        {
            checkPoints[6].SetActive(true);
        }
        if (isSolvingProblem && isFindingCat && isShootingFirecraker && isPlayingBasketball && isCatchingThief && isFindingEasteregg)
        {
            checkPoints[7].SetActive(true);
        }
    }

    public void CoverReportCard() //플레이어가 특정키에서 손을 때면(-)
    { transform.GetChild(0).gameObject.SetActive(false); }
}
